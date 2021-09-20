using Labostic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labostic.Services
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AboutSign> AboutSign { get; set; }
        public DbSet<AboutStatistic> AboutStatistic { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Awards> Awards { get; set; }

        public DbSet<AwardsToDoctor> AwardsToDoctor { get; set; }
        public DbSet<Check> Check { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Faq> Faq { get; set; }
        public DbSet<HomeCircle> HomeCircle { get; set; }
        public DbSet<LabTech> LabTech { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<ResearchCategory> ResearchCategory { get; set; }
        public DbSet<ResearchSquar> ResearchSquar { get; set; }
        public DbSet<Models.Services> Services { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Models.Skill> Skill { get; set; }
        public DbSet<SkillToDoctor> SkillToDoctor { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Social> Social { get; set; }
        public DbSet<SocialToDoctor> SocialToDoctor { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<TrustedExp> TrustedExp { get; set; }
        public DbSet<WhyChoose> WhyChoose { get; set; }
        public DbSet<WorkProcess> WorkProcess { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<WriterToResearch> WriterToResearch { get; set; }
        public DbSet<CustomUser> CustomUser { get; set; }



    }
}
