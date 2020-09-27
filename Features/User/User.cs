using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS201_WebApi.Infra.Database;

namespace CS201_WebApi.Features.User
{
    [Table("Users")]
    public class User : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}