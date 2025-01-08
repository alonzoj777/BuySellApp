using API.Data;
using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
public class InstrumentController : BaseApiController
{
    private readonly DataContext _context;
    private readonly YahooFinanceService _yahooFinanceService;

    public InstrumentController(DataContext context, YahooFinanceService yahooFinanceService)
    {
        _context = context;
        _yahooFinanceService = yahooFinanceService;
    }

        //private readonly DataContext? _context;
        //  private readonly YahooFinanceService? _yahooFinanceService;

        [HttpGet("all")]//api/instrument/all
        public async Task<ActionResult<IEnumerable<Instruments>>> GetInstruments()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var instruments = await _context.Instruments.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            return instruments;
        }
        
        [HttpGet("{ticker}")]//api/instrument/{ticker}
        public async Task<ActionResult<Instruments>> GetInstruments(string ticker)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var instrument = await _context.Instruments.FirstOrDefaultAsync(i => i.Ticker == ticker);
#pragma warning restore CS8604 // Possible null reference argument.
            if (instrument == null) return NotFound();
            
            return instrument;
        }

        [HttpGet("yahoo/{ticker}")] // api/instrument/yahoo/{ticker}
        public async Task<IActionResult> GetYahooFinanceData(string ticker)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var data = await _yahooFinanceService.GetStockDataAsync(ticker);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(data);
        } 

         [HttpPost("create")]//api/instrument/create
        public async Task<IActionResult> CreateInstrumentAsync([FromBody] InstrumentDto instrumentDto)
        {
            if (instrumentDto == null)
            {
                return BadRequest("Instrument data is null.");
            }
             var instrument = new Instruments
            {
                InstrumentName = instrumentDto?.InstrumentName ?? string.Empty,
                InstrumentType = instrumentDto?.InstrumentType ?? string.Empty,
                Cusip = instrumentDto?.Cusip ?? string.Empty,
                Isin = instrumentDto?.Isin ?? string.Empty,
                Sedol = instrumentDto?.Sedol ?? string.Empty,
                Bloomberg = instrumentDto?.Bloomberg ?? string.Empty,
                Ticker = instrumentDto?.Ticker ?? string.Empty,
                Exchange = instrumentDto?.Exchange ?? string.Empty,
                Currency = instrumentDto?.Currency ?? string.Empty,
                Country = instrumentDto?.Country ?? string.Empty,
                Sector = instrumentDto?.Sector ?? string.Empty,
                Industry = instrumentDto?.Industry ?? string.Empty,
                SubIndustry = instrumentDto?.SubIndustry ?? string.Empty,
                MarketCap = instrumentDto?.MarketCap ?? string.Empty
            };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _context.Instruments.Add(instrument);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await _context.SaveChangesAsync();

            return Ok(instrumentDto);
        
        }
         
         
    }
}
