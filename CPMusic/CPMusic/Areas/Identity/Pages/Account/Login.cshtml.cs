using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CPMusic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

// ReSharper disable ClassNeverInstantiated.Global

namespace CPMusic.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public string? ReturnUrl { get; private set; }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [TempData]
        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Required")]
            [Display(Name = "Tài khoản")]
            [StringLength(30, MinimumLength = 6, ErrorMessage = "StringLength")]
            public string? UserName { get; set; }

            [Required(ErrorMessage = "Required")]
            [Display(Name = "Mật khẩu")]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Display(Name = "Ghi nhớ đăng nhập?")]
            public bool RememberMe { get; set; }
        }

        /// <summary>
        /// Trang đăng nhập
        /// </summary>
        /// ReSharper disable once UnusedMember.Global
        public async Task<IActionResult> OnGetAsync(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            // Nếu đã đăng nhập rồi thì chuyển về trang chủ
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect(ReturnUrl);
            }
            
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Page();
        }

        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        /// ReSharper disable once UnusedMember.Global
        public async Task<IActionResult> OnPostAsync(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Muốn bật tính năng khóa tài khoản khi đăng nhập sai quá nhiều lần thì đặt lockoutOnFailure thành true
            SignInResult result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, false);

            // Đăng nhập thành công
            if (result.Succeeded)
            {
                return LocalRedirect(ReturnUrl);
            }

            // Chuyển sang trang LoginWith2fa vì yêu cầu xác thực hai bước
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl, Input.RememberMe });
            }

            // Tài khoản đã bị khóa
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }

            // Tài khoản hoặc mật khẩu không đúng
            ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không đúng.");

            return Page();
        }
    }
}