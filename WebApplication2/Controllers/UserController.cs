using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
                _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //Контроллер, который возвращает список пользователей
        [HttpGet]
        public async Task<IActionResult> Index(int id = 0)
        {
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            if (id == 0)
            {
                var users = await _context.Users.ToListAsync();
                //throw new FileLoadException("блабла");
                return View(users);
            }
            else
            {
                IQueryable<User> usersIQuer = _context.Users;
                var users = await usersIQuer.Where(w => w.PositionId == id).ToListAsync();
                return View(users);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            User user = new();
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var positions = await _context.Positions.ToListAsync();
            ViewBag.Positions = positions;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if(user is null)
                throw new ArgumentException(nameof(user));
            user.ModifiedAt = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                throw new ArgumentException(nameof(user));
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var user =  _context.Users.Find(id);
            return PartialView("Popup",user);
        }
    }
}
