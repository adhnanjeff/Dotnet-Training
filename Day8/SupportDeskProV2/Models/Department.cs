using System;
using System.Collections.Generic;

namespace SupportDeskProV2.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
