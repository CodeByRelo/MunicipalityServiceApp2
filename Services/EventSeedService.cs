using MunicipalityServiceApp2.Data;
using MunicipalityServiceApp2.Models;
using System;
using System.Linq;

namespace MunicipalityServiceApp2.Services
{
    public class EventSeedService
    {
        public void Seed()
        {
            using (var db = new MunicipalityDbContext())
            {
                if (db.Events.Any())
                {
                    return;
                }

                db.Events.Add(new Event
                {
                    Title = "Community Clean-Up Day",
                    Location = "Botlokwa Community Hall",
                    Description =
                        "Residents are invited to take part in a community clean-up initiative.",
                    EventDate = DateTime.Now.AddDays(3).Date.AddHours(9),
                    Category = "Community",
                    Priority = "High",
                    DateCreated = DateTime.Now
                });

                db.Events.Add(new Event
                {
                    Title = "Youth Development Workshop",
                    Location = "Municipal Youth Centre",
                    Description =
                        "A workshop focused on youth development, skills and opportunities.",
                    EventDate = DateTime.Now.AddDays(7).Date.AddHours(10),
                    Category = "Youth",
                    Priority = "Medium",
                    DateCreated = DateTime.Now
                });

                db.Events.Add(new Event
                {
                    Title = "Water Conservation Awareness",
                    Location = "Municipal Civic Centre",
                    Description =
                        "Learn practical ways to conserve water and support responsible water usage.",
                    EventDate = DateTime.Now.AddDays(10).Date.AddHours(11),
                    Category = "Environment",
                    Priority = "Medium",
                    DateCreated = DateTime.Now
                });

                db.Events.Add(new Event
                {
                    Title = "Small Business Support Day",
                    Location = "Municipal Business Centre",
                    Description =
                        "Local entrepreneurs can learn about available municipal support programmes.",
                    EventDate = DateTime.Now.AddDays(14).Date.AddHours(9),
                    Category = "Business",
                    Priority = "Low",
                    DateCreated = DateTime.Now
                });

                db.Events.Add(new Event
                {
                    Title = "Community Safety Meeting",
                    Location = "Ward Community Centre",
                    Description =
                        "Residents can discuss local safety concerns and community initiatives.",
                    EventDate = DateTime.Now.AddDays(18).Date.AddHours(14),
                    Category = "Safety",
                    Priority = "High",
                    DateCreated = DateTime.Now
                });

                db.Announcements.Add(new Announcement
                {
                    Title = "Scheduled Water Maintenance",
                    Message =
                        "Residents are advised that scheduled maintenance may temporarily affect water services.",
                    Category = "Water",
                    Priority = "High",
                    DatePublished = DateTime.Now,
                    IsActive = true
                });

                db.Announcements.Add(new Announcement
                {
                    Title = "Municipal Offices Operating Hours",
                    Message =
                        "Municipal offices will operate during normal working hours unless otherwise announced.",
                    Category = "General",
                    Priority = "Medium",
                    DatePublished = DateTime.Now.AddDays(-1),
                    IsActive = true
                });

                db.Announcements.Add(new Announcement
                {
                    Title = "Community Participation Notice",
                    Message =
                        "Residents are encouraged to participate in upcoming community programmes and activities.",
                    Category = "Community",
                    Priority = "Low",
                    DatePublished = DateTime.Now.AddDays(-2),
                    IsActive = true
                });

                db.SaveChanges();
            }
        }
    }
}