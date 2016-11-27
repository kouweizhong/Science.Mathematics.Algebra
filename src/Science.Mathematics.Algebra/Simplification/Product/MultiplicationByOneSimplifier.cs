﻿using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Science.Mathematics.Algebra
{
    /// <summary>
    /// Simplifies expressions like 1 * x to x.
    /// </summary>
    public sealed class MultiplicationByOneSimplifier : ISimplifier<ProductExpressionList>
    {
        public AlgebraExpression Simplify(ProductExpressionList expression, CancellationToken cancellationToken)
        {
            var otherTerms = expression.Terms
                .Where(t => t.GetConstantValue(cancellationToken) != 1)
                .ToImmutableList();

            if (otherTerms.Count != expression.Terms.Count)
                return expression.WithTerms(otherTerms);
            
            return expression;
        }
    }
}
