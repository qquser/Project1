using Project1.Application.API.Commands;
using Project1.Application.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Helpers
{
    public static class CommandHelper
    {
        public static IEnumerable<IBaseCommand<T>> Nodes<T>(this IBaseCommand<T> command) where T : IModel
        {
            for (var node = command; node != null; node = node.DecoratedHandler)
            {
                if (node.Equals(node.DecoratedHandler))
                    throw new Exception("This is an infinite cycle!");
                yield return node;
            }
        }
    }
}
