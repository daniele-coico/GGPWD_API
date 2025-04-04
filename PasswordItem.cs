using System.Data.SqlTypes;
using System.Text;

namespace GGPWD_API
{
    public class PasswordItem ()
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string? Username { get; set; }
        public string? Hash { get; set; }
    }
}
