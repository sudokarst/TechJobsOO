using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string Name { get; set; }

        [Required] // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation#notes-on-the-use-of-the-required-attribute
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        [Display(Name = "Location")]
        public int LocationID { get; set; }

        [Display(Name = "Core Competency")]
        public int CoreCompetencyID { get; set; }

        [Display(Name = "Position Type")]
        public int PositionTypeID { get; set; }

        // TODO #3X - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4X - populate the other List<SelectListItem> 
            // collections needed in the view

            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }
    }
}
