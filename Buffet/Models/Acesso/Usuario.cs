using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Buffet.Models.Acesso
{
    public class Usuario : IdentityUser<Guid>
    {
        public List<LoginHistory> LoginHistories { get; set; }
    }
}