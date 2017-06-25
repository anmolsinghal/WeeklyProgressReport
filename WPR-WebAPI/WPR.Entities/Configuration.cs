namespace WPR.Entities.Models
{
    using System.Collections.Generic;

    public class Configuration
    {
        public Configuration()
        {
            ConfigurationValues = new HashSet<ConfigurationValue>();
        }
    
        public int ConfigurationId { get; set; }
        public string Name { get; set; }
   
        public virtual ICollection<ConfigurationValue> ConfigurationValues { get; set; }
    }
}
