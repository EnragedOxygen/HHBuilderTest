using System;
using UnityEngine;

namespace App.Scripts.Core
{
    // This interface name is misleading, might require fixing later
    public interface IClickableProduction
    {
        //Get NMAgent destination for DemoPurposes
        public Vector3 GetAgentDestination();

        // Action to complete upon reaching destination
        public Action DestinationAction();
    }
}