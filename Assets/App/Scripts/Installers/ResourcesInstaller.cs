using System.ComponentModel;
using App.Scripts.Core;
using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        InstallResources();
    }
    
    void InstallResources()
    {
        Container.Bind<IResourceManager>().FromInstance(new BasicResourceManager()).AsSingle();
        Container.Bind<IObjectRegistry<IResourceFactory>>().FromInstance(new ResourceBuildingsRegistry()).AsSingle();
    }
}
