namespace AutoDWGPublisherAPI.Model
{
    public class Folder
    {
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public string Status { get; set; }
        public List<Folder> SubFolders { get; set; }
        public List<string> DWGNames { get; set; }
        public bool IsProjectFolder { get; set; }
        private string _projectStringStart = "P-";

        public Folder(string folderPath, string name)
        {
            Name = name;
            FolderPath = folderPath;
            SubFolders = new List<Folder>();
            DWGNames = new List<string>();
            if (_projectStringStart == name.Substring(0, 2)) IsProjectFolder = true;
            Console.WriteLine(name);
            Console.WriteLine(IsProjectFolder);
            // Legg til noe greier som legger det til i en liste hvis det er ett prosjekt
        }

        public void GetSubFolder()
        {
            string[] folders = Directory.GetDirectories($"{FolderPath}\\{Name}");
            foreach (string folder in folders)
            {
                string subFolderName = folder.Substring(folder.LastIndexOf('\\') + 1);
                SubFolders.Add(new Folder($"{FolderPath}\\{Name}", subFolderName));
            }
        }

        public void GetDWGFiles()
        {
            DWGNames = Directory.GetFiles(FolderPath, "*.dwg").ToList();
        }

        public void UpdateAll()
        {
            GetSubFolder();
            GetDWGFiles();
            foreach (Folder folder in SubFolders)
            {
                folder.UpdateAll();
            }
        }
    }
}
