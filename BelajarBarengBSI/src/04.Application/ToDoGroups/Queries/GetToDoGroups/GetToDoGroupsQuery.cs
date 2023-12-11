using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.BelajarBarengBSI.Application.Common.Extensions;
using Zeta.BelajarBarengBSI.Application.Common.Mappings;
using Zeta.BelajarBarengBSI.Application.Services.Persistence;
using Zeta.BelajarBarengBSI.Domain.Entities;
using Zeta.BelajarBarengBSI.Shared.Common.Enums;
using Zeta.BelajarBarengBSI.Shared.Common.Requests;
using Zeta.BelajarBarengBSI.Shared.Common.Responses;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Queries.GetToDoGroups;

namespace Zeta.BelajarBarengBSI.Application.ToDoGroups.Queries.GetToDoGroups;

public class GetToDoGroupsQuery : PaginatedListRequest, IRequest<PaginatedListResponse<GetToDoGroupsToDoGroup>>
{
}

public class GetToDoGroupsToDoGroupMapping : IMapFrom<ToDoGroup, GetToDoGroupsToDoGroup>
{
}

public class GetToDoGroupsQueryHandler : IRequestHandler<GetToDoGroupsQuery, PaginatedListResponse<GetToDoGroupsToDoGroup>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetToDoGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedListResponse<GetToDoGroupsToDoGroup>> Handle(GetToDoGroupsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.ToDoGroups
            .AsNoTracking();

        if (!string.IsNullOrEmpty(request.SearchText))
        {
            query = query.Where(x => x.Name.Contains(request.SearchText));
        }

        if (request.SortOrder is SortOrder.Asc)
        {
            query = request.SortField switch
            {
                nameof(GetToDoGroupsToDoGroup.Name) => query.OrderBy(x => x.Name),
                nameof(GetToDoGroupsToDoGroup.Created) => query.OrderBy(x => x.Created),
                nameof(GetToDoGroupsToDoGroup.Modified) => query.OrderBy(x => x.Modified),
                _ => query.OrderBy(x => x.Created)
            };
        }
        else if (request.SortOrder is SortOrder.Desc)
        {
            query = request.SortField switch
            {
                nameof(GetToDoGroupsToDoGroup.Name) => query.OrderByDescending(x => x.Name),
                nameof(GetToDoGroupsToDoGroup.Created) => query.OrderByDescending(x => x.Created),
                nameof(GetToDoGroupsToDoGroup.Modified) => query.OrderByDescending(x => x.Modified),
                _ => query.OrderByDescending(x => x.Created)
            };
        }
        else
        {
            query = query.OrderByDescending(x => x.Created);
        }

        var result = await query.ToPaginatedListAsync(request.Page, request.PageSize, cancellationToken);

        return result.AsPaginatedListResponse<GetToDoGroupsToDoGroup, ToDoGroup>(_mapper.ConfigurationProvider);
    }
}
