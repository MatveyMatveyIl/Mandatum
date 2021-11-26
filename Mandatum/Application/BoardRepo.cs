using System.Collections.Generic;
using System.IO;
using NReco.Csv;

namespace Application
{
    public class BoardRepo
    {
        private readonly AbstractRepo repo;

        public BoardRepo(AbstractRepo repo)
        {
            this.repo = repo;
        }

        public IEnumerable<BoardRecord> Start()
        {
            var data = repo.GetData("test.csv", csvReader => new BoardRecord(csvReader[0], csvReader[1]));
            
            
            return data;
        }
    }
}