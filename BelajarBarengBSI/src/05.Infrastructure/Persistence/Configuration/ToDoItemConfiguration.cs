using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zeta.BelajarBarengBSI.Application.Services.Persistence;
using Zeta.BelajarBarengBSI.Domain.Entities;
using Zeta.BelajarBarengBSI.Infrastructure.Persistence.Common.Constants;
using Zeta.BelajarBarengBSI.Shared.ToDoItems.Constants;

namespace Zeta.BelajarBarengBSI.Infrastructure.Persistence.SqlServer.Configuration;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable(nameof(IApplicationDbContext.ToDoItems), nameof(BelajarBarengBSI));

        builder.Property(e => e.Title).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Title));
        builder.Property(e => e.Description).HasColumnType(CommonColumnTypes.Nvarchar(MaximumLengthFor.Description));

        builder.HasOne(e => e.ToDoGroup).WithMany(e => e.ToDoItems).HasForeignKey(e => e.ToDoGroupId).OnDelete(DeleteBehavior.Restrict);
    }
}
