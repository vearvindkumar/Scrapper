using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Scheduler
{
	public enum ScheduleMode { Hourly=0, Daily=1, Weekly=2, FirstDayOfMonth=3, LastDayOfMonth=4, DayOfMonth=5, SpecificInterval=6 };
	public enum DateCompareState { Equal=0, Earlier=1, Later=2 };

	public class DateScheduler
	{

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Determines the number of days in the month portion of the specified date
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static int DaysInMonth(DateTime date)
		{
			return CultureInfo.InvariantCulture.Calendar.GetDaysInMonth(date.Year,date.Month);
		}

		public static bool IsLeapYear(DateTime date)
		{
			return CultureInfo.InvariantCulture.Calendar.IsLeapYear(date.Year);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Calculates the next trigger time, based on the current time, the process time, and the schedule mode.
		/// </summary>
		/// <param name="currentTime">The datetime on which to base the calculations</param>
		/// <param name="processTime">For hourly mode, only minutes are used, and for specificInterval mode, it represents the actual amount of time to use, but for all other modes indicates time of day (in all cases, seconds and milliseconds are ignored).</param>
		/// <param name="processMode">The mode with which to process the calculations</param>
		/// <returns></returns>
		public static DateTime CalculateNextTriggerTime(DateTime currentTime, TimeSpan processTime, ScheduleMode scheduleMode)
		{
			if (currentTime == null)
			{
				throw new Exception("Parameter 1 (currentTime) cannot be null");
			}

			// if the processTime object is null, throw an exception - You could 
			// alternately react to a null processTime by creating one with an 
			// appropriate default value, but I figured this would really serve no 
			// purpose in the grand scheme of things, so I didn't do it here.
			if (processTime == null)
			{
				throw new Exception("Parameter 2 (processTime) cannot be null");
			}
			DateTime nextTime = new DateTime();
			nextTime = currentTime;

			switch(scheduleMode)
			{
				case ScheduleMode.Hourly:
					{
						if (nextTime.Minute < processTime.Minutes)
						{
							nextTime = nextTime.AddMinutes(processTime.Minutes - nextTime.Minute);
						}
						else
						{
							// subtract the minutes, seconds, and milliseconds - this allows 
							// us to determine what the last hour was
							nextTime = nextTime.Subtract(new TimeSpan(0, 0, nextTime.Minute, nextTime.Second, nextTime.Millisecond));

							// add an hour and the number of minutes 
							nextTime = nextTime.Add(new TimeSpan(0, 1, processTime.Minutes, 0, 0));
						}
					}
					break;

				case ScheduleMode.Daily:
					{
						// subtract the hour, minutes, seconds, and milliseconds (essentially, makes it midnight of the current day)
						nextTime = nextTime.Subtract(new TimeSpan(0,nextTime.Hour,nextTime.Minute,nextTime.Second,nextTime.Millisecond));

						// add a day, and the number of hours:minutes after midnight
						nextTime = nextTime.Add(new TimeSpan(1,processTime.Hours,processTime.Minutes,0,0));
					}
					break;

				case ScheduleMode.Weekly:
					{
						int daysToAdd = 0;

						// get the number of the week day
						int dayNumber = (int)nextTime.DayOfWeek;

						// if the process day isn't today (should only happen when the service starts)
						if (dayNumber == processTime.Days)
						{
							// add 7 days
							daysToAdd = 7;
						}
						else
						{
							// determine where in the week we are
							// if the day number is > than the specified day
							if (dayNumber > processTime.Days)
							{
								// subtract the day number from 7 to get the number of days to add
								daysToAdd = 7 - dayNumber;
							}
							else
							{
								// otherwise, subtract the day number from the specified day
								daysToAdd = processTime.Days - dayNumber;
							}
						}

						// add the days
						nextTime = nextTime.AddDays(daysToAdd);

						// get rid of the seconds/milliseconds
						nextTime = nextTime.Subtract(new TimeSpan(0, nextTime.Hour, nextTime.Minute, nextTime.Second, nextTime.Millisecond));

						// add the specified time of day
						nextTime = nextTime.Add(new TimeSpan(0, processTime.Hours, processTime.Minutes, 0, 0));
					}
					break;

				case ScheduleMode.FirstDayOfMonth:
					{
						// detrmine how many days in the month
						int daysThisMonth = DaysInMonth(nextTime);

						// for ease of typing
						int today = nextTime.Day;

						// if today is the first day of the month
						if (today == 1)
						{
							// simply add the number of days in the month
							nextTime = nextTime.AddDays(daysThisMonth);
						}
						else
						{
							// otherwise, add the remaining days in the month
							nextTime = nextTime.AddDays((daysThisMonth - today) + 1);
						}
						// get rid of the seconds/milliseconds
						nextTime = nextTime.Subtract(new TimeSpan(0,nextTime.Hour,nextTime.Minute,nextTime.Second,nextTime.Millisecond));

						// add the specified time of day
						nextTime = nextTime.Add(new TimeSpan(0, processTime.Hours, processTime.Minutes, 0, 0));
					}
					break;

				case ScheduleMode.LastDayOfMonth:
					{
						// detrmine how many days in the month
						int daysThisMonth = DaysInMonth(nextTime);

						// for ease of typing
						int today = nextTime.Day;

						// if this is the last day of the month
						if (today == daysThisMonth)
						{
							// add the number of days for the next month
							int daysNextMonth = DaysInMonth(nextTime.AddDays(1));
							nextTime = nextTime.AddDays(daysNextMonth);
						}
						else
						{
							// otherwise, add the remaining days for this month
							nextTime = nextTime.AddDays(daysThisMonth - today);
						}

						// get rid of the seconds/milliseconds
						nextTime = nextTime.Subtract(new TimeSpan(0, nextTime.Hour, nextTime.Minute, nextTime.Second, nextTime.Millisecond));

						// add the specified time of day
						nextTime = nextTime.Add(new TimeSpan(0, processTime.Hours, processTime.Minutes, 0, 0));
					}
					break;

				// The processTime.Day property indicates what day of the month to 
				// schedule, and the hour/minute properties indicate the time of the day 
				case ScheduleMode.DayOfMonth:
					{
						// account for leap year
						// assume we don't have a leap day 
						int leapDay = 0;
						// if it's february, and a leap year and the day is 29
						if (nextTime.Month == 2 && !IsLeapYear(nextTime) && processTime.Days == 29)
						{
							// we have a leap day
							leapDay = 1;
						}

						// If the current day is earlier in the month than the desired day,
						// calculate how many days there are between the two
						int daysToAdd = 0;
						// if the current day is earlier than the desired day
						if (nextTime.Day < processTime.Days)
						{
							// add the difference (less the leap day)
							daysToAdd = processTime.Days - nextTime.Day - leapDay;
						}
						else
						{
							// otherwise, add the days not yet consumed (less the leap day)
							daysToAdd = (DaysInMonth(nextTime) - nextTime.Day) + processTime.Days - leapDay;
						}
						// add the calculated days
						nextTime = nextTime.AddDays(daysToAdd);

						// get rid of the seconds/milliseconds
						nextTime = nextTime.Subtract(new TimeSpan(0, nextTime.Hour, nextTime.Minute, nextTime.Second, nextTime.Millisecond));

						// add the specified time of day
						nextTime = nextTime.Add(new TimeSpan(0, processTime.Hours, processTime.Minutes, 0, 0));
					}
					break;

				case ScheduleMode.SpecificInterval:
					{
						// if we're past the 30-second mark, add a minute to the current time
						if (nextTime.Second >= 30)
						{
							nextTime = nextTime.AddSeconds(60 - nextTime.Second);
						}

						// since we don't care about seconds or milliseconds, zero these items out
						nextTime = nextTime.Subtract(new TimeSpan(0, 0, 0, nextTime.Second, nextTime.Millisecond));

						// now, we add the process time
						nextTime = nextTime.Add(processTime);
					}
					break;
			}

			// and subtract the seconds and milliseconds, just in case they were specified in the process time 
			nextTime = nextTime.Subtract(new TimeSpan(0, 0, 0, nextTime.Second, nextTime.Millisecond));

			return nextTime;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Convert the date to a 64-bit integer so we can do an accurate comparison.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static Int64 ConvertToInt64(DateTime date)
		{
			string dateStr = date.ToString("yyyyMMddHHmm");
			Int64 dateValue = Convert.ToInt64(dateStr);
			return dateValue;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Compare two datetime objects, but ignore the seconds and milliseconds parts.
		/// </summary>
		/// <param name="now"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		public static DateCompareState CompareDates(DateTime now, DateTime target)
		{
			DateCompareState state = DateCompareState.Equal;

			now = now.Subtract(new TimeSpan(0, 0, 0, now.Second, now.Millisecond));
			target = target.Subtract(new TimeSpan(0, 0, 0, target.Second, target.Millisecond));

			Int64 nowValue = ConvertToInt64(now);
			Int64 targetValue = ConvertToInt64(target);

			if (nowValue < targetValue)
			{
				state = DateCompareState.Earlier;
			}
			else
			{
				if (nowValue > targetValue)
				{
					state = DateCompareState.Later;
				}
			}

#if DEBUG
			// If you want to watch the comparison results in the output window during 
			// a debugging session, uncomment this line
			string traceFormat = "CompareDates({0}, {1}) - result = {2}";
			System.Diagnostics.Trace.WriteLine(string.Format(traceFormat, 
															now.ToString(), 
															target.ToString(), 
															state.ToString()));
#endif

			return state;
		}

	}

}
