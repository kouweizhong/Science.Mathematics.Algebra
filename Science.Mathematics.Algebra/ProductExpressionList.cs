﻿using System;
using System.Collections.Immutable;
using System.Linq;

namespace Science.Mathematics.Algebra
{
    public class ProductExpressionList : ExpressionList
    {
        public ProductExpressionList(ImmutableList<AlgebraExpression> terms)
            : base(terms)
        { }
        

        public override AlgebraExpression Simplify()
        {
            // Collect constants
            var constants = this.Terms.ToDictionary(e => e, e => e.GetConstantValue());

            // all constant: 1 * 2 * 3
            if (constants.Values.All(v => v != null))
                return ExpressionFactory.Constant(constants.Values.Cast<double>().Product(v => v));

            // collect constants: 1 * ? * 2 -> (1 * 2) * ? -> 3 * ?
            double product = constants.Values.Where(v => v != null).Cast<double>().Product(v => v);
            var newTerms = this.Terms.RemoveAll(e => constants[e].HasValue);

            if (product == 0) // 0 * ?
                return ConstantExpression.Zero;

            if (product != 1) // 1 * ?
                newTerms = newTerms.Insert(0, ExpressionFactory.Constant(product));

            // TODO: Collect power terms

            return new ProductExpressionList(newTerms);
        }

        public override AlgebraExpression Expand()
        {
            throw new NotImplementedException();
        }

        public override AlgebraExpression Factor()
        {
            throw new NotImplementedException();
        }


        public override double? GetConstantValue()
        {
            return this.Terms.Select(t => t.GetConstantValue()).Product(v => v);
        }


        public override string ToString()
        {
            return String.Join(" * ", this.Terms);
        }
    }
}