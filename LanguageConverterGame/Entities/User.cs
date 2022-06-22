using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageConverterGame.Entities
{
    [Table("UserLogin")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get ; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
