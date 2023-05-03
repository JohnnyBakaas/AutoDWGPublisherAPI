namespace AutoDWGPublisherAPI.Model
{
    public static class Common
    {
        public static string RootFolderPath = "C:";
        public static string RootFolderName = "Test for Autocad greier";


        public static string PathToName(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        public static bool IsProjectFolder(string name)
        {
            string prefix = "P-";
            if (name.Substring(0, 2) == prefix)
            {
                return true;
            }
            return false;
        }
    }
}
