using System.IO;

namespace Alpha
{
    public static class TerrariaExtensions
    {
        public static (byte r, byte g, byte b) ReadRGB(this BinaryReader reader) =>
            (reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
    }
}
