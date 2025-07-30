using System;
using System.Collections.Generic;

namespace EFCoreDbFirstDemo.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int Age { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }
}
