using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentUnion0105.Models
{
    public class SuFrontCalendarEventCalendarModel
    {
        public int ProcessId { get; set; }
        public int StepId { get; set; }
        [Key]
        public int ProcessFieldId { get; set; }
        public DateTime DateTimeValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public int ProcessTemplateFieldId { get; set; }
        public int ProcessTemplateFieldTypeId { get; set; }
        public DateTime MainDate { get; set; }
        public int ProcessTemplateStepTypeId { get; set; }
    }
    public class SuFrontCalendarEventCalendarModelWithAdditionalInfo
    {
        //public List<SuFrontCalendarEventsPerDay> EventsPerDay { get; set; }
                public List<SuFrontCalendarEventCalendarModel> Events { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthName { get; set; }
        public int StartDay { get; set; }
        public int EndDay { get; set; }

    }
    public class SuFrontCalendarEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
    }
    public class SuFrontCalendarEventsPerDay
    {
        public int Id { get; set; }

        public List<SuFrontCalendarEvent> Events { get; set; }
    }

}
