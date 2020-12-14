using loginAssignment.Model.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace loginAssignment.Model.DataManager
{
    public class UserManager: IDataRepository<UserModel>
    {
        readonly UserContext _employeeContext;

        public UserManager(UserContext context)
        {
            _employeeContext = context;

        }
        //MAke a Token
        public UserModel Authenticate(string username, string password)
        {
            var user = _employeeContext.Users.SingleOrDefault(x => x.Email == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fsgfdhgsgfwfj23h23hhsdhaavdk");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var toke = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            var employee = new UserModel { Token = toke };
            return employee;
        }

        public List<UserModel> GetAll()
        {
            return _employeeContext.Users.ToList();
        }

        public UserModel Get(long id)
        {
            return _employeeContext.Users
                  .FirstOrDefault(e => e.UserId == id);
        }

        public void Add(UserModel entity)
        {
            _employeeContext.Users.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(UserModel UserModel, UserModel entity)
        {
            UserModel.FirstName = entity.FirstName;
            UserModel.LastName = entity.LastName;
            UserModel.Email = entity.Email;
            UserModel.Password = entity.Password;
            

            _employeeContext.SaveChanges();
        }

        public void Delete(UserModel user)
        {
            _employeeContext.Users.Remove(user);
           
            _employeeContext.SaveChanges();
        }
    }
}
