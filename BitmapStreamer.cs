using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraForms
{
    public static class BitmapStreamer
    {
        public static Bitmap FromBytes(byte[] data)
        {
            if (data.Length < 1) return null;
            using (var s = new MemoryStream(data))
                return new Bitmap(s);
        }
        public static byte[] ToBytes(this Bitmap b)
        {
            if (b == null) return new byte[0];
            using (var s = new MemoryStream())
            {
                b.Save(s, ImageFormat.Png);
                return s.ToArray();
            }
        }

        public static Bitmap ReadBitmap(this BinaryReader r)
        {
            int size = r.ReadInt32();
            if (size < 1) return null;
            return FromBytes(r.ReadBytes(size));
        }
        public static void Write(this BinaryWriter w, Bitmap b)
        {
            if (b == null)
            {
                w.Write(0);
                return;
            }
            var array = b.ToBytes();
            w.Write(array.Length);
            w.Write(array);
        }

        public static Bitmap Read(BinaryReader r)
        {
            int size = r.ReadInt32();
            if (size < 1) return null;
            return FromBytes(r.ReadBytes(size));
        }
        public static void Write(this Bitmap b, BinaryWriter w)
        {
            if (b == null)
            {
                w.Write(0);
                return;
            }
            var array = b.ToBytes();
            w.Write(array.Length);
            w.Write(array);
        }
    }
}
