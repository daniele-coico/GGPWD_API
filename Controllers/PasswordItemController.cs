using Microsoft.AspNetCore.Mvc;

namespace GGPWD_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordItemController : ControllerBase
    {
        private readonly ILogger<PasswordItemController> _logger;
        private readonly PasswordHasher _passwordUtility;

        public PasswordItemController(ILogger<PasswordItemController> logger, PasswordHasher passwordUtility)
        {
            _logger = logger;
            _passwordUtility = passwordUtility;
        }

        [HttpGet(Name = "GetHash")]
        public PasswordItem Get(string? username, string plainText)
        {
            string hashedPassword = _passwordUtility.Encrypt(plainText);
            _logger.LogDebug($"Hashed password: {hashedPassword}");

            PasswordItem passwordItem = new PasswordItem
            {
                Username = username ?? "Default",
                Hash = hashedPassword
            };

            return passwordItem;
        }

        [HttpPost(Name = "Hash")]
        public IActionResult Post([FromBody] InputRequest request)
        {
            if (string.IsNullOrEmpty(request.Password))
            {
                _logger.LogDebug("A request has been denied. Reason: password is null or empty");
                return BadRequest("Password is required!");
            }

            string hashedPassword = _passwordUtility.Encrypt(request.Password);
            _logger.LogDebug($"Hashed password: {hashedPassword}");

            PasswordItem passwordItem = new PasswordItem
            {
                Username = request.Username ?? "Default",
                Hash = hashedPassword
            };

            return Ok(passwordItem);
        }
    }

    public class InputRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

