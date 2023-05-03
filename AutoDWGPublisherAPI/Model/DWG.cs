namespace AutoDWGPublisherAPI.Model
{
    public class DWG
    {
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
        public DateTime RevDate { get; set; }

        public DWG(string name, string folderPath)
        {
            Name = Common.PathToName(name);
            FolderPath = folderPath;
            Status = "Ikke implimentert"; // Hent info fra DB
            Author = "Ikke implimentert"; // Hent info fra DB
            RevDate = GetLastModifiedDate();
        }

        private DateTime GetLastModifiedDate()
        {
            string filePath = Path.Combine(FolderPath, Name);

            if (File.Exists(filePath))
            {
                return File.GetLastWriteTime(filePath);
            }
            else
            {
                throw new FileNotFoundException($"File {filePath} not found.");
            }
        }
    }
}
