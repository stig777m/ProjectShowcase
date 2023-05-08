using BussinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BussinessLogicLayer.Services
{
    public class ProjectRepositories : IProjectServices
    {
        private readonly IProjectRepositories _repositories;
        public ProjectRepositories(IProjectRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<bool> ChangeStatus(string projectId, string status)
        {
            return await _repositories.ChangeStatus(projectId, status);
        }

        public async Task<ProjectDTO> CreateProject(ProjectDTO? project)
        {
            return await _repositories.CreateProject((Project)project);
        }

        public async Task<ProjectDTO> GetProjectById(string id)
        {
            return await _repositories.GetProjectById(id);
        }

        public async Task<List<ProjectDTO>> SearchProject(string keyword)
        {
            List<Project> list = await _repositories.SearchProject(keyword);
            return list.Select(project => (ProjectDTO)project).ToList();
        }
    }
}
