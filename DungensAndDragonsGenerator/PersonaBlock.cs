using DungensAndDragonsGenerator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace DungensAndDragonsGenerator
{

    [Serializable]
    public class PersonaBlock
    {

        public string Name { get; set; }


        //public List<LevelClass> levelClasses = new List<LevelClass>();

        public List<LevelClass> LevelsAndClasses { get; set; }
      
        public string Wheight { get; set; }

        public int WorldWideIndex { get; set; }

        public string Height { get; set; }

        public string Exp { get; set; }

        public string Old { get; set; }

        public string History { get; set; }

        public string Charakter { get; set; }

        public string Weakness { get; set; }

        public string Idials { get; set; }

        public string Affection { get; set; }

        public int RaceNumber { get; set; }

        public int SubRaceNumber { get; set; }

       

        [XmlIgnore]
        public BitmapImage PersonImage
        {


            get
            {
                if (String.IsNullOrEmpty(PersonStringImage))
                {

                    return null;
                }

                return BitmapToImageSource((Bitmap)StrToImg(PersonStringImage));
            }

        }

        public static string ImgToStr(string filename)
        {
            MemoryStream Memostr = new MemoryStream();
            System.Drawing.Image Img = System.Drawing.Image.FromFile(filename);
            Img.Save(Memostr, Img.RawFormat);
            byte[] arrayimg = Memostr.ToArray();
            return Convert.ToBase64String(arrayimg);
        }

        public static System.Drawing.Image StrToImg(string StrImg)
        {
            byte[] arrayimg = Convert.FromBase64String(StrImg);
            System.Drawing.Image imageStr = System.Drawing.Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }

        public string PersonStringImage { get; set; }

        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public static BitmapImage BitmapToImageSourceS(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public PersonaBlock()
        {

        }

    }
}
