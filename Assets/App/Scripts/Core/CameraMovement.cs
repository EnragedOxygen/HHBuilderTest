using System;
using App.Scripts.Core;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    // Simple implementation with dragSpeed is enough for this Demo
    [SerializeField]
    private float dragSpeed = 0.1f;

    private IPointerProcessor _pointerInputs;
    
    [Inject]
    private void Construction(IPointerProcessor processor)
    {
        _pointerInputs = processor;
    }

    private void Update()
    {
        Vector2 dragDelta = _pointerInputs.GetDragDelta() * dragSpeed;
        Vector3 cameraDelta = new Vector3(dragDelta.x, 0, dragDelta.y);
        transform.position += cameraDelta;
    }
}
