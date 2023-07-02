using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using gym.Data;
using Frenchtution.Exceptions; 

using Frenchtution.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Frenchtution.Controllers
{


public class BatchController : Controller
{
    private readonly ApplicationDbContext _context;

    public BatchController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult AvailableBatches()
    {
        var availableBatches = _context.Batches.ToList();
        return View(availableBatches);
    }

    public IActionResult BookedBatches()
    {
        var bookedBatches = _context.Batches
            .Where(b => b.Students.Count > 0)
            .ToList();
        return View(bookedBatches);
    }
}
}