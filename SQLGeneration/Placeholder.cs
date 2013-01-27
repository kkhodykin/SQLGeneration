﻿using System;
using SQLGeneration.Expressions;

namespace SQLGeneration
{
    /// <summary>
    /// Acts as a placeholder anywhere within the options of a SQL statement.
    /// </summary>
    public class Placeholder : IProjectionItem, IFilterItem, IGroupByItem
    {
        private readonly string value;

        /// <summary>
        /// Initializes a new instance of a Placeholder.
        /// </summary>
        /// <param name="value">The value of the placeholder.</param>
        public Placeholder(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets an alias for the placeholder. This is ignored.
        /// </summary>
        public string Alias
        {
            get;
            set;
        }

        IExpressionItem IProjectionItem.GetProjectionExpression(CommandOptions options)
        {
            return new Token(value);
        }

        IExpressionItem IGroupByItem.GetGroupByExpression(CommandOptions options)
        {
            return new Token(value);
        }

        IExpressionItem IFilterItem.GetFilterExpression(CommandOptions options)
        {
            return new Token(value);
        }
    }
}