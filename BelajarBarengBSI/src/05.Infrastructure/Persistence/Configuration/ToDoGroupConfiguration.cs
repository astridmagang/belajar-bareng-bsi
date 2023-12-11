using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeta.BelajarBarengBSI.Application.Services.Persistence;
using Zeta.BelajarBarengBSI.Domain.Entities;
using Zeta.BelajarBarengBSI.Infrastructure.Persistence.Common.Constants;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Constants;

namespace Zeta.BelajarBarengBSI.Infrastructure.Persistence.SqlServer.Configuration;

public class ToDoGroupConfiguration : IEntityTypeConfiguration<ToDoGroup>
{
    public void Configure(EntityTypeBuilder<ToDoGroup> builder)
    {
        builder.ToTable(nameof(IApplicationDbContext.ToDoGroups), nameof(BelajarBarengBSI));

        builder.Property(e => e.Name).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Name));
    }
}
