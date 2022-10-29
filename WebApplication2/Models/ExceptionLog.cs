using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ExceptionLog
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
