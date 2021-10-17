
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using OSCManager.Abstractions.Model.Entities;

namespace OSCManager.Abstractions.Model
{
    public class OrderByUnit<T> where T : IEntity
    {
        public OrderByUnit(Expression<Func<T, object>> expression, SortDirection sortDirection)
        {
            OrderByExpression = expression;
            SortDirection = sortDirection;
        }

        public Expression<Func<T, object>> OrderByExpression { get; }
        public SortDirection SortDirection { get; }
    }

    public class OrderBy<T> where T : IEntity
    {
        public OrderBy(Expression<Func<T, object>> expression, SortDirection sortDirection)
        {
            Sorts.Add(new(expression, sortDirection));
        }

        public ICollection<OrderByUnit<T>> Sorts { get; set; } = new List<OrderByUnit<T>>(4);

        public OrderBy<T> OrderByAccording(Expression<Func<T, object>> expression)
        {
            Sorts.Add(new(expression, SortDirection.Ascending));
            return this;
        }

        public OrderBy<T> OrderByDescending(Expression<Func<T, object>> expression)
        {
            Sorts.Add(new(expression, SortDirection.Descending));
            return this;
        }
    }

    public static class OrderByBuild
    {
        public static OrderBy<T> OrderBy<T>(Expression<Func<T, object>> expression) where T : IEntity => new(expression, SortDirection.Ascending);
        public static OrderBy<T> OrderByDescending<T>(Expression<Func<T, object>> expression) where T : IEntity => new(expression, SortDirection.Descending);
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
