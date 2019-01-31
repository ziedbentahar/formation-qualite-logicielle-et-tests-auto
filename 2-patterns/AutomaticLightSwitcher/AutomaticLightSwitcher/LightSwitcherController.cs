using System;

namespace AutomaticLightSwitcher
{
    public interface IDateTimeWrapper
    {
        DateTime Now { get; }
    }

    public sealed class RuntimeDateTime : IDateTimeWrapper
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }


    class LightSwitcherController
    {
        private readonly IDateTimeWrapper _dateTimeWrapper;

        public LightSwitcherController(IDateTimeWrapper dateTimeWrapper)
        {
            _dateTimeWrapper = dateTimeWrapper;
        }

        public void Actuate()
        {
            var dateTime = _dateTimeWrapper.Now;

            var timeOfTheDay = GetTimeOfTheDay(dateTime);

            if (timeOfTheDay == "Night" && timeOfTheDay == "Evening" && !LightSwitcher.Instance.IsTurnedOn)
            {
                LightSwitcher.Instance.TurnOn();
            }
            else
            {
                LightSwitcher.Instance.TurnOff();
            }
        }

        private string GetTimeOfTheDay(DateTime dateTime)
        {
            if (dateTime.Hour >= 0 && dateTime.Hour < 6)
            {
                return "Night";
            }
            if (dateTime.Hour >= 6 && dateTime.Hour < 12)
            {
                return "Morning";
            }
            if (dateTime.Hour >= 12 && dateTime.Hour < 18)
            {

                return "Noon";
            }
            return "Evening";
        }
    }
}
