using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungensAndDragonsGenerator
{
    public static class FileManager
    {

        public static void Serialize(Player player)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON-File | *.json";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == true)
            {
                string FilePath = saveFileDialog.FileName;
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    JsonWriter jsonWriter = new JsonTextWriter(sw);
                    jsonSerializer.Serialize(jsonWriter, player);
                }
            }
        }

        public static Player Desirialize()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON-File | *.json";

            if (openFileDialog.ShowDialog() == true)
            {

                string FilePath = openFileDialog.FileName;
                JObject jObject = null;
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamReader sw = new StreamReader(FilePath))
                {
                    JsonReader jsonReader = new JsonTextReader(sw);
                    jObject = jsonSerializer.Deserialize(jsonReader) as JObject;

                }

                return jObject.ToObject<Player>();
            }

            return new Player();
        }
    }
}
