using System.Collections.Generic;
using Application;
using Application.Entities;
using Mandatum.Models;
using BoardFormatRecord = Application.Entities.BoardFormat;
using BoardFormatModel = Mandatum.Models.BoardFormat;

namespace Mandatum.Convertors
{
    public class BoardConverterUILayer: IConverter<BoardRecord, BoardModel>
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
                BoardFormatRecord.Table => BoardFormatModel.Table,
            };
        }
        
        private BoardFormatRecord ConvertRecordFormat(BoardFormatModel format)
        {
            return format switch
            {
                BoardFormatModel.KanbanBoard => BoardFormatRecord.KanbanBoard,
                BoardFormatModel.Table => BoardFormatRecord.Table,
            };
        }
    }
}