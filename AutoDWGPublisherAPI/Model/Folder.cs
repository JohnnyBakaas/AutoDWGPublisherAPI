namespace AutoDWGPublisherAPI.Model
{
    public class Folder
    {
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public string Status { get; set; }
        public List<Folder> SubFolders { get; set; }
        public List<DWG> DWGs { get; set; }
        public bool IsProjectFolder { get; set; }

        public Folder(string folderPath, string name)
        {
            Name = name;
            FolderPath = folderPath;
            SubFolders = new List<Folder>();
            DWGs = new List<DWG>();

            Status = string.Empty;

            IsProjectFolder = Common.IsProjectFolder(name);

            GetDWGFiles();
            GetSubFolder();
        }

        public void GetSubFolder()
        {
            string[] folders = Directory.GetDirectories($"{FolderPath}\\{Name}");
            foreach (string folder in folders)
            {
                string subFolderName = Common.PathToName(folder);
                SubFolders.Add(new Folder($"{FolderPath}\\{Name}", subFolderName));
            }
        }

        public void GetDWGFiles()
        {
            var DWGNames = Directory.GetFiles($"{FolderPath}\\{Name}", "*.dwg");
            Console.WriteLine("It is DWGs we are looking for");
            foreach (string dwgName in DWGNames)
            {
                Console.WriteLine(dwgName);

                DWGs.Add(new DWG(dwgName, $"{FolderPath}\\{Name}"));
            }
        }

        public void UpdateAll()
        {
            foreach (Folder folder in SubFolders)
            {
                folder.UpdateAll();
                if (folder.IsProjectFolder) ProjectFolders.Projcts.Add(folder);
            }
        }
    }
}
