using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MunicipalityServiceApp2.Data;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.Services
{
    public class EventService
    {
        // ============================================================
        // DATABASE OPERATIONS
        // ============================================================

        public List<Event> GetAllEvents()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Events
                    .OrderBy(e => e.EventDate)
                    .ToList();
            }
        }

        public List<Event> GetUpcomingEvents()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Events
                    .Where(e => e.EventDate >= DateTime.Now)
                    .OrderBy(e => e.EventDate)
                    .ToList();
            }
        }

        public Event GetEventById(int id)
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Events
                    .FirstOrDefault(e => e.Id == id);
            }
        }

        public List<Announcement> GetActiveAnnouncements()
        {
            using (var db = new MunicipalityDbContext())
            {
                return db.Announcements
                    .Where(a => a.IsActive)
                    .OrderByDescending(a => a.DatePublished)
                    .ToList();
            }
        }

        // ============================================================
        // 1. SORTED DICTIONARY
        // Organises events chronologically by date.
        // ============================================================

        public SortedDictionary<DateTime, List<Event>>
            BuildEventsByDate(List<Event> events)
        {
            var eventsByDate =
                new SortedDictionary<DateTime, List<Event>>();

            foreach (Event currentEvent in events)
            {
                DateTime date = currentEvent.EventDate.Date;

                if (!eventsByDate.ContainsKey(date))
                {
                    eventsByDate[date] = new List<Event>();
                }

                eventsByDate[date].Add(currentEvent);
            }

            return eventsByDate;
        }

        // ============================================================
        // 2. DICTIONARY
        // Organises events by category for fast retrieval.
        // ============================================================

        public Dictionary<string, List<Event>>
            BuildEventsByCategory(List<Event> events)
        {
            var eventsByCategory =
                new Dictionary<string, List<Event>>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (Event currentEvent in events)
            {
                string category = currentEvent.Category;

                if (string.IsNullOrWhiteSpace(category))
                {
                    category = "Other";
                }

                if (!eventsByCategory.ContainsKey(category))
                {
                    eventsByCategory[category] =
                        new List<Event>();
                }

                eventsByCategory[category].Add(currentEvent);
            }

            return eventsByCategory;
        }

        // ============================================================
        // 3. HASH SET
        // Stores unique event categories.
        // ============================================================

        public HashSet<string>
            GetUniqueCategories(List<Event> events)
        {
            var categories =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (Event currentEvent in events)
            {
                if (!string.IsNullOrWhiteSpace(
                    currentEvent.Category))
                {
                    categories.Add(currentEvent.Category);
                }
            }

            return categories;
        }

        // ============================================================
        // 4. HASH SET
        // Stores unique event dates.
        // ============================================================

        public HashSet<DateTime>
            GetUniqueDates(List<Event> events)
        {
            var dates = new HashSet<DateTime>();

            foreach (Event currentEvent in events)
            {
                dates.Add(currentEvent.EventDate.Date);
            }

            return dates;
        }

        // ============================================================
        // 5. QUEUE
        // Stores upcoming events in chronological order.
        // ============================================================

        public Queue<Event>
            BuildUpcomingEventQueue(List<Event> events)
        {
            var queue = new Queue<Event>();

            List<Event> upcomingEvents = events
                .Where(e => e.EventDate >= DateTime.Now)
                .OrderBy(e => e.EventDate)
                .ToList();

            foreach (Event currentEvent in upcomingEvents)
            {
                queue.Enqueue(currentEvent);
            }

            return queue;
        }

        // ============================================================
        // 6. PRIORITY QUEUE
        // .NET Framework 4.8 does not have the modern PriorityQueue
        // class, so we implement a simple priority queue ourselves.
        // ============================================================

        public List<Event> BuildPriorityQueue(
            List<Event> events)
        {
            return events
                .OrderBy(e => GetPriorityValue(e.Priority))
                .ThenBy(e => e.EventDate)
                .ToList();
        }

        private int GetPriorityValue(string priority)
        {
            switch (priority)
            {
                case "High":
                    return 1;

                case "Medium":
                    return 2;

                case "Low":
                    return 3;

                default:
                    return 4;
            }
        }

        // ============================================================
        // SEARCH BY CATEGORY
        // ============================================================

        public List<Event> SearchByCategory(
            List<Event> events,
            string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return events;
            }

            return events
                .Where(e =>
                    e.Category != null &&
                    e.Category.Equals(
                        category,
                        StringComparison.OrdinalIgnoreCase))
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        // ============================================================
        // SEARCH BY DATE
        // ============================================================

        public List<Event> SearchByDate(
            List<Event> events,
            DateTime date)
        {
            return events
                .Where(e =>
                    e.EventDate.Date == date.Date)
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        // ============================================================
        // SEARCH BY CATEGORY + DATE
        // ============================================================

        public List<Event> SearchEvents(
            List<Event> events,
            string category,
            DateTime? date)
        {
            IEnumerable<Event> results = events;

            if (!string.IsNullOrWhiteSpace(category))
            {
                results = results.Where(e =>
                    e.Category != null &&
                    e.Category.Equals(
                        category,
                        StringComparison.OrdinalIgnoreCase));
            }

            if (date.HasValue)
            {
                results = results.Where(e =>
                    e.EventDate.Date ==
                    date.Value.Date);
            }

            return results
                .OrderBy(e => e.EventDate)
                .ToList();
        }
    }
}