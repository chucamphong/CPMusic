using Microsoft.AspNetCore.Identity;

namespace CPMusic.Helpers
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"Tài khoản {userName} đã tồn tại"
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = "Tài khoản chỉ có thể chứa chữ hoặc số"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"Địa chỉ {email} đã tồn tại"
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof (InvalidEmail),
                Description = $"Địa chỉ {email} không hợp lệ"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Mật khẩu phải có ít nhất một chữ viết thường"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Mật khẩu phải có ít nhất một chữ viết hoa"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Mật khẩu phải có ít nhất một số"
            };
        }
    }
}
