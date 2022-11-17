using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveBuilderExample
{
    public class Resume
    {
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string CandidateName { get; set; }
        public string Title { get; set; }
        public Education Education { get; set; } = new Education();
        public Work Work { get; set; } = new Work();
    }

    public class Education
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double GPA { get; set; }
        public string EducationAchivement { get; set; }
    }

    public class Work
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class WorkBuilder
    {
        private Work Work { get; set; } = new Work();
        private Resume Resume { get; set; } = new Resume(); 

        public WorkBuilder(Resume resume, Work work)
        {
            Resume = resume;
            Work = work;
        }

        public WorkBuilder WithTitle(string title)
        {
            Work.Title = title;
            return this;
        }

        public WorkBuilder WithDescription(string description)
        {
            Work.Description = description;
            return this;
        }

        public WorkBuilder WithCompany(string company)
        {
            Work.Company = company;
            return this;
        }

        public WorkBuilder WithStartDate(DateTime startDate)
        {
            Work.StartDate = startDate;
            return this;
        }

        public WorkBuilder WithEndDate(DateTime endDate)
        {
            Work.EndDate = endDate;
            return this;
        }

        public Resume Build()
        {
            return Resume;
        }
    }

    public class EducationBuilder
    {
        private Education Education { get; set; }
        private Resume Resume { get; set; }

        public EducationBuilder(Resume resume, Education education)
        {
            Resume = resume;
            Education = education;
        }

        public EducationBuilder WithName(string name)
        {
            Education.Name = name;
            return this;
        }

        public EducationBuilder WithDescription(string description)
        {
            Education.Description = description;
            return this;
        }

        public EducationBuilder WithGPA(double GPA)
        {
            Education.GPA = GPA;
            return this;
        }

        public EducationBuilder WithEducationAchivement(string educationAchivement)
        {
            Education.EducationAchivement = educationAchivement;
            return this;
        }

        public WorkBuilder AddWork(Action<WorkBuilder> workBuilder)
        {
            var work = new Work();
            var woBuilder = new WorkBuilder(Resume, work);
            workBuilder.Invoke(woBuilder);
            Resume.Work = work;
            return woBuilder;
        }
    }

    public class ResumeBuilder
    {
        private Resume Resume { get; set; } = new Resume();

        public ResumeBuilder WithTitle(string title)
        {
            Resume.Title = title;
            return this;
        }

        public ResumeBuilder WithDescription(string description)
        {
            Resume.Description = description;
            return this;
        }

        public ResumeBuilder WithCandidateName(string candidateName)
        {
            Resume.CandidateName = candidateName;
            return this;
        }

        public ResumeBuilder WithAvatarUrl(string avatarUrl)
        {
            Resume.AvatarUrl = avatarUrl;
            return this;
        }

        public EducationBuilder AddEducation(Action<EducationBuilder> educationBuilder)
        {
            var edu = new Education();
            var eduBuilder = new EducationBuilder(Resume, edu);
            educationBuilder.Invoke(eduBuilder);
            Resume.Education = edu;
            return eduBuilder;
        }
    }
}
