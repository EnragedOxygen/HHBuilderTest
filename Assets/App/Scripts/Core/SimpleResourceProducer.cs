using System;
using UnityEngine;
using Zenject;

namespace App.Scripts.Core
{
    public class SimpleResourceProducer : BaseResourceProducer
    {
        public SimpleResourceProducer(GameResources resourceType, int producedAmount) : base(resourceType, producedAmount)
        {
            
        }
        
        public override void Produce()
        {
            Debug.Log($"Produced {ProducedAmount} {ProducedResource.ToString()}");
            _resourceManager.UpdateResource(ProducedResource,ProducedAmount);
        }

        public class Factory : PlaceholderFactory<GameResources, int, SimpleResourceProducer>
        {
            
        }
    }
}