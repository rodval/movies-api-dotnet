using System;
using Newtonsoft.Json;

namespace MovieAPI.UnitTest
{
    public class StreamReaderJSON<T>
    {
        public List<T> Get(string path)
        {
            try
            {
                using StreamReader jsonStream = File.OpenText(path);
                var json = jsonStream.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<T>>(json);
                return data.Count > 0 ? data : new List<T>();
            }
            catch
            {
                throw new Exception("could not find or read the requested resource.");
            }
        }
    }
}

