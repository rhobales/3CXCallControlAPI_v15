using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("set_office_hours")]
    [SampleWarning("This sample modifies office hours on PBX and sets them to Monday-Friday 8:00 - 17:00 as office time, and 13:00-14:00 as office BreakTime")]
    [SampleDescription("Shows how to setup 'Office Hours' of PBX")]
    class SetOfficeHoursSample : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            Tenant tenant = ps.GetTenants()[0];
            if (tenant != null)
            {
                var officeHours = new Schedule(PhoneSystem.Root.GetRuleHourTypeByType(RuleHoursType.SpecificHours));
                officeHours.Add(DayOfWeek.Monday, new Schedule.PeriodOfDay(TimeSpan.Parse("8:00"), TimeSpan.Parse("17:00")));
                officeHours.Add(DayOfWeek.Tuesday, new Schedule.PeriodOfDay(TimeSpan.Parse("8:00"), TimeSpan.Parse("17:00")));
                officeHours.Add(DayOfWeek.Wednesday, new Schedule.PeriodOfDay(TimeSpan.Parse("8:00"), TimeSpan.Parse("17:00")));
                officeHours.Add(DayOfWeek.Thursday, new Schedule.PeriodOfDay(TimeSpan.Parse("8:00"), TimeSpan.Parse("17:00")));
                officeHours.Add(DayOfWeek.Friday, new Schedule.PeriodOfDay(TimeSpan.Parse("8:00"), TimeSpan.Parse("17:00")));

                var breakTime = new Schedule(PhoneSystem.Root.GetRuleHourTypeByType(RuleHoursType.SpecificHours));
                breakTime.Add(DayOfWeek.Monday, new Schedule.PeriodOfDay(TimeSpan.Parse("13:00"), TimeSpan.Parse("14:00")));
                breakTime.Add(DayOfWeek.Tuesday, new Schedule.PeriodOfDay(TimeSpan.Parse("13:00"), TimeSpan.Parse("14:00")));
                breakTime.Add(DayOfWeek.Wednesday, new Schedule.PeriodOfDay(TimeSpan.Parse("13:00"), TimeSpan.Parse("14:00")));
                breakTime.Add(DayOfWeek.Thursday, new Schedule.PeriodOfDay(TimeSpan.Parse("13:00"), TimeSpan.Parse("14:00")));
                breakTime.Add(DayOfWeek.Friday, new Schedule.PeriodOfDay(TimeSpan.Parse("13:00"), TimeSpan.Parse("14:00")));

                //Office hours
                tenant.Hours = officeHours;
                tenant.BreakTime = breakTime;
                tenant.Save();

            }
        }
    }
}