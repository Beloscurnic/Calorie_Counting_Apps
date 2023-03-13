using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface I_DbContext
    {
        DbSet<Domain_Example> Domain_Examples { get; set; }
        DbSet<CalorieIntake> CalorieIntakes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
