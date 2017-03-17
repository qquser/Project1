using Project1.Common.DTO;
using System.Collections.Generic;

namespace Project1.Common.Queries.Project
{
    public interface IGetAllProjects
    {
    }

    public interface IGetAllProjectsResult
    {
        List<ProjectDTO> Projects { get; }
    }
}