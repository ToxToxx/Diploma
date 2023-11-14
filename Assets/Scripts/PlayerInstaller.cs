using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       BindPlayerHealth();
    }

    private void BindPlayerHealth()
    {
        Container.BindInterfacesAndSelfTo<PlayerHealthController>().AsSingle().NonLazy();
        Container.Bind<PlayerHealthView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerHealthModel>().AsSingle().WithArguments(100).NonLazy();
    }
}