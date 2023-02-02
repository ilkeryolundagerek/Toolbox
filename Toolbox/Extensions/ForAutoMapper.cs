using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Extensions
{
    public static class ForAutoMapper
    {
        public static IMappingExpression<TSource,TDestination> IgnoreAll<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            expression.ForAllMembers(o => o.Ignore());
            return expression;
        }
    }
}
