using System.IO;

namespace Alpha.Resources
{
    public struct Resource
    {
        public static readonly Resource Sacrifices = new(true, "Alpha.Resources.Content.Sacrifices.tsv");
        public static readonly Resource ItemNames = new(true, "Alpha.Resources.Content.Items.json");
        public static readonly Resource JourneyCategories = new(true, "Alpha.Resources.Content.JourneyCategories.json");

        public bool ManifestResource;
        public string ResourcePath;

        public Resource(bool manifestResource, string path)
        {
            ManifestResource = manifestResource;
            ResourcePath = path;
        }

        public readonly Stream GetFileStream() =>
            ManifestResource ? GetType().Assembly.GetManifestResourceStream(ResourcePath) : File.OpenRead(ResourcePath);

        public readonly string GetText()
        {            
            using Stream stream = GetFileStream();
            using StreamReader reader = new(stream);
                
            return reader.ReadToEnd();
        }

        public readonly byte[] GetBytes()
        {
            using Stream stream = GetFileStream();
            byte[] bytes = new byte[stream.Length];

            stream.Read(bytes, 0, (int)stream.Length);
            return bytes;
        }
    }
}
