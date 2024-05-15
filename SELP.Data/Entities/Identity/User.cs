using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using SELP.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities.Identity
{
    public class User: IdentityUser
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EncryptColumn]
        public string? ResetCode { get; set; }



        [InverseProperty("user")]
        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
