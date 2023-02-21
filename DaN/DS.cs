using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DaN
{
    internal class DS
    {
        public static T Des<T>()
        {
            string json = File.ReadAllText("C:\\Users\\Anna\\Documents\\МПТ\\4 семестр\\ОАИП Скорогудаева\\DaN\\MyJson.json", Encoding.UTF8);
            T notes = JsonConvert.DeserializeObject<T>(json);
            return notes;
        }

        public void Ser<T>(T notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C:\\Users\\Anna\\Documents\\МПТ\\4 семестр\\ОАИП Скорогудаева\\DaN\\MyJson.json", json, Encoding.UTF8);
        }
    }
}
