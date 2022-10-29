using WebApplication2.Contexts;

namespace WebApplication2.Services
{
    public class LogService : ILogService
    {
        private readonly DataContext _context;

    }

    public interface ILogService
    {
    }
}
