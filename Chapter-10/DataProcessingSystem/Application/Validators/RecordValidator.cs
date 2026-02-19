using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;

namespace DataProcessingSystem.Application.Validators
{
    public class RecordValidator : IValidator<Record>
    {
        public bool IsValid(Record record, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(record.Id))
            {
                errorMessage = "Missing Id";
                return false;
            }

            if (string.IsNullOrWhiteSpace(record.Name))
            {
                errorMessage = $"Record {record.Id} missing name";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }

}
