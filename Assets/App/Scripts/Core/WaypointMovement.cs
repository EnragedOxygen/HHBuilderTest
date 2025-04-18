using System;
using App.Scripts.Core;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private IPointerProcessor _pointerInputs;
    
    // TODO Replace with a proper Command pattern
    private Action _destinationAction;
    
    private bool _performedDestinationAction = false;
    
    
    [Inject]
    private void Construction(IPointerProcessor pointerProcessor)
    {
        // Later could be replaced with ObjectContext injection
        _pointerInputs = pointerProcessor;
    }
        
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    
    
    // TODO separate class into two, one responsible for movement, and another for actions
    // This realisation is less than optimal, but it's easy to replace when GDD is finalised
    private void Update()
    {
        if (_pointerInputs.ClickedThisFrame())
        {
            if (_pointerInputs.GetClickedProduction(out IClickableProduction production))
            {
                _agent.SetDestination(production.GetAgentDestination());
                _destinationAction = production.DestinationAction();
                _performedDestinationAction = false;
            }
            else
            {
                _destinationAction = null;
                _agent.SetDestination(_pointerInputs.GetScreenToWorldPosition());
            }
        }
        
        // Crude Test implementation before Command is implemented
        if (!_performedDestinationAction && Vector3.Distance(_agent.destination, transform.position) <= 1f  & _destinationAction != null )
        {
            _destinationAction?.Invoke();  
            _performedDestinationAction = true;
        }
    }
}
