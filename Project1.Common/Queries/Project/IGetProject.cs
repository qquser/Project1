using Project1.Common.DTO;
using System;

namespace Project1.Common.Queries.Project
{
    public interface IGetProject
    {
        Guid Id { get; }
    }

    public interface IGetProjectResult
    {
        ProjectDTO Project { get; }
    }
}