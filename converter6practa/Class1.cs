using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practic_6
{
    public class figure
    {
        public string name;
        public int width;
        public int height;
        public figure()
        {

        }
        public figure(string Name, int Height, int Width)
        {
            name=Name;
            height=Height;
            width=Width;
        }
    }
    public class Preobrazovanie
    {
        private static List<figure> ConvertToObject(string file)
        {
            List<figure> figures = new List<figure>();
            if (file.Contains(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<figure>));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    figures = (List<figure>)xml.Deserialize(fs);
                }
            }
            if (file.Contains(".json"))
            {
                figures = JsonConvert.DeserializeObject<List<figure>>(File.ReadAllText(file));
            }

            if (file.Contains(".txt"))
            {
                string[] linii = File.ReadAllLines(file);
                for (int i = 0; i < linii.GetLength(0); i = i + 3)
                {
                    figure figure = new figure();
                    if (i != linii.GetLength(0))
                    {
                        figure.name = linii[i];
                    }
                    else break;
                    if (i + 1 != linii.GetLength(0))
                    {
                        figure.width = Convert.ToInt32(linii[i + 1]);

                    }
                    else break;
                    if (i + 2 != linii.GetLength(0))
                    {
                        figure.height = Convert.ToInt32(linii[i + 2]);
                    }
                    else break;
                    figures.Add(figure);
                }
            }
            return figures;
        }
        public static string ConvertToText(string file)
        {
            string text = "";
            List<figure> figures = ConvertToObject(file);
            for (int i = 0; i < figures.Count(); i++)
            {
                text = text + figures[i].name + "\n";
                text = text + figures[i].height + "\n";
                text = text + figures[i].width + "\n";
            }
            return text;
        }
        public static void SaveFile(string oldFile, string newFile)
        {
            List<figure> figures = ConvertToObject(oldFile);
            if (newFile.Contains(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<figure>));
                using (FileStream fs = new FileStream(newFile, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, figures);
                }
            }
            if (newFile.Contains(".json"))
            {
                File.WriteAllText(newFile, JsonConvert.SerializeObject(figures));
            }
            if (newFile.Contains(".txt"))
            {
                File.WriteAllText(newFile, ConvertToText(newFile));
            }
        }
    }
}
