using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Turnify.Domain.Common;
using Turnify.Domain.Enums;

namespace Turnify.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid ProfessionalId { get; set; }
    public Guid ClientId { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    public Professional Professional { get; set; } = null!;
    public Client Client { get; set; } = null!;
}
