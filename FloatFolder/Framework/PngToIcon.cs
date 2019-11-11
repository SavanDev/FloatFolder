// thanks to Ruiwei Bu/darkfall
// https://gist.github.com/darkfall/1656050

using System.Drawing;
using System.IO;

namespace FloatFolder
{
    public static class PngToIcon
    {
        /// <summary>
        /// convert .png to .ico
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool Convert(Stream input, Stream output)
        {
            int size = 256;
            Bitmap input_bit = (Bitmap)Image.FromStream(input);
            if (input_bit != null)
            {
                int width, height;
                width = size;
                height = input_bit.Height / input_bit.Width * size;

                Bitmap image_bit = new Bitmap(input_bit, new Size(width, height));
                if (image_bit != null)
                {
                    // save png to a memory stream
                    MemoryStream memory_stream = new MemoryStream();
                    image_bit.Save(memory_stream, System.Drawing.Imaging.ImageFormat.Png);

                    BinaryWriter icon_binary = new BinaryWriter(output);
                    if (output != null && icon_binary != null)
                    {
                        icon_binary.Write((byte)0);
                        icon_binary.Write((byte)0);
                        icon_binary.Write((short)1);
                        icon_binary.Write((short)1);
                        icon_binary.Write((byte)width);
                        icon_binary.Write((byte)height);
                        icon_binary.Write((byte)0);
                        icon_binary.Write((byte)0);
                        icon_binary.Write((short)0);
                        icon_binary.Write((short)32);
                        icon_binary.Write((int)memory_stream.Length);
                        icon_binary.Write((int)(6 + 16));
                        // write memory stream
                        icon_binary.Write(memory_stream.ToArray());
                        // flush and icon_binary will equal null
                        icon_binary.Flush();
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// run convert, close streams
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool Convert(string input, string output)
        {
            FileStream input_file_stream = new FileStream(input, FileMode.Open);
            FileStream output_file_stream = new FileStream(output, FileMode.OpenOrCreate);
            bool is_converted = Convert(input_file_stream, output_file_stream);
            input_file_stream.Close();
            output_file_stream.Close();
            return is_converted;
        }
    }
}