using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sandwich_shack.Models;
using sandwich_shack.Repositories;

namespace sandwich_shack.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
    private readonly UserRepository _repo;

    public AccountController(UserRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
      return View();
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult AccountDetails()
    {
      return View(Authenticate());
    }


    [HttpPost("login")]
    public async Task<User> Login([FromBody]UserLogin creds)
    {
      if (ModelState.IsValid)
      {
        var user = _repo.Login(creds);
        if (user == null) { return null; }
        user.SetClaims();
        await HttpContext.SignInAsync(user.GetPrincipal());
        return user;
      }
      return null;
    }

    [HttpPost("register")]
    public async Task<User> Register([FromBody]UserRegistration creds)
    {
      if (ModelState.IsValid)
      {
        var user = _repo.Register(creds);
        if (user == null) { return null; } //USER ALREADY EXISTS MOST LIKELY
        //req.session.uid = user._id
        //req.sesson.save()
        user.SetClaims();
        await HttpContext.SignInAsync(user.GetPrincipal());
        return user;
      }
      return null;
    }

    [Authorize]
    [HttpGet("authenticate")]
    public User Authenticate()
    {
      var user = HttpContext.User;
      var id = user.Identity.Name;
      return _repo.GetUserById(id);
    }

  }
}