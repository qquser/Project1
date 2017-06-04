using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Client
{
    internal class City : IStandardEntity
    {
        private readonly string _name;
        public City(string name)
        {
            _name = name;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void MakeInActive()
        {
            throw new NotImplementedException();
        }

        public void Rename()
        {
            throw new NotImplementedException();
        }
    }
}
