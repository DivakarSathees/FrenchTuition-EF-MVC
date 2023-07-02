using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frenchtution.Models

{
    public class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int BatchID { get; set; }
    public Batch Batch { get; set; }
}
}