using System;

namespace CPMusic.ViewModels
{
    public class UserViewModel
    {
        private Guid _id;

        public string Id
        {
            get => _id.ToString();
            set => _id = Guid.Parse(value);
        }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Avatar { get; set; }
    }
}
