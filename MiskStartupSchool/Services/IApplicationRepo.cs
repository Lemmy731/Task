﻿using Microsoft.AspNetCore.Mvc;
using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IApplicationRepo
    {
        Task<ProgramDto> GetProgram(string Id);
        Task<List<ProgramDto>> GetAllProgram();
        Task<bool> Update(ApplicationDto application);
        Task<string> Add(ApplicationDto application);
        Task<bool> Remove(string Id);
    }
}
