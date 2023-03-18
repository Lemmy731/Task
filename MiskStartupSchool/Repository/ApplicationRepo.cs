using Microsoft.EntityFrameworkCore;
using MiskStartupSchool.Context;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Entities;
using MiskStartupSchool.Enums;
using MiskStartupSchool.Services;

namespace MiskStartupSchool.Repository
{
    public class ApplicationRepo : IApplicationRepo
    {
        readonly ApplicationDbContext _context;
        public ApplicationRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(ApplicationDto application)
        {
            if (application == null) return null;

            try
            {
                var data = new MyApplicationForm()
                {
                    ApplicationId = Guid.NewGuid().ToString(),
                    ImageUrl = application.ImageUrl,
                    ResumeUrl = application.ResumeUrl,
                    FirstName = application.FirstName,
                    LastName = application.LastName,
                    Email = application.Email,
                    Phone = application.Phone,
                    Nationality = application.Nationality,
                    Residence = application.Residence,
                    IDNumber = application.IDNumber,
                    Gender = application.Gender,
                    Educations = application.Educations,
                    Experiences = application.Experiences,
                    stages = application.stages,
                    ProgramType = application.ProgramType,
                    ProgramStart = application.ProgramStart,
                    ApplciationOpen = application.ApplciationOpen,
                    ApplicationClose = application.ApplicationClose,
                    Duration = application.Duration,
                    ProgramLocation = application.ProgramLocation,
                    MinQualification = application.MinQualification,
                    ProgramTitle = application.ProgramTitle,
                    ProgramSummary = application.ProgramSummary,
                    ProgramDescription = application.ProgramDescription,
                    KeySkills = application.KeySkills,
                    ProgramBenefits = application.ProgramBenefits,
                    ApplicationCriteria = application.ApplicationCriteria
                };

                await _context.AddAsync(data);
                var newdata = await _context.SaveChangesAsync();

                return newdata.ToString();
            }
            catch (DbUpdateException ex)
            {
                
               return ex.InnerException?.Message;
                
            }
        }
        public async Task<ProgramDto> GetProgram(string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);
            if (data == null) return null;

            return new ProgramDto()
            {
                Duration = data.Duration,
                ProgramDescription = data.ProgramDescription,
                ApplciationOpen = data.ApplciationOpen,
                ApplicationClose = data.ApplicationClose,
                ApplicationCriteria = data.ApplicationCriteria,
                KeySkills = data.KeySkills,
                MaxApplications = data.MaxApplications,
                MinQualification = data.MinQualification,
                ProgramBenefits = data.ProgramBenefits,
                ProgramLocation = data.ProgramLocation,
                ProgramStart = data.ProgramStart,
                ProgramSummary = data.ProgramSummary,
                ProgramTitle = data.ProgramTitle,
                ProgramType = data.ProgramType
            };
        }
        public async Task<List<ProgramDto>> GetAllProgram()
        {
            
            return await _context.application.Select(x => 
            new ProgramDto()
            {
                Duration = x.Duration,
                ProgramDescription = x.ProgramDescription,
                ApplciationOpen = x.ApplciationOpen,
                ApplicationClose = x.ApplicationClose,
                ApplicationCriteria = x.ApplicationCriteria,
                KeySkills = x.KeySkills,
                MaxApplications = x.MaxApplications,
                MinQualification = x.MinQualification,
                ProgramBenefits = x.ProgramBenefits,
                ProgramLocation = x.ProgramLocation,
                ProgramStart = x.ProgramStart,
                ProgramSummary = x.ProgramSummary,
                ProgramTitle = x.ProgramTitle,
                ProgramType = x.ProgramType
            }).ToListAsync();
        }
        public Task<bool> Remove(string Id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateProgram(ProgramDto program, string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);

            if (data == null) return false;

            data.Duration = program.Duration;
            data.ProgramDescription = program.ProgramDescription;
            data.ApplciationOpen = program.ApplciationOpen;
            data.ApplicationClose = program.ApplicationClose;
            data.ApplicationCriteria = program.ApplicationCriteria;
            data.KeySkills = program.KeySkills;
            data.MaxApplications = program.MaxApplications;
            data.MinQualification = program.MinQualification;
            data.ProgramBenefits = program.ProgramBenefits;
            data.ProgramLocation = program.ProgramLocation;
            data.ProgramStart = program.ProgramStart;
            data.ProgramSummary = program.ProgramSummary;
            data.ProgramTitle = program.ProgramTitle;
            data.ProgramType = program.ProgramType;

            _context.Update(data);
            return _context.SaveChanges() > 0;
        }
    }
}
