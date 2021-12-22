namespace Mandatum.Models
{
    public interface IBoardFormat
    {
        BoardFormat Format { get; set; }
        string Image { get; set; }
        string Label { get; set; }
    }
}