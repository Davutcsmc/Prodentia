using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;

namespace Prodentia.Domain.Entities
{
    public class Patient
    {
        public Patient()
        {
            
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Patient(string name, Email email)
        {
            EnforceNameBusinessRules(name);
            EnforceEmailBusinessRules(email);
                        
            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }

        public void UpdateName(string name) 
        {
            EnforceNameBusinessRules(name);
            Name = name;
        }

        private void EnforceNameBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }
        }
        public void UpdateEmail(Email email)
        {
            EnforceEmailBusinessRules(email);
            Email = email;
        }

        private void EnforceEmailBusinessRules(Email email)
        {
            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }
        }
    }
}
