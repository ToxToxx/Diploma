using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       BindPlayerHealth();
       BindPlayerMovement();
    }

    private void BindPlayerHealth()
    {
        Container.BindInterfacesAndSelfTo<PlayerHealthController>().AsSingle().NonLazy();
        Container.Bind<PlayerHealthView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerHealthModel>().AsSingle().WithArguments(100).NonLazy();
    }

    private void BindPlayerMovement()
    {
        Container.Bind<PlayerMovementModel>().AsSingle().WithArguments<float>(3f).NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle().NonLazy();
        Container.Bind<PlayerMovementView>().FromComponentInHierarchy().AsSingle();
    }
}