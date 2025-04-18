using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace App.Scripts.Core
{
    public class ClickableResourceProduction : MonoBehaviour, IClickableProduction
    {
        IResourceProducer _resourceProducer;
        
        [SerializeField]
        private Transform interactionPoint;

        [SerializeField] private TextMeshProUGUI text;

        [Inject]
        public void Construction(IResourceProducer resourceProducer)
        {
            _resourceProducer = resourceProducer;
            text.SetText($"Resource: {_resourceProducer.ProducedResource.ToString()} \n Production: {_resourceProducer.ProducedAmount.ToString()}");
        }

        public Vector3 GetAgentDestination()
        {
            Debug.Log($"Setting Destination to {interactionPoint.position}");
            return interactionPoint.position;
        }

        public Action DestinationAction()
        {
            return () =>
            {
                Debug.Log($"{name} produced resources", this);
                _resourceProducer.Produce();
            };
        }
    }
}