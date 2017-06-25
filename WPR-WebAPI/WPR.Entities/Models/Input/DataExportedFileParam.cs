using System.Text;

namespace WPR.Entities.Models.Input
{
    public class DataExportedFileParam
    {
        public string UserName { get; set; }
        public bool IsInternal { get; set; }
        public string[] ClientIds { get; set; }
        public string[] MatterIds { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("UserName = {0},", this.UserName))
                .AppendLine(string.Format("IsInternal = {0},", this.IsInternal))
                .AppendLine(string.Format("Clients (count) = {0},", this.ClientIds == null ? 0 : this.ClientIds.Length))
                .AppendLine(string.Format("Matters (count) = {0},", this.MatterIds == null ? 0 : this.MatterIds.Length));
            return sb.ToString();
        }
    }
}
