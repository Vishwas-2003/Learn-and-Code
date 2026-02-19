using DataProcessingSystem.Domain.Entities;
using DataProcessingSystem.Domain.Interfaces;

namespace DataProcessingSystem.Application.Transformers
{
    public class RecordTransformer : ITransformer<Record>
    {
        public Record Transform(Record record)
        {
            record.TransformNameToUpper();
            return record;
        }
    }

}
