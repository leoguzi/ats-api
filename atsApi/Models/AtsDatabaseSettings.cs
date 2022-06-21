namespace atsApi.Models
{
    public class AtsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;

        public string PositionsCollectionName { get; set; } = null;
    }
}
