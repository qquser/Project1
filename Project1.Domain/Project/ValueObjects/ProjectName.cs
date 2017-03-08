using System;
using Project1.Common;

namespace Project1.Domain.Project.ValueObjects
{
    internal class ProjectName : ValueObject<string>
    {
        public ProjectName(string name) : base(name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
        }
    }
}