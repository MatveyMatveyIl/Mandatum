using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mandatum.Models
{
    public class BoardModel
    {
        public Guid Id { get; set; }
        public bool Privacy { get; set; }
        public BoardFormat Format { get; set; }
        
        [Required(ErrorMessage = "Введите имя доски")]
        public string Name { get; set; }
        public IEnumerable<IBoardFormat> BoardFormats { get; set; } 
    }

    public enum BoardFormat
    {
        KanbanBoard,
        Table
    }
}