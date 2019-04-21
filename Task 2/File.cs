using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_2
{
    [Serializable()]
    [XmlRoot(ElementName = "File")]
    [Table(Name = "Files")]
    public class File
    {
        [XmlIgnore]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "FileVersion")]
        [Column]
        public string FileVersion { get; set; }

        [XmlElement(ElementName = "Name")]
        [Column]
        public string Name { get; set; }

        [XmlElement(ElementName = "DateTime")]
        [Column]
        public DateTime DateTime { get; set; }
    }

    [Serializable()]
    [XmlRoot("FilesCollection")]
    public class FilesCollection
    {
        [XmlArray("Files")]
        [XmlArrayItem("File", typeof(File))]
        public File[] Files { get; set; }
    }
}
