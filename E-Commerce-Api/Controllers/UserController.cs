using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Api.Data;
using E_Commerce_Api.Data.Entities;
using E_Commerce_Api.Models.UserModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }




        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserModel>>> GetUsers()
        {
            var users = new List<GetUserModel>();

            foreach (var user in await _context.Users.Include(x => x.Adress).ToListAsync())
                users.Add(new GetUserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AddressLine = user.Adress.AddressLine,
                    ZipCode = user.Adress.ZipCode,
                    City = user.Adress.City
                });

            return users;
           

        }








        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }




        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserModel(CreateUserModel model)
        {
            var _user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
            
            string PasseordError;

            var PasswordValidate = ValidatePassword(model.password,out PasseordError);
           
            if (_user == null )
            {
                if(IsValidEmail(model.Email))
                {
                    if (PasswordValidate)
                    {
                        var user = new UserModel
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            PasswordHash = new PasswordHashModel
                            {
                                Password = model.password
                            },
                            
                            Adress = new AddressModel
                            {
                                AddressLine = model.AddressLine,
                                ZipCode = model.ZipCode,
                                City = model.City
                            }
                         
                        };

                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetUserModel", new { id = user.Id }, user);
                    }


                    return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = PasseordError }));
                }
                return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Please enter a valid Email" }));
            }

            else 
                return new ConflictResult();
           
        }








        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }



        //Validate Email
        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }

        //Validate Password

        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
