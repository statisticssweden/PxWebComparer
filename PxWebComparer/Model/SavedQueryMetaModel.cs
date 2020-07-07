using System;

namespace PxWebComparer.Model
{
    public class SavedQueryMetaModel
    {
        public int QueryId { get; set; }
        public string DataSourceType  { get; set; }
        public string DatabaseId { get; set; }
        public string DataSourceId { get; set; }
        public string Status { get; set; }
        public string StatusUse { get; set; }
        public string StatusChange { get; set; }
        public string OwnerId { get; set; }
        public string MyDescription { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public DateTime UsedDate { get; set; }
        public  DateTime DataSourceUpdateDate { get; set; }
        public string SavedQueryFormat { get; set; }
        public string SavedQueryStorage { get; set; }
        public string QueryText { get; set; }
        public int Runs { get; set; }
        public int  Fails { get; set; }
    }
}
