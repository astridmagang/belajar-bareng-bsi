﻿using AutoMapper;

namespace Zeta.BelajarBarengBSI.Application.Common.Mappings;

public interface IMapFrom<TSource, TDestination>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap<TSource, TDestination>();
    }
}
