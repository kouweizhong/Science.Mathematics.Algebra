﻿using System.Threading;

namespace Science.Mathematics.Algebra
{
    /// <summary>
    /// Simplifies expressions.
    /// </summary>
    internal sealed class GenericAbsoluteValueSimplifier : ISimplifier<AbsoluteValueExpression>
    {
        public AlgebraExpression Simplify(AbsoluteValueExpression expression, CancellationToken cancellationToken)
        {
            return expression.WithExpression(expression.Expression.Simplify());
        }
    }
}
