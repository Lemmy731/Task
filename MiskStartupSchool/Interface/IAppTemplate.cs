using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IAppTemplate
    {
        Task<AppTemplateDto> GetTemplate(string Id);
        Task<bool> UpdateTemplate(AppTemplateDto program, string Id);
    }
}
