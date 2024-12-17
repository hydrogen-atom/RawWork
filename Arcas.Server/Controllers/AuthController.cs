using System.Linq;
using sqlTest.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sqlTest.Server.Data;

namespace sqlTest.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ArcasDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ArcasDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 检查用户名是否已存在
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (existingUser != null)
            {
                return BadRequest(new { message = "账号已存在。" });
            }

            // 创建新用户（不使用密码哈希）
            var user = new User
            {
                Username = model.Username,
                Nickname = model.Nickname,
                Password = model.Password // 直接保存明文密码（不推荐用于生产环境）
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "用户注册成功。" });
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 查找用户
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (user == null || user.Password != model.Password) // 比对明文密码
            {
                return Unauthorized(new { message = "账号或密码错误。" });
            }

            return Ok(new { message = "登录成功。" });
        }
    }
}
