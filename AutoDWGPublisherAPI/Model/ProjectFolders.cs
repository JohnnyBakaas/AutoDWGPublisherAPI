namespace AutoDWGPublisherAPI.Model
{
    public static class ProjectFolders
    {
        public static List<Folder> Projcts { get; set; }

        public static void Update()
        {
            Projcts = new List<Folder>();
            var folder = new Folder(Common.RootFolderPath, Common.RootFolderName);
            folder.UpdateAll();
        }

        public static string UpdateProject(Folder incomeingFolder)
        {
            Update();
            try
            {
                var foundFolder = Projcts.First(folder => folder.Name == incomeingFolder.Name);
                foundFolder = incomeingFolder;
                return "Mappe oppdatert";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
    }
}
