using System.Collections.Generic;

namespace App.Scripts.Core
{
    // GenericInterface for storing objects 
    public interface IObjectRegistry<T>
    {
        public IEnumerable<T> GetRegistry();
        public void AddObject(T regObject);
        public void RemoveObject(T regObject);
        public bool TryGetRandomObject(out T regObject);
    }
}