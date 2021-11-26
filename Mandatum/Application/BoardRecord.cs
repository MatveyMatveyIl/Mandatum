namespace Application
{
    public class BoardRecord
    {
        public string Id { get; }
        public string Name { get; }

        public BoardRecord(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}