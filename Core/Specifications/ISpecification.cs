using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skinet.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get;}
    }
}
