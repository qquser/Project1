using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class Workshop : StandardEntity
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly Guid _cityId;
        public Workshop(Guid id, string name, Guid cityId)
        {
            _name = name;
            _id = id;
            _cityId = cityId;
        }
        public override async Task Add()
        {
            throw new NotImplementedException();
        }

        public override async Task MakeInActive()
        {
            throw new NotImplementedException();
        }

        public override async Task Rename()
        {
            throw new NotImplementedException();
        }
    }
}
