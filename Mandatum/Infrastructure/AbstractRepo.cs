using System;

namespace Infrastructure
{
    public class AbstractRepo
    {
        public T GetData<T>(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveData<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}