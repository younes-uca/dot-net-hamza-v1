using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Project_Spring_to_.net.Data;
using Project_Spring_to_.net.Zynerator.Business.Contracts;
using Project_Spring_to_.net.Zynerator.Models;
using Project_Spring_to_.net.Zynerator.Models.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Project_Spring_to_.net.Zynerator.Business.Impls
{
    public class UserService: IUserService
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper,IConfiguration configuration )
        {
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }
        public UserDto Register(UserDto user)
        {
            string passwordHash=BCrypt.Net.BCrypt.HashPassword(user.Password);
            var newUser=_mapper.Map<User>(user);
            newUser.PasswordHash = passwordHash;
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return _mapper.Map<UserDto>(newUser);
        }
        public string Login(UserDto user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);

            if (existingUser is null)
            {
                throw new ApplicationException("User does not exist.");
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, existingUser.PasswordHash))
            {
                throw new AuthenticationException("Incorrect password.");
            }
            string token = CreateToken(existingUser);
            return token;

        }
        private string CreateToken(User user)
        {
            List<Claim> claims= new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token =new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:creds
                ) ;

            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
