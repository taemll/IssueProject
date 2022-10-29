using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PositionController : Controller
    {
        private readonly DataContext _context;
        public PositionController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //Контроллер, который возвращает список пользователей
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var positions = await _context.Positions.ToListAsync();
            return View(positions);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Position position = new();
            var positions = await _context.Positions.ToListAsync();
            return View(position);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            return View(position);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Position position)
        {
            if (position is null)
                throw new ArgumentException(nameof(position));
            position.ModifiedAt = DateTime.Now;
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position is null)
                throw new ArgumentException(nameof(position));
            if (_context.Users.Any(a => a.PositionId == id))
                return RedirectToAction("Error", "HomeController");
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }        
    }
}
