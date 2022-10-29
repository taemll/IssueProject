using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models;

public class User : BaseModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int PositionId { get; set; }
    [ForeignKey(nameof(PositionId))]
    public virtual Position Position { get; set; }
}
