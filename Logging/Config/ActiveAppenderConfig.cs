﻿using System.Collections.Generic;
using System.Configuration;

namespace ProDataMedia.Logging.Config
{
	public class ActiveAppenderConfig : ConfigurationElement
	{
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name => (string) this["name"];
	}

	#region Collection class

	public class ActiveAppenderConfigCollection : ConfigurationElementCollection, IEnumerable<ActiveAppenderConfig>
	{
		private readonly List<ActiveAppenderConfig> _elements;

		public ActiveAppenderConfigCollection()
		{
			_elements = new List<ActiveAppenderConfig>();
		}

		public new IEnumerator<ActiveAppenderConfig> GetEnumerator()
		{
			return _elements.GetEnumerator();
		}

		protected override ConfigurationElement CreateNewElement()
		{
			var element = new ActiveAppenderConfig();
			_elements.Add(element);

			return element;
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ActiveAppenderConfig) element).Name;
		}
	}

	#endregion
}