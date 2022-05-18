using MQPMTool2.Classes;
using System;
using System.IO;
using System.Xml.Serialization;

namespace MQPMTool2.Static
{
    public static class Globals
    {
        public static PartsList partsList = new PartsList();
        public static OutfitList outfitList = new OutfitList();

        static Globals()
        {
            partsList = ReadList<PartsList>("PartsList.xml");
            outfitList = ReadList<OutfitList>("OutfitList.xml");
        } //constructor

        public static T ReadList<T>(string path)
        {
            T list = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            if(File.Exists(path))
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        list = (T)serializer.Deserialize(stream);
                    } //try
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    } //catch
                    finally
                    {
                        stream.Close();
                    } //finally
                } //using
            } //if

            return list;
        } //ReadPartsList

        public static void WriteList<T>(T list, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                try
                {
                    serializer.Serialize(stream, list);
                } //try
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                } //catch
                finally
                {
                    stream.Close();
                } //finally
            } //using
        } //WritePartsList
    } //class
} //namespace
