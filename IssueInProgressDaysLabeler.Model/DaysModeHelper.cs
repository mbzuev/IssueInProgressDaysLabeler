using System;
using System.Collections.Generic;
using IssueInProgressDaysLabeler.Model.Extensions;
using Mindbox.WorkingCalendar;

namespace IssueInProgressDaysLabeler.Model
{
    internal class DaysModeHelper : IDaysModeHelper
    {
        private readonly WorkingCalendar _workingCalendar;
        private readonly DaysMode _daysMode;

        public DaysModeHelper(DaysMode daysMode)
        {
            _daysMode = daysMode;
            _workingCalendar = new WorkingCalendar(new Dictionary<DateTime, DayType>());
        }

        public bool IsSuitableDay(DateTime dateTime)
        {
            switch (_daysMode)
            {
                case DaysMode.EveryDay:
                    return true;
                case DaysMode.EveryDayExceptWeekend:
                    return dateTime.IsWorkingDay();
                case DaysMode.RussianCalendar:
                    return _workingCalendar.IsWorkingDay(dateTime);
                default:
                    throw new ArgumentOutOfRangeException(nameof(_daysMode));
            }
        }
    }
}