using System;
using Microsoft.AspNetCore.Identity;

namespace CPMusic.Models
{
    /// <summary>
    /// Bảng chức vụ
    /// </summary>
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
            Id = Guid.NewGuid();
        }

        public Role(string name) : this()
        {
            Name = name;
        }

        public Role(string name, string normalizedName) : this(name)
        {
            NormalizedName = normalizedName;
        }
    }
}
