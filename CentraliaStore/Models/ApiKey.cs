using CentraliaStore.Areas.Identity;

namespace CentraliaStore.Models
{
    public class ApiKey
    {
        public int ApiKeyId { get; set; }
        public string ApiSecret { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
