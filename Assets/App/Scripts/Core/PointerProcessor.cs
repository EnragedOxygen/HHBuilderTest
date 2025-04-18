using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace App.Scripts.Core
{
    public class PointerProcessor : IDisposable, ITickable, IPointerProcessor
    {
        // Simple solution for processing pointer inputs in a single place
        //Later would receive states to interact with UI or with Game ActionMaps only.
        // For now we use a single "Demo" action map for everything.
        
        private readonly InputActionMap _actionMap;

        private readonly InputAction _clickAction;
        
        private readonly InputAction _dragAction;

        private readonly InputAction _pointerPositionAction;
        
        
        private Vector2 _dragDelta;

        private Vector2 _pointerScreenPosition;

        private Vector3 _lastToWorldPosition;

        private IClickableProduction _lastClickedProduction;
        
        private bool _clickedThisFrame;
        
        private bool _clickedProductionThisFrame;
        
        public PointerProcessor(InputActionAsset inputAsset,string actionMapName)
        {
            _actionMap = inputAsset.FindActionMap(actionMapName);
            _actionMap.Enable();
            _clickAction = _actionMap.FindAction("Click");
            _dragAction = _actionMap.FindAction("Drag");
            _pointerPositionAction = _actionMap.FindAction("PointerPosition");
        }

        
        public void Tick()
        {
            ProcessMouseInputs();
        }
        
        private void ProcessMouseInputs()
        {
            _clickedThisFrame = _clickAction.triggered;
            _pointerScreenPosition = _pointerPositionAction.ReadValue<Vector2>();
            _dragDelta = _dragAction.ReadValue<Vector2>();
            _clickedProductionThisFrame = false;
            
            if (_clickedThisFrame)
            {
                // TODO Pass Camera Trough DI later. 
                Ray ray = Camera.main.ScreenPointToRay(_pointerScreenPosition);
                
                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out IClickableProduction clickableProduction))
                    {
                        Debug.Log($"Hit i clickable: {clickableProduction}");
                        _clickedProductionThisFrame = true;
                        _lastClickedProduction = clickableProduction;
                    }

                    if (hit.transform.CompareTag("Ground"))
                    {
                        _lastToWorldPosition = hit.point;
                        Debug.Log($"Hit ground: {_lastToWorldPosition}");
                    }
                }
            }
        }
        
        public void Dispose()
        {
            _actionMap.Disable();
        }

        public Vector3 GetScreenToWorldPosition()
        {
            return _lastToWorldPosition;
        }

        public bool ClickedThisFrame()
        {
            return _clickedThisFrame;
        }

        public Vector2 GetPosition()
        {
            return _pointerScreenPosition;
        }

        public Vector2 GetDragDelta()
        {
            return _dragDelta;
        }

        public bool GetClickedProduction(out IClickableProduction production)
        {
            production = _lastClickedProduction;
            return _clickedProductionThisFrame;
        }

        public IClickableProduction GetLastClickedProduction()
        {
            return _lastClickedProduction;
        }
    }
}