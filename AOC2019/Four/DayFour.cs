using AOC2019.Four.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Four
{
    public class DayFour
    {
        private const string Guard = "Guard";
        private const string Falls = "falls";
        private const string Wakes = "wakes";

        public int CalculatePartOne(IEnumerable<string> rows)
        {
            var records = BuildOrderedRecordSet(rows);

            var napMinutes = BuildNapMinutes(records);

            var mostNappingGuardId = CalculateMostNappingGuardId(napMinutes);

            var mostNappedMinuteForMostNappedGuard = CalculateMostNappedMinuteForGuardId(napMinutes, mostNappingGuardId);

            return mostNappingGuardId * mostNappedMinuteForMostNappedGuard;
        }
        
        public int CalculatePartTwo(IEnumerable<string> rows)
        {
            var records = BuildOrderedRecordSet(rows);

            var napMinutes = BuildNapMinutes(records);

            var mostCommonNapMinute = CalculateMostCommonMinuteGuardCombination(napMinutes);

            return mostCommonNapMinute.GuardId * mostCommonNapMinute.Minute;
        }

        public DayFourRecord ParseRecord(string input)
        {
            var splitInput = input.Split('[', ']');

            var dateTime = DateTime.Parse(splitInput[1]);
            var content = splitInput[2].TrimStart();

            var eventType = EventType.BeginShift;
            int? guardId = null;

            if (content.StartsWith(Guard))
            {
                eventType = EventType.BeginShift;
                guardId = int.Parse(content.Split(' ')[1].Replace("#", ""));
            }
            else if (content.StartsWith(Falls))
            {
                eventType = EventType.FallsAsleep;
            }
            else
            {
                eventType = EventType.WakesUp;
            }

            return new DayFourRecord()
            {
                DateTime = dateTime,
                EventType = eventType,
                GuardId = guardId,            
            };
        }

        public IEnumerable<DayFourRecord> BuildOrderedRecordSet(IEnumerable<string> rows)
        {
            return rows.Select(ParseRecord).OrderBy(r => r.DateTime);
        }

        public IEnumerable<NapMinute> BuildNapMinutes(IEnumerable<DayFourRecord> records)
        {
            var currentGuard = 0;
            var napStart = 0;

            var napMinutes = new List<NapMinute>();

            foreach(var record in records)
            {
                if (record.EventType == EventType.BeginShift)
                {
                    currentGuard = record.GuardId.Value;
                }

                if (record.EventType == EventType.FallsAsleep)
                {
                    napStart = record.DateTime.Minute;
                }

                if (record.EventType == EventType.WakesUp)
                {
                    var napEnd = record.DateTime.Minute;

                    var currentNapMinutes = Enumerable.Range(napStart, napEnd - napStart).Select(m => new NapMinute() { GuardId = currentGuard, Minute = m });

                    napMinutes.AddRange(currentNapMinutes);
                }
            }

            return napMinutes;
        }

        private int CalculateMostNappingGuardId(IEnumerable<NapMinute> napMinutes)
        {
            return napMinutes.GroupBy(nm => nm.GuardId).OrderByDescending(g => g.Count()).First().Key;
        }

        private int CalculateMostNappedMinuteForGuardId(IEnumerable<NapMinute> napMinutes, int guardId)
        {
            return napMinutes
                .Where(nm => nm.GuardId == guardId)
                .GroupBy(nm => nm.Minute)
                .OrderByDescending(g => g.Count())
                .First().Key;
        }      
        
        private NapMinute CalculateMostCommonMinuteGuardCombination(IEnumerable<NapMinute> napMinutes)
        {
            return napMinutes.GroupBy(nm => new { nm.GuardId, nm.Minute }).OrderByDescending(g => g.Count()).Select(g => new NapMinute() { GuardId = g.Key.GuardId, Minute = g.Key.Minute }).First();
        }
    }
}
