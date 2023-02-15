using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public int? DeptId { get; set; }

    public int MngrId { get; set; }

    public string EmpName { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual Department? Dept { get; set; }
}
