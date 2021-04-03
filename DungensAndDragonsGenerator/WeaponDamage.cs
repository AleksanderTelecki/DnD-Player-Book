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
    public class WeaponDamage
    {

        public string Naming { get; set; }
        public string Damage { get; set; }
        public string Distance { get; set; }
        public string Descripto { get; set; }
        public string Bonus { get; set; }
        public string Type { get; set; }

        public int DamageIndex { get; set; }

        [XmlIgnore]
        public BitmapImage PersonImage
        {


            get
            {
                if (String.IsNullOrEmpty(WeaponStringImage))
                {

                    return null;
                }

                return BitmapToImageSource((Bitmap)StrToImg(WeaponStringImage));
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

        public string WeaponStringImage { get; set; }

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

        public WeaponDamage(string name, string damage, string distanc, string descripto, string bonus, string type,int init,string image)
        {

            Naming = name;
            Damage = damage;
            Distance = distanc;
            Descripto = descripto;
            Bonus = bonus;
            Type = type;
            DamageIndex = init;
            WeaponStringImage = image;


        }






        public WeaponDamage()
        {

        }

    }
}
