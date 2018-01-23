using System.Collections.Generic;

namespace DECAds.AutoMapper
{
    public interface IAutoMapperService
    {
        /// <summary>
        /// Map a single object of TSourceType to TDestinationType 
        /// </summary>
        /// <typeparam name="TSourceType"></typeparam>
        /// <typeparam name="TDestinationType"></typeparam>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        TDestinationType Map<TSourceType, TDestinationType>(TSourceType sourceObject);

        /// <summary>
        /// Map a enumerable object of TSourceType to TDestinationType 
        /// </summary>
        /// <typeparam name="TSourceType"></typeparam>
        /// <typeparam name="TDestinationType"></typeparam>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        IEnumerable<TDestinationType> Map<TSourceType, TDestinationType>(IEnumerable<TSourceType> sourceObject);
    }
}