
using System.Text.Json;
using System.Xml.Serialization;

namespace WebSystem.Core
{
    public static class WebSystemGenerics
    {
        public static string JsonSerializedObject<T>(T obj, string? path = null)
        {
            var entity = JsonSerializer.Serialize(obj);

            if(!string.IsNullOrEmpty(path))
            {
                try
                {
                    using StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(entity);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return entity;
        }

        public static T JsonDeserializedObject<T>(string obj, string? path = null)
        {
            var entity = JsonSerializer.Deserialize<T>(obj);

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    using StreamWriter sw = new StreamWriter(path);
                    foreach (var value in entity!.GetType().GetProperties())
                    {
                        sw.WriteLine($"{value.Name} - {value.GetValue(entity)}");
                    }
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                }
            }
            return entity!;
        }

        public static void XmlSerializedObject<T>(T obj, string path)
        {
            var xml = new XmlSerializer(typeof(T));

            try
            {
              using StreamWriter sw = new StreamWriter(path);
              xml.Serialize(sw,obj);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
        }

        public static T? XmlDeserializedObject<T>(string path, bool showValues = false)
        {
            var xml = new XmlSerializer(typeof(T));

             try
             {
               using StreamReader sw = new StreamReader(path);
               var entity = xml.Deserialize(sw);

                if (showValues)
                {
                    foreach (var value in entity!.GetType().GetProperties())
                    {
                       Console.WriteLine($"Name: {value.Name} | Value: {value.GetValue(entity)}");
                    }
                }

               return (T)entity!;
             }
             catch (Exception ex)
             {
               Console.WriteLine(ex.Message);
             }
            return default;
        }
    } 
}