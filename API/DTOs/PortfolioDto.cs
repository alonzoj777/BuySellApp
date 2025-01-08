using System;

namespace API.DTOs;

public class PortfolioDto
{
    public int Id { get; set; }
    
    public int quantity { get; set; }

    public int InstrumentId { get; set; }

    public int AppUserId { get; set; }
    
}
