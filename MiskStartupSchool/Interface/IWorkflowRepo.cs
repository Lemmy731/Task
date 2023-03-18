using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IWorkflowRepo
    {
        Task<WorkflowDto> GetWorkflow(string Id);
        Task<bool> UpdateWorkflow(WorkflowDto program, string Id);
    }
}
