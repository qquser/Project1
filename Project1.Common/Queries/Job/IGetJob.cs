using Project1.Common.DTO;
using System;

namespace Project1.Common.Queries.Job
{
    public interface IGetJob
    {
        Guid Id { get; }
    }

    public interface IGetJobResult
    {
        ProjectDTO Project { get; }
    }
}