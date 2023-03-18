using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiskStartupSchool.Enums;
using Newtonsoft.Json;

namespace MiskStartupSchool.Entities
{
    public class MyApplicationForm : WorkFlow
    {
        [Key]
        [JsonProperty(PropertyName = "ApplicationId")]
        public string? ApplicationId { get; set; }
        public string ImageUrl { get; set; }
        public string ResumeUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public string IDNumber { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
    }
}
