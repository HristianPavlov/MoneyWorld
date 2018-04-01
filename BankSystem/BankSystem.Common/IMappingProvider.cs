using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Common
{
    interface IMappingProvider
    {
        Target Map<Source, Target>(Source source);
        IQueryable<TargetType> ProjectTo<CollectionType, TargetType>(IQueryable<CollectionType> collection);
    }


}
