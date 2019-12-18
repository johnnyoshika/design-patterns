using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Specification.Specifications
{
    public class AndSpecification<T> : ISpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        ISpecification<T> Left { get; }
        ISpecification<T> Right { get; }

        public Expression<Func<T, bool>> Criteria => Left.Criteria.And(Right.Criteria);
    }
}
