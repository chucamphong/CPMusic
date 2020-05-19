using Microsoft.AspNetCore.Identity;

namespace CPMusic.Models
{
    public class User : IdentityUser
    {
        [ProtectedPersonalData]
        public string? Avatar { get; set; }
    }
}