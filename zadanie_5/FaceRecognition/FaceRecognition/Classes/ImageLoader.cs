using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace FaceRecognition.Classes
{
    static class ImageLoader
    {
        public static Bitmap GetImage(int faceNumber, int imageNumber)
        {
            string path = "Tvare/Osoba" + faceNumber + "/" + imageNumber + ".png";
            return new Bitmap(path);
        }
    }
}
