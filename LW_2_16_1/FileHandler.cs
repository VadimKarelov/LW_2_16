using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LW_2_16_1
{
    internal class FileHandler : IDisposable
    {
        public void WriteBinary<T>(string path, MyNewStack<T> collection)
        {
            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(writer, collection);
            }
        }

        public void WriteJSON<T>(string path, MyNewStack<T> collection)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                string json = "[";
                foreach (var item in collection)
                {
                    json += JsonSerializer.Serialize(item, item.GetType(), new JsonSerializerOptions() { WriteIndented = true })+",";
                }
                json = json.Remove(json.Length - 1, 1);
                json += "]";
                writer.Write(json);
                
            }
        }

        public void WriteXML<T>(string path, MyNewStack<T> collection)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyNewStack<T>));

            using (FileStream writer = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, collection);
            }
        }

        public MyNewStack<Organization> ReadFile<T>(string path)
        {
            if (TryReadBinary(path, out MyNewStack<T> coll1))
            {
                return coll1 as MyNewStack<Organization>;
            }
            if (TryReadJSON(path, out MyNewStack<Organization> coll2))
            {
                return coll2 as MyNewStack<Organization>;
            }
            if (TryReadXML(path, out MyNewStack<Organization> coll3))
            {
                return coll3;
            }
            
            throw new FileLoadException("Не удалось открыть файл");
        }

        private bool TryReadBinary<T>(string path, out MyNewStack<T> collection)
        {
            collection = new MyNewStack<T>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    collection = (MyNewStack<T>)bf.Deserialize(fs);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool TryReadJSON(string path, out MyNewStack<Organization> collection)
        {
            collection = new MyNewStack<Organization>();

            try
            {
                using (StreamReader fs = new StreamReader(path))
                {
                    collection = JsonSerializer.Deserialize<Organization[]>(fs.ReadToEnd()).ToMyNewStack();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool TryReadXML(string path, out MyNewStack<Organization> collection)
        {
            collection = new MyNewStack<Organization>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization[]));
                    collection = (xmlSerializer.Deserialize(fs) as Organization[]).ToMyNewStack();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
