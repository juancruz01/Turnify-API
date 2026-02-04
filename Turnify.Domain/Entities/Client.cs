using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Turnify.Domain.Common;

namespace Turnify.Domain.Entities;

public class Client : BaseEntity
{
    public Guid UserId { get; set; }
    public string Phone { get; set; } = null!;
    public string? Notes { get; set; }

    public User User { get; set; } = null!;
}
