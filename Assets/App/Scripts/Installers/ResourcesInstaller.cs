using System;
using System.ComponentModel;
using App.Scripts.Core;
using UnityEngine;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{

    private int _producersGenerated = 0;
    
    public override void InstallBindings()
    {
        InstallResources();
    }
    
    void InstallResources()
    {
        Container.BindInterfacesAndSelfTo<BasicResourceManager>().AsSingle();
        Container.Bind<IObjectRegistry<IResourceProducer>>().FromInstance(new ResourceBuildingsRegistry()).AsSingle();

        Container.Bind<IResourceProducer>().FromMethod(GenerateProducer).AsTransient();
    }
    
    private IResourceProducer GenerateProducer()
    {
        var producer = new SimpleResourceProducer((GameResources)(_producersGenerated % Enum.GetValues(typeof(GameResources)).Length), ++_producersGenerated);
        Container.Inject(producer);
        return producer;
    }
}
