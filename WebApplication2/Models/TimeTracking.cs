using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models;

public class TimeTracking : BaseModel
{
    public int? UserId { get;set; }
    public int IssueId { get;set; } 
    public DateTime ExecutionDate { get; set; }
    public int Hours { get; set; }
    [ForeignKey(nameof(IssueId))]
    public virtual Issue Issue { get; set; }
}
