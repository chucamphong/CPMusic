﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// ReSharper disable ClassNeverInstantiated.Global

namespace CPMusic.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public string? ReturnUrl { get; private set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Required")]
            [Display(Name = "Tài khoản")]
            public string? UserName { get; set; }

            [Required(ErrorMessage = "Required")]
            [EmailAddress(ErrorMessage = "EmailAddress")]
            [Display(Name = "Địa chỉ email")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Required")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "StringLength")]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Required")]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu nhập lại")]
            [Compare("Password", ErrorMessage = "ComparePassword")]
            public string? ConfirmPassword { get; set; }
        }

        /// <summary>
        /// Trang đăng ký
        /// </summary>
        /// ReSharper disable once UnusedMember.Global
        public IActionResult OnGetAsync(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            // Nếu đã đăng nhập thì chuyển trang, không được truy cập
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect(ReturnUrl);
            }

            // Trang đăng ký
            return Page();
        }

        /// <summary>
        /// Xử lý đăng ký
        /// </summary>
        /// ReSharper disable once UnusedMember.Global
        public async Task<IActionResult> OnPostAsync(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            // ReSharper disable once InvertIf
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser {UserName = Input.UserName, Email = Input.Email};
                IdentityResult result = await _userManager.CreateAsync(user, Input.Password);

                // Tạo tài khoản thành công thì đăng nhập
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect(ReturnUrl);
                }
                
                // Tạo tài khoản thất bại
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}