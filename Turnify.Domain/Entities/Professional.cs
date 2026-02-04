using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Turnify.Domain.Common;

namespace Turnify.Domain.Entities;

public class Professional : BaseEntity
{
    public Guid UserId { get; set; }
    public string Specialty { get; set; } = null!;
    public string WorkingHours { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public User User { get; set; } = null!;
}

