namespace Mandatum.Models
{
    public class TableBoardFormat : IBoardFormat
    {
        public BoardFormat Format { get; set; } = BoardFormat.Table;
        public string Image { get; set; } = "Table";
        public string Label { get; set; } = "Таблица";
    }
}