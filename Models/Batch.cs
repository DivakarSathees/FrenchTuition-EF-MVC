using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frenchtution.Models

{
    public class Batch
{
    public int BatchID { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Capacity { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}

}