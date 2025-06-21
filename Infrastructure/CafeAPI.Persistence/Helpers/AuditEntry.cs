namespace CafeAPI.Persistence.Helpers
{
    public class AuditEntry
    {
        public string TableName { get; set; }
        public string Action { get; set; }
        public string User { get; set; }
        public string IP { get; set; }
        public DateTime Time { get; set; }

        public Dictionary<string, object> OldValues { get; set; } = new();
        public Dictionary<string, object> NewValues { get; set; } = new();
    }

}
