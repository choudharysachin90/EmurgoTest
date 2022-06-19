using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestFrameworkSetup.DataReader
{
	/// <summary>
	/// EmurgoSchema - Class which convert XML to c# object to read testadata from xml file
	/// </summary>
	public class EmurgoSchema
	{
		[XmlRoot(ElementName = "parameter")]
		public class Parameter
		{
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "TestData")]
		public class TestData
		{
			[XmlElement(ElementName = "parameter")]
			public List<Parameter> Parameter { get; set; }
		}

		[XmlRoot(ElementName = "Emurgo")]
		public class Emurgo
		{
			[XmlElement(ElementName = "TestData")]
			public List<TestData> TestData { get; set; }
		}
	}
}
