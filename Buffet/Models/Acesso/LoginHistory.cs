using System;
using System.ComponentModel.DataAnnotations.Schema;
using Buffet.Views.Inner;

namespace Buffet.Models.Acesso
{
    public class LoginHistory
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public Usuario User { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}