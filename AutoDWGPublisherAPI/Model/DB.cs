using AutoDWGPublisherAPI.Model.TempDB;

namespace AutoDWGPublisherAPI.Model
{
    public static class DB
    {
        public static List<DWGFromDB> DWGs { get; set; }

        public static void StartUp()
        {
            DWGs = new List<DWGFromDB>();
            AddMockData();
        }

        private static void AddMockData()
        {
            ProjectFolders.Update();
            foreach (var projectFolder in ProjectFolders.Projcts)
            {
                foreach (var dwg in projectFolder.DWGs)
                {
                    Console.WriteLine(dwg.Name + " Hei");
                    DWGs.Add(new DWGFromDB(dwg.Name, "Under prosjektering", "Johnny Bakaas"));
                }
            }
        }

        public static string UpdateDWG(DWGFileFromFrontEnd dwg)
        {
            try
            {
                var foundDWG = DWGs.First(e => e.Name == dwg.Name);
                foundDWG.Author = dwg.Author;
                foundDWG.Status = dwg.Status;
                return $"{foundDWG.Name} sucsesfully updated";
            }
            catch
            {
                return "File not found";
            }
        }
    }
}
