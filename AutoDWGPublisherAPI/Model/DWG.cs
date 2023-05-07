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
            Console.WriteLine(Common.PathToName(name) + " DWG CTOR");
            try
            {
                var matchingFromDB = DB.DWGs.First(d => d.Name == Common.PathToName(name));
                Name = Common.PathToName(name);
                FolderPath = folderPath;
                Status = matchingFromDB.Status;
                Author = matchingFromDB.Author;
                RevDate = GetLastModifiedDate();
            }
            catch
            {
                Name = Common.PathToName(name);
                FolderPath = folderPath;
                Status = "Ikke funnet i DB"; // Hent info fra DB
                Author = "Ikke funnet i DB"; // Hent info fra DB
                RevDate = GetLastModifiedDate();
            }
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
