using UnityEngine;

namespace App.Scripts.Core
{
    // Interface for Clicking at screen
    public interface IPointerProcessor
    {
        public Vector3 GetScreenToWorldPosition();
        public bool ClickedThisFrame();

        public Vector2 GetPosition();

        public Vector2 GetDragDelta();

        public bool GetClickedProduction(out IClickableProduction production);
        
        public IClickableProduction GetLastClickedProduction();

    }
}