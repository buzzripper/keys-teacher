﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KeysTeacher.Data
{
	#region Windows Stuff

	// RECT structure required by WINDOWPLACEMENT structure
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;

		public RECT(int left, int top, int right, int bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}

	// POINT structure required by WINDOWPLACEMENT structure
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;

		public POINT(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	// WINDOWPLACEMENT stores the position, size, and state of a window
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINDOWPLACEMENT
	{
		public int length;
		public int flags;
		public int showCmd;
		public POINT minPosition;
		public POINT maxPosition;
		public RECT normalPosition;
	}

	#endregion

	public class WindowPlacement : IWindowPlacement
	{
		#region Static

		private static readonly Encoding encoding = new UTF8Encoding();
		private static readonly XmlSerializer serializer = new XmlSerializer(typeof(WINDOWPLACEMENT));

		#endregion

		#region Win Imports

		[DllImport("user32.dll")]
		private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

		#endregion

		#region Constants

		private const int SW_SHOWNORMAL = 1;
		private const int SW_SHOWMINIMIZED = 2;

		#endregion

		public void SetPlacement(IntPtr windowHandle, XmlCDataSection cDataSection)
		{
			if (string.IsNullOrEmpty(cDataSection?.Value))
				return;

			byte[] xmlBytes = encoding.GetBytes(cDataSection.Value);

			try {
				WINDOWPLACEMENT placement;
				using (MemoryStream memoryStream = new MemoryStream(xmlBytes)) {
					placement = (WINDOWPLACEMENT)serializer.Deserialize(memoryStream);
				}

				placement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
				placement.flags = 0;
				placement.showCmd = placement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : placement.showCmd;
				SetWindowPlacement(windowHandle, ref placement);
			}
			catch (InvalidOperationException) {
				// Parsing placement XML failed. Fail silently.
			}
		}

		public XmlCDataSection GetPlacementData(IntPtr windowHandle)
		{
			WINDOWPLACEMENT placement;
			GetWindowPlacement(windowHandle, out placement);

			using (MemoryStream memoryStream = new MemoryStream()) {
				using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8)) {
					serializer.Serialize(xmlTextWriter, placement);
					byte[] xmlBytes = memoryStream.ToArray();
					string xml = encoding.GetString(xmlBytes);

					return new XmlDocument().CreateCDataSection(xml);
				}
			}
		}
	}
}