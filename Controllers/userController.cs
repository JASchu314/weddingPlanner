using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using weddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Controllers
{
    public class userController : Controller
    {
        private weddingPlannerContext _context;
    public userController(weddingPlannerContext context)
    {
         _context = context;

    } 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult addUser(UserViewModel user){
            if(ModelState.IsValid){
                if(_context.users.SingleOrDefault(a => a.email== user.email)!=null){
                    TempData["Error"]="Email already exists";
                    return RedirectToAction("Index");
                }
            PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                user.password = Hasher.HashPassword(user, user.password);
                User newUser = new User{
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    password = user.password,
                };
                _context.Add(newUser);
                _context.SaveChanges();
                User nu = _context.users.SingleOrDefault(u => u.email == user.email);
                HttpContext.Session.SetInt32("id", nu.userId);
                return RedirectToAction("dash");
            }
            return View("Index");
        }
            public IActionResult Login(loginViewModel user){
                if(ModelState.IsValid){
                    User oneUser = _context.users.SingleOrDefault(u => u.email == user.email);
                    if(oneUser != null){
                if(user.email != null && user.password != null){
                        var Hasher = new PasswordHasher<loginViewModel>();
                    if(0 != Hasher.VerifyHashedPassword(user, oneUser.password, user.password)){
                        HttpContext.Session.SetInt32("id", oneUser.userId);
                        return RedirectToAction("dash");
                        }
                     }
                    }
                }
                 TempData["Error"]="User does not exist";
                    return View("Index");
            }
            public IActionResult dash(){
                  List<Wedding> allWeddings =_context.weddings.Include(u => u.UserWedding).ThenInclude(u => u.User).ToList();
                    ViewBag.allWeddings = allWeddings;
                    ViewBag.userId = HttpContext.Session.GetInt32("id");
                    return View("dashboard");
            }
           
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
