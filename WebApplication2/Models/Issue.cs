using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models;

public class Issue : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int? ExecutorId { get; set; }
    public int PriorityId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public virtual User? Author { get; set; }
    [ForeignKey(nameof(ExecutorId))]
    public virtual User? Executor { get; set; }
    [ForeignKey(nameof(PriorityId))]
    public virtual Priority? Priority { get; set; }
    public virtual ICollection<TimeTracking> TimeTrackings { get; set; }
    public Issue()
    {
        TimeTrackings = new List<TimeTracking>();
    }

}
