using System.Collections.Generic;
using Application;
using Mandatum.Models;
using BoardFormatRecord = Application.BoardFormat;
using BoardFormatModel = Mandatum.Models.BoardFormat;

namespace Mandatum.Convertors
{
    public class BoardModelConverter: IConverter<BoardRecord, BoardModel>
    {
        public BoardRecord Convert(BoardModel source)
        {
            return new BoardRecord()
            {
                Id = source.Id,
                Format = ConvertRecordFormat(source.Format),
                Privacy = source.Privacy,
                Name = source.Name
            };
        }

        public BoardModel Convert(BoardRecord source)
        {
            return new BoardModel()
            {
                Id = source.Id,
                Format = ConvertModelFormat(source.Format),
                Privacy = source.Privacy,
                Name = source.Name
            };
        }
        
        public IEnumerable<BoardModel> Convert(IEnumerable<BoardRecord> records)
        {
            foreach (var record in records)
            {
                yield return Convert(record);
            }
        }

        private BoardFormatModel ConvertModelFormat(BoardFormatRecord format)
        {
            return format switch
            {
                BoardFormatRecord.KanbanBoard => BoardFormatModel.KanbanBoard,
                BoardFormatRecord.Graph => BoardFormatModel.Graph,
            };
        }
        
        private BoardFormatRecord ConvertRecordFormat(BoardFormatModel format)
        {
            return format switch
            {
                BoardFormatModel.KanbanBoard => BoardFormatRecord.KanbanBoard,
                BoardFormatModel.Graph => BoardFormatRecord.Graph,
            };
        }
    }
}