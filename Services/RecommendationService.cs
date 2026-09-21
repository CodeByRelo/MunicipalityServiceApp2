using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.Services
{
    public class RecommendationService
    {
        // Stores how many times each category has been searched.
        private readonly Dictionary<string, int> searchPreferences =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // Stores individual search terms.
        private readonly Dictionary<string, int> searchKeywords =
            new Dictionary<string, int>(
                StringComparer.OrdinalIgnoreCase);

        // ---------------------------------------------------------
        // RECORD A SEARCH
        // ---------------------------------------------------------

        public void RecordSearch(
            string searchText,
            string category)
        {
            // Record category preference
            if (!string.IsNullOrWhiteSpace(category))
            {
                if (!searchPreferences.ContainsKey(category))
                {
                    searchPreferences[category] = 0;
                }

                searchPreferences[category]++;
            }

            // Record keyword preference
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string[] words = searchText
                    .Split(
                        new[] { ' ', ',', '.', '-', '_' },
                        StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    string keyword = word.Trim();

                    if (keyword.Length < 2)
                    {
                        continue;
                    }

                    if (!searchKeywords.ContainsKey(keyword))
                    {
                        searchKeywords[keyword] = 0;
                    }

                    searchKeywords[keyword]++;
                }
            }
        }

        // ---------------------------------------------------------
        // GET RECOMMENDATIONS
        // ---------------------------------------------------------

        public List<Event> GetRecommendations(
            List<Event> events,
            int numberOfRecommendations = 3)
        {
            if (events == null || events.Count == 0)
            {
                return new List<Event>();
            }

            List<EventScore> scoredEvents =
                new List<EventScore>();

            foreach (Event currentEvent in events)
            {
                int score = CalculateScore(currentEvent);

                if (score > 0)
                {
                    scoredEvents.Add(
                        new EventScore
                        {
                            Event = currentEvent,
                            Score = score
                        });
                }
            }

            return scoredEvents
                .OrderByDescending(e => e.Score)
                .ThenBy(e => e.Event.EventDate)
                .Take(numberOfRecommendations)
                .Select(e => e.Event)
                .ToList();
        }

        // ---------------------------------------------------------
        // CALCULATE EVENT SCORE
        // ---------------------------------------------------------

        private int CalculateScore(Event currentEvent)
        {
            int score = 0;

            // Category match
            if (!string.IsNullOrWhiteSpace(currentEvent.Category) &&
                searchPreferences.ContainsKey(
                    currentEvent.Category))
            {
                score +=
                    searchPreferences[currentEvent.Category] * 3;
            }

            // Search keyword matches
            foreach (KeyValuePair<string, int> keyword
                     in searchKeywords)
            {
                if (ContainsIgnoreCase(
                        currentEvent.Title,
                        keyword.Key))
                {
                    score += keyword.Value * 2;
                }

                if (ContainsIgnoreCase(
                        currentEvent.Description,
                        keyword.Key))
                {
                    score += keyword.Value * 2;
                }

                if (ContainsIgnoreCase(
                        currentEvent.Location,
                        keyword.Key))
                {
                    score += keyword.Value;
                }
            }

            // High-priority events receive a small boost.
            if (string.Equals(
                currentEvent.Priority,
                "High",
                StringComparison.OrdinalIgnoreCase))
            {
                score += 1;
            }

            return score;
        }

        // ---------------------------------------------------------
        // TEXT MATCHING
        // ---------------------------------------------------------

        private bool ContainsIgnoreCase(
            string source,
            string searchText)
        {
            if (string.IsNullOrWhiteSpace(source) ||
                string.IsNullOrWhiteSpace(searchText))
            {
                return false;
            }

            return source.IndexOf(
                searchText,
                StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // ---------------------------------------------------------
        // INTERNAL SCORE MODEL
        // ---------------------------------------------------------

        private class EventScore
        {
            public Event Event { get; set; }

            public int Score { get; set; }
        }
    }
}