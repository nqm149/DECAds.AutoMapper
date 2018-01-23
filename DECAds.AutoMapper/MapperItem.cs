using System;
using AutoMapper;

namespace DECAds.AutoMapper
{
    public class MapperItem
    {
        public Type SourceType { get; }
        public Type DestinationType { get; }
        public IMapper MyMapper { get; }

        /// <inheritdoc />
        public MapperItem(Type sourceType, Type destinationType, IMapper mapper)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
            MyMapper = mapper;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var mapItem = (MapperItem)obj;

            return mapItem.SourceType == SourceType && mapItem.DestinationType == DestinationType;
        }

        public override int GetHashCode() 
            => SourceType.GetHashCode() ^ DestinationType.GetHashCode();
    }
}