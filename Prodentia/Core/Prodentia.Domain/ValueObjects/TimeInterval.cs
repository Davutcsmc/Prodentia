using Prodentia.Domain.Exceptions;

namespace Prodentia.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new BusinessRuleException("Start time cannot be later than end time");
            }

            Start = startTime;
            End = endTime;
        }
    }
}
