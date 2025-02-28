namespace RetailApi.Models
{
    public class MasterData
    {
        public int ID { get; set; }
        public string CODE { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class MasterDataResponse
    {
        public int flag { get; set; }
        public string message { get; set; }
        public List<MasterData> Department { get; set; }
        public List<MasterData> Category { get; set; }
        public List<MasterData> SubCategory { get; set; }
        public List<MasterData> Brand { get; set; }
        public List<MasterData> Supplier { get; set; }
    }
    public class MasterFilter
    {
        public string MASTER_TYPE { get; set; }
        public string MASTER_VALUE { get; set; }
    }
}
