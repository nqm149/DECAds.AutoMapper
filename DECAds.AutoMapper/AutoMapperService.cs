using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;

[assembly: InternalsVisibleTo("DECAds.AutoMapper.Tests")]
namespace DECAds.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperService : IAutoMapperService
    {
        internal static readonly ISet<MapperItem> _mappers = new HashSet<MapperItem>();

        internal static void AddBidirectionalMapper<TSourceType, TDestinationType>()
        {
            var toDestinationTypeMap = new MapperItem(typeof(TSourceType), typeof(TDestinationType), new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TSourceType, TDestinationType>() )));
            var toSourceTypeMap = new MapperItem(typeof(TDestinationType), typeof(TSourceType), new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TDestinationType, TSourceType>() )));

            _mappers.Add(toDestinationTypeMap);
            _mappers.Add(toSourceTypeMap);
        }

        internal static IMapper GetMapper<TSourceType, TDestinationType>() 
            => _mappers.FirstOrDefault(m => m.SourceType == typeof(TSourceType) && m.DestinationType == typeof(TDestinationType))?.MyMapper as Mapper;

        /// <inheritdoc />
        public TDestinationType Map<TSourceType, TDestinationType>(TSourceType sourceObject)
        {
            if (GetMapper<TSourceType, TDestinationType>() != null)
                return GetMapper<TSourceType, TDestinationType>().Map<TDestinationType>(sourceObject);

            AddBidirectionalMapper<TSourceType, TDestinationType>();
            return GetMapper<TSourceType, TDestinationType>().Map<TDestinationType>(sourceObject);
        }

        /// <inheritdoc />
        public IEnumerable<TDestinationType> Map<TSourceType, TDestinationType>(IEnumerable<TSourceType> sourceObject)
        {
            if (GetMapper<TSourceType, TDestinationType>() != null)
                return GetMapper<TSourceType, TDestinationType>().Map<IEnumerable<TDestinationType>>(sourceObject);

            AddBidirectionalMapper<TSourceType, TDestinationType>();
            return GetMapper<TSourceType, TDestinationType>().Map<IEnumerable<TDestinationType>>(sourceObject);
        }
    }

}
