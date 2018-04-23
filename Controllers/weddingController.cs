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
    public class weddingController : Controller
    {
        private weddingPlannerContext _context;
    public weddingController(weddingPlannerContext context)
        {
             _context = context;

        }
        public IActionResult newWed(int id)
        {
            Wedding singleWedding = _context.weddings.Include(w => w.UserWedding).ThenInclude(u => u.User).SingleOrDefault(w => w.weddingId == id);
            ViewBag.singleWedding = singleWedding;
            return View("wedding");
        }
        public IActionResult addWedding(WeddingViewModel wedding){
            if(ModelState.IsValid){
                Wedding newWed = new Wedding{
                    wedderOne = wedding.wedderOne,
                    wedderTwo = wedding.wedderTwo,
                    date = wedding.date,
                    wedAddress = wedding.wedAddress,
                    createdBy =  (int)HttpContext.Session.GetInt32("id"),
                };
                _context.weddings.Add(newWed);               
                _context.SaveChanges();
                return RedirectToAction("dash","User");
            }
            return View("newWedding");
        }
        public IActionResult addWeddingLink(){
            return View("newWedding");
        }
        public IActionResult Delete(int id){
            Wedding w = _context.weddings.SingleOrDefault(wed => wed.weddingId == id);
            _context.weddings.Remove(w);
            _context.SaveChanges();
            return RedirectToAction("dash", "User");
        } 
        public IActionResult rsvp (int id){
            Wedding w = _context.weddings.Include(a => a.UserWedding).ThenInclude(a => a.User).SingleOrDefault(a => a.weddingId == id);
            UserWedding uw = new UserWedding{userId = (int)HttpContext.Session.GetInt32("id"), weddingId = w.weddingId};
            _context.userweddings.Add(uw);
            _context.SaveChanges();
            return RedirectToAction("dash", "User");
        }
        public IActionResult unRsvp(int id){
            UserWedding uw = _context.userweddings.SingleOrDefault(user => user.userId == (int)HttpContext.Session.GetInt32("id") && user.weddingId == id);
            _context.userweddings.Remove(uw);
            _context.SaveChanges();
            return RedirectToAction("dash", "User");
        }
    }
}