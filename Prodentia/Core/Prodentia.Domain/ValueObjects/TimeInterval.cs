using Prodentia.Domain.Exceptions;

namespace Prodentia.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("Start time cannot be later than end time");
            }

            Start = start;
            End = end;
        }
    }
}
