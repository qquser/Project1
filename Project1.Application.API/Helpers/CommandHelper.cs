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
            var list = new List<Type>();
            for (var node = command; node != null; node = node.DecoratedHandler)
            {
                bool isNodeTypeExists = list.Any(x => x.Equals(node.GetType()));
                if (isNodeTypeExists)
                    throw new Exception("This is an infinite cycle!");
                list.Add(node.GetType());
                yield return node;
            }
        }
    }
}
