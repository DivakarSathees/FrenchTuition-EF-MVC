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
public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult BatchEnrollmentForm(int id)
    {
        Console.WriteLine(id);
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }

        return View(batch);
    }

    [HttpPost]
    public IActionResult BatchEnrollmentForm(int id, string name, string email)
    {
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }

        if (batch.Capacity == 0)
        {
            throw new FrenchTuitionBookingException("Maximum number reached");
        }

        var student = new Student
        {
            Name = name,
            Email = email,
            BatchID = id
        };

        _context.Students.Add(student);

        // Update the batch capacity
        batch.Capacity = batch.Capacity - 1;

        // Save changes to the database
        _context.SaveChanges();

        return RedirectToAction("EnrollmentConfirmation", new { studentId = student.StudentID });
    }

    public IActionResult EnrollmentConfirmation(int studentId)
    {
        var student = _context.Students.Include(s => s.Batch).SingleOrDefault(s => s.StudentID == studentId);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
}
}