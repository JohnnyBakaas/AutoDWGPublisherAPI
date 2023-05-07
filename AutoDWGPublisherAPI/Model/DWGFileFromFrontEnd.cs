namespace AutoDWGPublisherAPI.Model
{
    public class DWGFileFromFrontEnd
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string FolderPath { get; set; }
        public string Author { get; set; }
        public bool ToBePublished { get; set; }

        public DWGFileFromFrontEnd(string name, string status, string folderPath, string author, bool toBePublished)
        {
            Name = name;
            Status = status;
            FolderPath = folderPath;
            Author = author;
            ToBePublished = toBePublished;
        }

        public Task<string> Publish()
        {
            if (ToBePublished)
            {
                var ADP = new AutoDWGPublisher();
                return ADP.PublishFile($"{FolderPath}\\{Name}");
            }

            return Common.StringToActionString($"{Name} kunne ikke printes");
        }
    }
}
