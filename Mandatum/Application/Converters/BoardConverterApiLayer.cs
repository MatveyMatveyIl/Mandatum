using System.Linq;
using Domain;
using Mandatum.Convertors;
using Mandatum.Models;

namespace Application.Converters
{
    public class BoardConverterApiLayer: IConverter<BoardRecord, Board>
    {
        private readonly TaskConverterAppLayer _taskConverter;
        private readonly AppDbContext _dbContext;
        public BoardConverterApiLayer(TaskConverterAppLayer taskConverter, AppDbContext dbContext)
        {
            _taskConverter = taskConverter;
            _dbContext = dbContext;
        }

        public BoardRecord Convert(Board source)
        {
            var boardRecord = _dbContext.Boards.FirstOrDefault(b => b.Id == source.Id);
            if(boardRecord is null)
                return new BoardRecord()
                {
                    Id = source.Id,
                    Format = ConvertRecordFormat(source.Format),
                    Privacy = source.Privacy,
                    Name = source.Name,
                    TaskIds = _taskConverter.Converts(source.Tasks).ToList(),
                };
            boardRecord.Name = source.Name;
            boardRecord.TaskIds = _taskConverter.Converts(source.Tasks).ToList();
            return boardRecord;
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