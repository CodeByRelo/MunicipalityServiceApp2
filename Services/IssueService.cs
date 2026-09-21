using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MunicipalityServiceApp2.Data;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.Services
{
    public class IssueService
    {
        public Issue CreateIssue(
            string location,
            string category,
            string description,
            string attachmentPath = null)
        {
            using (var db = new MunicipalityDbContext())
            {
                var issue = new Issue
                {
                    Location = location,
                    Category = category,
                    Description = description,
                    AttachmentPath = attachmentPath,
                    Status = "Pending",
                    DateReported = DateTime.Now
                };

                db.Issues.Add(issue);
                db.SaveChanges();

                return issue;
            }
        }


        public List<Issue> GetAllIssues()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues
                    .OrderByDescending(i => i.DateReported)
                    .ToList();
            }
        }


        public List<Issue> GetRecentIssues(int count)
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues
                    .OrderByDescending(i => i.DateReported)
                    .Take(count)
                    .ToList();
            }
        }


        public Issue GetIssueById(int id)
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues
                    .FirstOrDefault(i => i.Id == id);
            }
        }


        public int GetTotalIssues()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues.Count();
            }
        }


        public int GetActiveIssues()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues.Count(i =>
                    i.Status == "Pending" ||
                    i.Status == "In Progress");
            }
        }


        public int GetResolvedIssues()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Issues.Count(i =>
                    i.Status == "Resolved");
            }
        }


        public bool UpdateIssueStatus(
            int issueId,
            string newStatus)
        {
            string[] validStatuses =
            {
                "Pending",
                "In Progress",
                "Resolved"
            };

            if (!validStatuses.Contains(newStatus))
            {
                return false;
            }

            using (var db = new MunicipalityDbContext())
            {
                Issue issue = db.Issues
                    .FirstOrDefault(i =>
                        i.Id == issueId);

                if (issue == null)
                {
                    return false;
                }

                issue.Status = newStatus;

                db.SaveChanges();

                return true;
            }
        }
    }
}