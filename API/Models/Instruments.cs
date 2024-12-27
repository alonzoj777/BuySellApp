using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class Instruments
{
    public Instruments()
    {
        InstrumentName = string.Empty;
        InstrumentType = string.Empty;
        Cusip = string.Empty;
        Isin = string.Empty;
        Sedol = string.Empty;
        Bloomberg = string.Empty;
        Ticker = string.Empty;
        Exchange = string.Empty;
        Currency = string.Empty;
        Country = string.Empty;
        Sector = string.Empty;
        Industry = string.Empty;
        SubIndustry = string.Empty;
        MarketCap = string.Empty;
    }
    [Key]
    public int InstrumentId { get; set; }
    public required string InstrumentName { get; set; }
    public string InstrumentType { get; set; }
    public string Cusip { get; set; }
    public string Isin { get; set; }
    public string Sedol { get; set; }
    public string Bloomberg { get; set; }
    public string Ticker { get; set; }
    public string Exchange { get; set; }
    public string Currency { get; set; }
    public string Country { get; set; }
    public string Sector { get; set; }
    public string Industry { get; set; }
    public string SubIndustry { get; set; }
    public string MarketCap { get; set; }

}
