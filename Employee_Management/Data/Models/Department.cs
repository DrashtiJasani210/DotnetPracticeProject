﻿using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
