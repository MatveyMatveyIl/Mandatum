using System;

namespace Mandatum.Models
{
    public class BoardModel
    {
        public Guid Id { get; set; }
        public bool Privacy { get; set; }
        public BoardFormat Format { get; set; }
        public string Name { get; set; }
    }

    public enum BoardFormat
    {
        KanbanBoard,
        Graph,
        Table
    }
}