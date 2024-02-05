using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class LogInfo
    {
        [Key]
        public int Id { get; set; }
        public string Query { get; set; }

        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }

        // Navigation property to represent the relationship
        public UserInfo UserInfo { get; set; }
    }
}
