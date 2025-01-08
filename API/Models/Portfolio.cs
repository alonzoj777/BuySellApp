
namespace API.Models;

public class Portfolio
{
    public int Id { get; set; }
    
    public int quantity { get; set; }

    public int InstrumentId { get; set; }

    //navigating properties
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
    
}
