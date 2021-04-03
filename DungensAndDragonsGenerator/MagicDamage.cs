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
   public class MagicDamage
    {

       public string Naming { get; set; }

        public string BaseChar { get; set; }

        public string SavePower { get; set; }

        public string MagicDamageBonus { get; set; }

        public string Opis { get; set; }

        public string distance { get; set; }

        [XmlIgnore]
        public BitmapImage PersonImage
        {


            get
            {
                if (String.IsNullOrEmpty(MageStringImage))
                {

                    return null;
                }

                return BitmapToImageSource((Bitmap)StrToImg(MageStringImage));
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

        public string MageStringImage { get; set; }

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


        public MagicDamage(string naming,string basechar,string savepo,string magicbasicdam,string opis,string dist,string image)
        {

            Naming = naming;
            BaseChar = basechar;
            SavePower = savepo;
            MagicDamageBonus = magicbasicdam;
            Opis = opis;
            distance = dist;
            MageStringImage = image;






        }

        public MagicDamage()
        {

        }



    }
}
