using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace BankSystem.Common
{
    class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IQueryable<TargetType> ProjectTo<CollectionType, TargetType>(IQueryable<CollectionType> collection)
        {
            return collection.ProjectTo<TargetType>();
        }

        public Target Map<Source, Target>(Source source)
        {
            return mapper.Map<Target>(source);
        }
    }
}
