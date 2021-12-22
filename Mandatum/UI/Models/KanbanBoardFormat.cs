namespace Mandatum.Models
{
    public class KanbanBoardFormat : IBoardFormat
    {
        public BoardFormat Format { get; set; } = BoardFormat.KanbanBoard;
        public string Image { get; set; } = "KanbanBoard";
        public string Label { get; set; } = "Канбан доска";
    }
}