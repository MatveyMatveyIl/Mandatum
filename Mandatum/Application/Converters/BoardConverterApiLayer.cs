using System.Linq;
using Domain;
using Mandatum.Convertors;

namespace Application.Converters
{
    public class BoardConverterApiLayer: IConverter<BoardRecord, Board>
    {
        private readonly TaskConverterAppLayer _taskConverter;
        public BoardConverterApiLayer(TaskConverterAppLayer taskConverter)
        {
            _taskConverter = taskConverter;
        }

        public BoardRecord Convert(Board source)
        {
            return new BoardRecord()
            {
                Id = source.Id,
                Format = ConvertRecordFormat(source.Format),
                Privacy = source.Privacy,
                Name = source.Name,
                TaskIds = _taskConverter.Converts(source.Tasks).ToList()
            };
        }

        public Board Convert(BoardRecord source)
        {
            return new Board()
            {
                Id = source.Id,
                Format = ConvertDomainFormat(source.Format),
                Privacy = source.Privacy,
                Name = source.Name,
                Tasks = _taskConverter.Converts(source.TaskIds).ToList()
            };
        }
        
        private BoardFormatDomain ConvertDomainFormat(BoardFormat format)
        {
            return format switch
            {
                BoardFormat.KanbanBoard => BoardFormatDomain.KanbanBoard,
                BoardFormat.Table => BoardFormatDomain.Table,
            };
        }
        
        private BoardFormat ConvertRecordFormat(BoardFormatDomain format)
        {
            return format switch
            {
                BoardFormatDomain.KanbanBoard => BoardFormat.KanbanBoard,
                BoardFormatDomain.Table => BoardFormat.Table,
            };
        }
    }
}