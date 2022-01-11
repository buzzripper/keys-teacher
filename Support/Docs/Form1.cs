using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Avtec.Tools.LogViewer.Data;
using Avtec.Tools.LogViewer.Properties;

namespace Avtec.Tools.LogViewer
{
	public partial class Form1 : Form
	{
		#region Constants

		private const string DataFilename = "LogViewer.data";

		#endregion

		#region Static

		public static string ConnStr;

		#endregion

		#region Fields

		private string _dataFolder;
		private LogViewerData _logViewerData;
		private bool _suspendUpdates;
		private DatasourceForm _datasourceForm;
		private readonly Bitmap _sortAscBmp = Resources.SortAsc;
		private readonly Bitmap _sortDescBmp = Resources.SortDesc;
		private bool _sortAsc;
		private bool _autoRefresh = true;

		#endregion

		private DatasourceForm DatasourceForm
		{
			get { return _datasourceForm ?? (_datasourceForm = new DatasourceForm()); }
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_logViewerData = LoadData();

			PopulateForm();

			Form1_Resize(null, null);

			lvLogs.Focus();

			if (ApplicationDeployment.IsNetworkDeployed)
				// Running as click-once
				toolLblVersion.Text = string.Format("v. {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion);
			else
				toolLblVersion.Text = string.Format("v. {0}", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);

			// Prevents ListView flicker
			System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			aProp.SetValue(lvLogs, true, null);

			SelectInitialDbConn();
			SetAutoRefresh(true);
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			SetAutoRefresh(_autoRefresh);
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				SetAutoRefresh(_autoRefresh);
		}

		private void SelectInitialDbConn()
		{
			if (_logViewerData.DbConns.Count > 0)
			{
				DbConn defaultDatasource = _logViewerData.DbConns.FirstOrDefault(ds => ds.IsDefault);
				if (defaultDatasource != null)
				{
					cmbDbConns.SelectedItem = defaultDatasource;
					return;
				}

				if (!string.IsNullOrEmpty(_logViewerData.MRUConnStringName))
				{
					DbConn mruDatasource = _logViewerData.DbConns.FirstOrDefault(ds => ds.Name == _logViewerData.MRUConnStringName);
					if (mruDatasource != null)
					{
						cmbDbConns.SelectedItem = mruDatasource;
						return;
					}
				}
				cmbDbConns.SelectedIndex = 0;
			}
		}

		private LogViewerData LoadData()
		{
			try
			{
				_dataFolder = ApplicationDeployment.CurrentDeployment.DataDirectory;
			}
			catch (InvalidDeploymentException)
			{
				// This just means it's not running as a click-one application                
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, string.Format("{0} detecting data directory: {1}", ex.GetType().Name, ex), "Data Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (_dataFolder == null)
				_dataFolder = AppDomain.CurrentDomain.BaseDirectory;

			string dataFilepath = Path.Combine(_dataFolder, DataFilename);
			if (File.Exists(dataFilepath))
			{
				try
				{
					return XmlTools.DeserializeFromFile<LogViewerData>(dataFilepath);

				}
				catch (Exception ex)
				{
					statusLabel.Text = string.Format("Error reading data file: {0}", ex.Message);
				}
			}
			return new LogViewerData();
		}

		private void PopulateForm()
		{
			_suspendUpdates = true;
			try
			{
				cmbSeverity.Items.Add("TRACE");
				cmbSeverity.Items.Add("DEBUG");
				cmbSeverity.Items.Add("INFO");
				cmbSeverity.Items.Add("WARN");
				cmbSeverity.Items.Add("ERROR");
				cmbSeverity.Items.Add("FATAL");
				cmbSeverity.SelectedIndex = 0;

				foreach (DbConn dbConn in _logViewerData.DbConns)
					cmbDbConns.Items.Add(dbConn);

				cmbApplications.Items.Insert(0, string.Empty);
				cmbHostNames.Items.Insert(0, string.Empty);

				if (_logViewerData.WindowPlacement != null && !string.IsNullOrEmpty(_logViewerData.WindowPlacement.Value))
					WindowPlacement.SetPlacement(this.Handle, _logViewerData.WindowPlacement.Value);

				SetSortDirection(_logViewerData.MRUSortAsc);
			}
			finally
			{
				_suspendUpdates = false;
			}
		}

		private void SaveData()
		{
			string dataFilepath = Path.Combine(_dataFolder, DataFilename);
			try
			{
				XmlTools.SerializeToFile(_logViewerData, dataFilepath);

			}
			catch (Exception ex)
			{
				statusLabel.Text = string.Format("Error saving data file: {0}", ex.Message);
			}
		}

		private void cmbDbConn_SelectedIndexChanged(object sender, EventArgs e)
		{
			lvLogs.Focus();
			//SetAutoRefresh(true);
			DbConnChanged();
		}

		private void DbConnChanged()
		{
			if (cmbDbConns.SelectedItem == null)
			{
				btnEditDatasource.Enabled = false;
				btnDelDatasource.Enabled = false;
				ConnStr = string.Empty;
				return;
			}

			btnEditDatasource.Enabled = true;
			btnDelDatasource.Enabled = true;

			ResetApplicationFilterList();
			ResetHostNameFilterList();

			DbConn connStringData = (cmbDbConns.SelectedItem as DbConn);
			if (connStringData == null)
			{
				MessageBox.Show(this, "Connection string data is null.", "Connection String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			ConnStr = connStringData.ConnectionString;

			if (!_suspendUpdates)
			{
				RefreshData();
				RefreshFilterLists(true);
			}
		}

		private void ResetApplicationFilterList()
		{
			cmbApplications.Items.Clear();
			cmbApplications.Items.Add(string.Empty);
		}

		private void ResetHostNameFilterList()
		{
			cmbHostNames.Items.Clear();
			cmbHostNames.Items.Add(string.Empty);
		}

		private void RefreshAppNameFilterList(bool clearList)
		{
			if (clearList)
				ResetApplicationFilterList();
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStr))
				{
					conn.Open();

					// AppName
					using (SqlCommand cmd = new SqlCommand())
					{
						cmd.Connection = conn;
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "SELECT DISTINCT AppName FROM Log";
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								string appName = reader["AppName"].ToString();
								if (!cmbApplications.Items.Contains(appName))
									cmbApplications.Items.Add(appName);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				statusLabel.Text = string.Format("Error refreshing: {0}", ex.Message);
			}
		}

		private void RefreshMachineNameFilterList(bool clearList)
		{
			if (clearList)
				ResetHostNameFilterList();

			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStr))
				{
					conn.Open();

					// HostName
					using (SqlCommand cmd = new SqlCommand())
					{
						cmd.Connection = conn;
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = "SELECT DISTINCT HostName FROM Log";
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								string hostName = reader["HostName"].ToString();
								if (!cmbHostNames.Items.Contains(hostName))
									cmbHostNames.Items.Add(hostName);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				statusLabel.Text = string.Format("Error refreshing: {0}", ex.Message);
			}
		}

		private void ResetData()
		{
			if (Convert.ToInt32(txtPageNumber.Text) == 1)
				txtPageNumber_ValueChanged(null, null);
			else
				txtPageNumber.Text = "1";
		}

		private void RefreshData()
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				Refresh();
				FillGrid(Convert.ToInt32(txtPageNumber.Text), (int)numPageLength.Value);
				toolLblMessage.Text = null;
			}
			catch (Exception ex)
			{
				SetAutoRefresh(false);
				MessageBox.Show(ex.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void FillGrid(int startPage, int pageLength)
		{
			List<LogItem> logItems = new List<LogItem>();
			LogItem logItem;

			int startRow = ((startPage - 1) * pageLength) + 1;
			int endRow = startRow + pageLength;
			string sqlWhere = BuildWhereClause();
			string orderByDir = _sortAsc ? "DESC" : "ASC";

			string sql = string.Format(@"select 
                                                      MasterRowNums.*
                                                    from
                                                    (
                                                      select 
                                                        LogId, LogLevel, LogTimestamp, HostName, AppName, 
														LogSource, CurrentUser, LogMessage, AppSessionId, Thread, TraceId,
														CASE WHEN Exception = '' THEN 0 ELSE 1 END AS HasException,
                                                        ROW_NUMBER() OVER (ORDER BY LogTimestamp DESC) AS RowNum
                                                      FROM 
                                                        Log WITH(NOLOCK)
                                                      {0}
                                                    ) 
                                                      MasterRowNums
                                                    WHERE 
                                                      RowNum BETWEEN {1} AND {2}
                                                    ORDER BY 
                                                      LogTimestamp {3}, LogId ASC",
				sqlWhere,
				startRow,
				endRow,
				orderByDir);

			using (SqlConnection conn = new SqlConnection(ConnStr))
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.CommandType = CommandType.Text;

				try
				{
					conn.Open();
				}
				catch
				{
					// DB was probably re-created since the last calll, let's try once more
					conn.Open();
				}

				SqlDataReader reader;
				try
				{
					reader = cmd.ExecuteReader();
				}
				catch (SqlException sqlEx)
				{
					// Sql Error #10054 means the database rebuild script was recently run but the connection pool
					// didn't know about it so it tries connecting on a stale connection. Let's try once more..
					if (sqlEx.Number == 10054)
					{
						conn.Open();
						reader = cmd.ExecuteReader();
					}
					else
					{
						throw;
					}
				}

				try
				{
					while (reader.Read())
					{
						logItem = new LogItem {
							LogId = (int)reader["LogId"],
							LogLevel = reader["LogLevel"].ToString(),
							LogTimestamp = ((DateTime)reader["LogTimestamp"]).ToLocalTime(),
							HostName = reader["HostName"].ToString(),
							AppName = reader["AppName"].ToString(),
							LogSource = reader["LogSource"].ToString(),
							CurrentUser = reader["CurrentUser"].ToString(),
							LogMessage = reader["LogMessage"].ToString(),
							AppSessionId = reader["AppSessionId"].ToString(),
							Thread = reader["Thread"].ToString(),
							TraceId = reader["TraceId"].ToString(),
							HasException = ((int)reader["HasException"] == 1)
						};
						logItems.Add(logItem);
					}
				}
				finally
				{
					reader.Dispose();
				}
			}

			// If there were no items just clear the list and return
			if (logItems.Count == 0)
			{
				lvLogs.Items.Clear();
				return;
			}

			lvLogs.Items.Clear();
			foreach (LogItem item in logItems)
			{
				var timestampStr = item.LogTimestamp.Date == DateTime.Now.Date ? item.LogTimestamp.ToString("h:mm:ss.fff") : item.LogTimestamp.ToString("h:mm:ss.fff M/d/yy");

				ListViewItem lvItem = new ListViewItem(new[] { timestampStr, item.AppName, item.HostName, item.LogSource, item.LogMessage });
				lvItem.ToolTipText = item.LogTimestamp.ToString("M/d/yy");
				lvItem.ImageIndex = LogLevelToImageIndex(item.LogLevel);
				lvItem.Tag = item;
				if (item.LogLevel == "ERROR" || item.LogLevel == "FATAL")
					lvItem.ForeColor = Color.Red;
				lvLogs.Items.Add(lvItem);
			}

			if (!_sortAsc)
				lvLogs.Items[lvLogs.Items.Count - 1].EnsureVisible();
		}

		private int LogLevelToImageIndex(string logLevel)
		{
			if (logLevel == "TRACE")
				return 0;
			if (logLevel == "DEBUG")
				return 1;
			if (logLevel == "INFO")
				return 2;
			if (logLevel == "WARN")
				return 3;
			if (logLevel == "ERROR")
				return 4;
			return 5;
		}

		private bool PurgeLogs()
		{
			string msg = string.Format("Are you sure you want to delete all logs in database {0}?", cmbDbConns.SelectedText);
			if (MessageBox.Show(msg, "Confirm Delete Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return false;

			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStr))
				using (SqlCommand cmd = new SqlCommand())
				{
					try
					{
						conn.Open();
					}
					catch (SqlException)
					{
						// Try once more
						conn.Open();
					}

					cmd.Connection = conn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "DELETE FROM Log";
					cmd.CommandTimeout = 300;       // 5 minutes, sometimes these take a long time

					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException sqlEx)
					{
						// Sql Error #10054 means the database rebuild script was recently run but the connection pool
						// didn't know about it so it tries connecting on a stale connection. Another try will get a new connection, so let's try
						if (sqlEx.Number == 10054)
						{
							conn.Open();
							cmd.ExecuteNonQuery();
						}
						else
						{
							throw;
						}
					}

					cmbApplications.Items.Clear();
					cmbHostNames.Items.Clear();
				}

				return true;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		private void RemoveAllUnclearedAlarms()
		{
			string msg = string.Format("Are you sure you want remove all Uncleared alarms in database {0}?", cmbDbConns.SelectedText);
			if (MessageBox.Show(msg, "Confirm remove all uncleared Alarms", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;

			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStr))
				using (SqlCommand cmd = new SqlCommand())
				{
					try
					{
						conn.Open();
					}
					catch (SqlException)
					{
						// Try once more
						conn.Open();
					}

					cmd.Connection = conn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "DELETE FROM dbo.Alarm WHERE ClearDateTime IS NULL";
					cmd.CommandTimeout = 300;       // 5 minutes, sometimes these take a long time

					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException sqlEx)
					{
						// Sql Error #10054 means the database rebuild script was recently run but the connection pool
						// didn't know about it so it tries connecting on a stale connection. Another try will get a new connection, so let's try
						if (sqlEx.Number == 10054)
						{
							conn.Open();
							cmd.ExecuteNonQuery();
						}
						else
						{
							throw;
						}
					}
					ListViewItem lvItem = new ListViewItem(new[] { DateTime.Now.ToString(), "Logger", "Logger", "Logger", "All Uncleared Alarms removed from database" });
					lvItem.ForeColor = Color.Blue;
					lvLogs.Items.Add(lvItem);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RemoveAllUnAckAlarms()
		{
			string msg = string.Format("Are you sure you want to remove all  Unacknowledged alarms in the database {0}?", cmbDbConns.SelectedText);
			if (MessageBox.Show(msg, "Confirm remove all Unacknowledged alarms", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;

			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStr))
				using (SqlCommand cmd = new SqlCommand())
				{
					try
					{
						conn.Open();
					}
					catch (SqlException)
					{
						// Try once more
						conn.Open();
					}

					cmd.Connection = conn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "DELETE FROM dbo.Alarm WHERE AckDateTime IS NULL";
					cmd.CommandTimeout = 300;       // 5 minutes, sometimes these take a long time

					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException sqlEx)
					{
						// Sql Error #10054 means the database rebuild script was recently run but the connection pool
						// didn't know about it so it tries connecting on a stale connection. Another try will get a new connection, so let's try
						if (sqlEx.Number == 10054)
						{
							conn.Open();
							cmd.ExecuteNonQuery();
						}
						else
						{
							throw;
						}
					}
					ListViewItem lvItem = new ListViewItem(new[] { DateTime.Now.ToString(), "Logger", "Logger", "Logger", "All Unacknowledged Alarms removed from database" });
					lvItem.ForeColor = Color.Blue;
					lvLogs.Items.Add(lvItem);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string BuildWhereClause()
		{
			List<string> whereList = new List<string>();

			// Severity
			if (cmbSeverity.SelectedIndex > 0)
			{
				if (cmbSeverity.SelectedIndex == 1) // DEBUG
					whereList.Add("LogLevel = 'DEBUG' OR LogLevel = 'INFO' OR LogLevel = 'WARN' OR LogLevel = 'ERROR' OR LogLevel = 'FATAL' ");
				else if (cmbSeverity.SelectedIndex == 2) // INFO
					whereList.Add("LogLevel = 'INFO' OR LogLevel = 'WARN' OR LogLevel = 'ERROR' OR LogLevel = 'FATAL' ");
				else if (cmbSeverity.SelectedIndex == 3) // WARN
					whereList.Add("LogLevel = 'WARN' OR LogLevel = 'ERROR' OR LogLevel = 'FATAL' ");
				else if (cmbSeverity.SelectedIndex == 4) // ERROR
					whereList.Add("(LogLevel = 'ERROR' OR LogLevel = 'FATAL') ");
				else
					whereList.Add("LogLevel = 'FATAL' ");
			}

			// HostName
			if (cmbHostNames.SelectedIndex > 0)
			{
				whereList.Add(string.Format("HostName = '{0}' ", cmbHostNames.Text));
			}

			// AppName
			if (cmbApplications.SelectedIndex > 0)
			{
				whereList.Add(string.Format("AppName = '{0}' ", cmbApplications.Text));
			}

			// LogSource
			if (!string.IsNullOrEmpty(txtSource.Text))
			{
				whereList.Add(string.Format("LogSource LIKE '%{0}%' ", txtSource.Text));
			}

			// LogMessage
			if (!string.IsNullOrEmpty(txtMessage.Text))
			{
				whereList.Add(string.Format("LogMessage LIKE '%{0}%' ", txtMessage.Text));
			}

			string result = null;

			if (whereList.Count > 0)
			{
				result = "WHERE ";
				for (int i = 0; i < whereList.Count; i++)
				{
					if (i > 0)
						result += " AND ";
					result += whereList[i];
				}
			}

			return result;
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				_autoRefresh = timer1.Enabled;
				SetAutoRefresh(false);
			}
			else
			{
				lvLogs.Columns[4].Width = lvLogs.Width - lvLogs.Columns[0].Width - lvLogs.Columns[1].Width - lvLogs.Columns[2].Width - lvLogs.Columns[3].Width - 22;
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			ResetData();
		}

		private void txtPageNumber_ValueChanged(object sender, EventArgs e)
		{
			RefreshData();
		}

		private DetailForm _detailForm;

		private DetailForm DetailForm
		{
			get { return _detailForm ?? (_detailForm = new DetailForm(this)); }
		}

		private void lvLogs_DoubleClick(object sender, EventArgs e)
		{
			if (lvLogs.SelectedItems.Count == 1)
			{
				DetailForm.ShowLog(lvLogs.SelectedItems[0].Tag as LogItem);
			}
		}

		public LogItem GetPrevLogItem()
		{
			if (lvLogs.SelectedItems.Count == 0)
				return null;

			int idx = lvLogs.SelectedItems[0].Index;
			if (idx > 0)
			{
				lvLogs.Items[idx - 1].Selected = true;
				return lvLogs.Items[idx - 1].Tag as LogItem;
			}
			return null;
		}

		public LogItem GetNextLogItem()
		{
			if (lvLogs.SelectedItems.Count == 0)
				return null;

			int idx = lvLogs.SelectedItems[0].Index;
			if (idx < lvLogs.Items.Count - 1)
			{
				lvLogs.Items[idx + 1].Selected = true;
				return lvLogs.Items[idx + 1].Tag as LogItem;
			}
			return null;
		}

		private void btnClearLogs_Click(object sender, EventArgs e)
		{
			if (PurgeLogs())
				lvLogs.Items.Clear();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_logViewerData.MRUConnStringName = cmbDbConns.Text;

			var cdata = new XmlDocument().CreateCDataSection(WindowPlacement.GetPlacement(this.Handle));
			_logViewerData.WindowPlacement = cdata;

			SaveData();
		}

		private void btnClearFilters_Click(object sender, EventArgs e)
		{
			ClearFilters();
			ResetData();
		}

		private void ClearFilters()
		{
			_suspendUpdates = true;
			try
			{
				cmbSeverity.SelectedIndex = 0;
				txtSource.Text = string.Empty;
				cmbHostNames.SelectedIndex = 0;
				cmbApplications.SelectedIndex = 0;
				txtMessage.Text = string.Empty;
			}
			finally
			{
				_suspendUpdates = false;
			}
		}

		private void btnPageDown_Click(object sender, EventArgs e)
		{
			int pgNum = Convert.ToInt32(txtPageNumber.Text);
			if (pgNum == 1)
				return;
			txtPageNumber.Text = (pgNum - 1).ToString();
		}

		private void btnPageUp_Click(object sender, EventArgs e)
		{
			int pgNum = Convert.ToInt32(txtPageNumber.Text);
			txtPageNumber.Text = (pgNum + 1).ToString();
		}

		private void btnAddDatasource_Click(object sender, EventArgs e)
		{
			try
			{
				if (DatasourceForm.Run(new DbConn()))
				{
					_logViewerData.DbConns.Add(DatasourceForm.DbConn);
					int idx = cmbDbConns.Items.Add(DatasourceForm.DbConn);
					cmbDbConns.SelectedIndex = idx;
					RefreshFilterLists(true);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("(btnAddDatasource_Click) {0}: {1}", ex.GetType().Name, ex.Message));
			}
		}

		private void btnEditDatasource_Click(object sender, EventArgs e)
		{
			try
			{

				DbConn datasource = cmbDbConns.SelectedItem as DbConn;
				if (datasource == null)
					return;
				int idx = _logViewerData.DbConns.IndexOf(datasource);
				if (idx == -1)
				{
					MessageBox.Show("Error with connection list.");
					return;
				}

				if (DatasourceForm.Run(datasource))
				{
					_logViewerData.DbConns[idx].Apply(DatasourceForm.DbConn);

					// If this is set as the default datasource, clear all others
					if (datasource.IsDefault)
						for (var i = 0; i < _logViewerData.DbConns.Count; i++)
							_logViewerData.DbConns[i].IsDefault = (i == idx);

					cmbDbConns.Items[idx] = DatasourceForm.DbConn;
					DbConnChanged();
					RefreshFilterLists(true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("(btnAddDatasource_Click) {0}: {1}", ex.GetType().Name, ex.Message));
			}
		}

		private void btnDelDatasource_Click(object sender, EventArgs e)
		{
			if (cmbDbConns.SelectedItem == null)
				return;

			if (MessageBox.Show(this, "Delete the selected datasource?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_logViewerData.DbConns.Remove(cmbDbConns.SelectedItem as DbConn);
				int idx = cmbDbConns.SelectedIndex;
				cmbDbConns.Items.RemoveAt(idx);
				if (idx < cmbDbConns.Items.Count)
					cmbDbConns.SelectedIndex = idx;
				else
					cmbDbConns.SelectedIndex = cmbDbConns.Items.Count - 1;
				RefreshFilterLists(true);
			}
		}

		private void cmbSeverity_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
			{
				RefreshData();
				lvLogs.Focus();
			}
		}

		private void cmbMachineNames_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
			{
				lvLogs.Focus();
				RefreshData();
			}
		}

		private void cmbApplications_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_suspendUpdates)
			{
				lvLogs.Focus();
				RefreshData();
			}
		}

		private void btnRefreshFilterLists_Click(object sender, EventArgs e)
		{
			RefreshFilterLists(true);
		}

		private void RefreshFilterLists(bool clearLists)
		{
			RefreshAppNameFilterList(clearLists);
			RefreshMachineNameFilterList(clearLists);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.R)
				RefreshData();
		}

		#region Auto-refresh

		private void btnAutoRefresh_Click(object sender, EventArgs e)
		{
			SetAutoRefresh(!timer1.Enabled);
		}

		private void SetAutoRefresh(bool autoRefresh)
		{
			if (autoRefresh)
			{
				ResetData();
				btnAutoRefresh.Image = Resources.Spinner;
				timer1.Enabled = true;
				timer1.Start();
			}
			else
			{
				timer1.Stop();
				timer1.Enabled = false;
				btnAutoRefresh.Image = Resources.Timer;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			MethodInvoker refreshDataActionStart = RefreshData;
			cmbHostNames.BeginInvoke(refreshDataActionStart);
		}

		private void btnSortDir_Click(object sender, EventArgs e)
		{
			_sortAsc = !_sortAsc;
			SetSortDirection(_sortAsc);

			FillGrid(Convert.ToInt32(txtPageNumber.Text), (int)numPageLength.Value);
		}

		private void SetSortDirection(bool sortAsc)
		{
			if (sortAsc)
			{
				btnSortDir.Image = _sortDescBmp;
				toolTip1.SetToolTip(btnSortDir, "Change to Ascending Sort");
			}
			else
			{
				btnSortDir.Image = _sortAscBmp;
				toolTip1.SetToolTip(btnSortDir, "Change to Descending Sort");
			}
			_logViewerData.MRUSortAsc = sortAsc;
		}

		#endregion

		private void btnClearAllAlarms_Click(object sender, EventArgs e)
		{
			RemoveAllUnclearedAlarms();
		}

		private void btAckAllAlarms_Click(object sender, EventArgs e)
		{
			RemoveAllUnAckAlarms();
		}

		#region MouseEnter Events

		//private void lvLogs_MouseEnter(object sender, EventArgs e)
		//{
		//	((ListView)sender).Focus();
		//}

		//private void cmbSeverity_MouseEnter(object sender, EventArgs e)
		//{
		//	((ComboBox)sender).Focus();
		//}

		//private void cmbHostNames_MouseEnter(object sender, EventArgs e)
		//{
		//	((ComboBox)sender).Focus();
		//}

		//private void cmbApplications_MouseEnter(object sender, EventArgs e)
		//{
		//	((ComboBox)sender).Focus();
		//}

		//private void cmbDbConns_MouseEnter(object sender, EventArgs e)
		//{
		//	((ComboBox)sender).Focus();
		//}

		#endregion
	}

	public class LogItem
	{
		public int LogId { get; set; }
		public string LogLevel { get; set; }
		public DateTime LogTimestamp { get; set; }
		public string HostName { get; set; }
		public string AppName { get; set; }
		public string LogSource { get; set; }
		public string CurrentUser { get; set; }
		public string LogMessage { get; set; }
		public string AppSessionId { get; set; }
		public string Thread { get; set; }
		public string TraceId { get; set; }
		public bool HasException { get; set; }
		public string Exception { get; set; }
		public bool ExceptionWasLoaded { get; set; }
	}
}