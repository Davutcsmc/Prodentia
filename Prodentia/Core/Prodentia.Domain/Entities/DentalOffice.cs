using Prodentia.Domain.Exceptions;

namespace Prodentia.Domain.Entities
{
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public DentalOffice(string name)
        {
            EnforceBusinessRules(name);
            Name = name;
            Id = Guid.CreateVersion7();
        }

        public void UpdateName(string name)
        {
            EnforceBusinessRules(name);
            Name = name;
        }

        private void EnforceBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }
        }

    }
}
