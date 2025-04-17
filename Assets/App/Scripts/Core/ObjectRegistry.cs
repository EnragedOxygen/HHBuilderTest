using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Core
{
    public class ObjectRegistry<T> : IObjectRegistry<T>
    {
        protected List<T> _registry = new();

        public IEnumerable<T> GetRegistry()
        {
            return _registry;
        }

        public virtual void AddObject(T regObject)
        {
            _registry.Add(regObject);
        }

        public virtual void RemoveObject(T regObject)
        {
            _registry.Remove(regObject);
        }

        public virtual bool TryGetRandomObject(out T regObject)
        {
            regObject = default;

            if (_registry.Count > 0)
            {
                regObject = _registry[Random.Range(0, _registry.Count)];
                return true;
            }

            return false;
        }
    }
}