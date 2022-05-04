/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "class")]
    public class Class
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "super")]
        public string Super { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "classes")]
    public class Classes
    {
        [XmlElement(ElementName = "class")]
        public List<Class> Class { get; set; }
    }

    [XmlRoot(ElementName = "property")]
    public class Property
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "container")]
        public string Container { get; set; }
        [XmlAttribute(AttributeName = "arraySize")]
        public string ArraySize { get; set; }
        [XmlElement(ElementName = "value")]
        public List<Value> Value { get; set; }
    }

    [XmlRoot(ElementName = "value")]
    public class Value
    {
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "packagePath")]
        public string PackagePath { get; set; }
        [XmlAttribute(AttributeName = "archivePath")]
        public string ArchivePath { get; set; }
        [XmlAttribute(AttributeName = "nameInArchive")]
        public string NameInArchive { get; set; }
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "z")]
        public string Z { get; set; }
        [XmlAttribute(AttributeName = "w")]
        public string W { get; set; }
    }

    [XmlRoot(ElementName = "staticProperties")]
    public class StaticProperties
    {
        [XmlElement(ElementName = "property")]
        public List<Property> Property { get; set; }
    }

    [XmlRoot(ElementName = "entity")]
    public class Entity
    {
        [XmlElement(ElementName = "staticProperties")]
        public StaticProperties StaticProperties { get; set; }
        [XmlElement(ElementName = "dynamicProperties")]
        public string DynamicProperties { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlAttribute(AttributeName = "classVersion")]
        public string ClassVersion { get; set; }
        [XmlAttribute(AttributeName = "addr")]
        public string Addr { get; set; }
        [XmlAttribute(AttributeName = "unknown1")]
        public string Unknown1 { get; set; }
        [XmlAttribute(AttributeName = "unknown2")]
        public string Unknown2 { get; set; }
    }

    [XmlRoot(ElementName = "entities")]
    public class Entities
    {
        [XmlElement(ElementName = "entity")]
        public List<Entity> Entity { get; set; }
    }

    [XmlRoot(ElementName = "fox")]
    public class Fox
    {
        [XmlElement(ElementName = "classes")]
        public Classes Classes { get; set; }
        [XmlElement(ElementName = "entities")]
        public Entities Entities { get; set; }
        [XmlAttribute(AttributeName = "formatVersion")]
        public string FormatVersion { get; set; }
        [XmlAttribute(AttributeName = "fileVersion")]
        public string FileVersion { get; set; }
        [XmlAttribute(AttributeName = "originalVersion")]
        public string OriginalVersion { get; set; }
    }

}
