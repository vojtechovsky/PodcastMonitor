﻿using System;
using System.Linq.Expressions;

namespace PodcastMonitor.Stores
{
    /// <summary>
    /// Another good idea by Tomas Petricek.
    /// See http://tomasp.net/blog/dynamic-linq-queries.aspx for information on how it's used.
    /// </summary>
    public static class Linq
    {
        // Returns the given anonymous method as a lambda expression
        public static Expression<Func<T, TResult>> Expr<T, TResult>(Expression<Func<T, TResult>> expr)
        {
            return expr;
        }

        // Returns the given anonymous function as a Func delegate
        public static Func<T, TResult> Func<T, TResult>(Func<T, TResult> expr)
        {
            return expr;
        }
    }
}