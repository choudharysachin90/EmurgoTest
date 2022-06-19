using System.IO;

namespace TestFrameworkSetup.DataReader
{
    /// <summary>
    /// TestDataReader - Class that read xml file and convert that to any given schema
    /// </summary>
    class TestDataReader
    {
        /// <summary>
        /// DeserializeToObject - Generic function which will convert 
        /// your xml to any given Schema
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public T DeserializeToObject<T>(string filepath) where T : class
        {
            System.Xml.Serialization.XmlSerializer emurgoXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)emurgoXmlSerializer.Deserialize(sr);
            }
        }
    }
}
