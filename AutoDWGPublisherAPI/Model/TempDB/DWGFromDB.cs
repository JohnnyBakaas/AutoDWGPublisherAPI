namespace AutoDWGPublisherAPI.Model.TempDB
{
    public class DWGFromDB
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }

        public DWGFromDB(string name, string status, string author)
        {
            Name = name;
            Status = status;
            Author = author;
        }
    }
}
