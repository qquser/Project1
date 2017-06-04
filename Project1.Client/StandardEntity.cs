using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal abstract class StandardEntity : BaseRestSharp
    {
        public abstract Task Add();
        public abstract Task Rename();
        public abstract Task MakeInActive();

    }
}
