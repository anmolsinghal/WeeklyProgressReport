namespace WPR.Entities.Models
{
    public class ConfigurationValue
    {
        public int ConfigurationValueId { get; set; }
        public int? ConfigurationId { get; set; }
        public int? ValueId { get; set; }
        public string Value { get; set; }
    
        public virtual Configuration Configuration { get; set; }
    }
}
