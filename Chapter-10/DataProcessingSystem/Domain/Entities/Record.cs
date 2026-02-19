namespace DataProcessingSystem.Domain.Entities
{
    public class Record
    {
        public string Id { get; }
        public string Name { get; private set; }
        public double Value { get; }
        public DateTime? Date { get; }

        public Record(string id, string name, double value, DateTime? date)
        {
            Id = id;
            Name = name;
            Value = value;
            Date = date;
        }

        public void TransformNameToUpper()
        {
            Name = Name?.ToUpper();
        }

        public double DoubledValue => Value * 2;
        public double SquaredValue => Value * Value;
    }
}
