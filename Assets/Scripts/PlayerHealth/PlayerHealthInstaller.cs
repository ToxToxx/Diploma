using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerHealthController>().AsSingle().NonLazy();
        Container.Bind<PlayerHealthView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerHealthModel>().AsSingle().WithArguments(100).NonLazy();
    }
}
