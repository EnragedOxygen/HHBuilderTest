using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace App.Scripts.Core
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField]
        private InputActionAsset inputAsset;

        [SerializeField]
        private string actionMap;
        
        public override void InstallBindings()
        {
            InstallControls();
        }
    
        void InstallControls()
        {
            Container.BindInstance(inputAsset);
            Container.BindInstance(actionMap);
            // Container.BindInterfacesAndSelfTo<IPointerProcessor>().FromInstance(new PointerProcessor(inputAsset, actionMap)).AsSingle();
            Container.Bind(typeof(IPointerProcessor), typeof(ITickable)).To<PointerProcessor>().AsSingle();
        }
    }
}