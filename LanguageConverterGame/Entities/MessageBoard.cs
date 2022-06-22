using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace LanguageConverterGame.Entities
{
    public class MessageBoard
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Message { get; set; }

        [StringLength(250)]
        public string TranslatedMessage { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }

    }
}
