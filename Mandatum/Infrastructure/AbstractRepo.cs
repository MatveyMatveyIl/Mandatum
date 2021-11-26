using System;
using System.Collections.Generic;
using System.IO;
using Infrastructure;
using NReco.Csv;

namespace Application
{
    public class AbstractRepo
    {
        private readonly IRepoConfig _path;

        public AbstractRepo(IRepoConfig path)
        {
            _path = path;
        }

        public IEnumerable<T> GetData<T>(string filename, Func<CsvReader, T> func)
        {
            using (FileStream fsSource = new FileStream(_path.filePath + filename,
                FileMode.Open, FileAccess.Read))
            using (var streamRdr = new StreamReader(fsSource)) {
                var csvReader = new CsvReader(streamRdr, ";");
                while (csvReader.Read())
                {
                    yield return func(csvReader);
                }
            }
        }
    }
}