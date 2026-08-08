using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
}
