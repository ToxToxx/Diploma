using UnityEngine;
using Zenject;

public class PlayerInstaller : Installer
{
    public override void InstallBindings()
    {
       BindPlayerHealth();
       BindPlayerMovement();
       BindPlayerRunning();
       BindPlayerInput();
    }

    private void BindPlayerHealth()
    {
        Container.BindInterfacesAndSelfTo<PlayerHealthController>().AsSingle().NonLazy();
        Container.Bind<PlayerHealthView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerHealthModel>().AsSingle().WithArguments<float>(100).NonLazy();
    }

    private void BindPlayerMovement()
    {
        Container.Bind<PlayerMovementModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle().NonLazy();
        Container.Bind<PlayerMovementView>().FromComponentInHierarchy().AsSingle();
    }

    private void BindPlayerRunning()
    {
        Container.Bind<PlayerRunModel>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerRunController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<PlayerRunView>().FromComponentInHierarchy().AsSingle();
    }

    private void BindPlayerInput()
    {
        Container.Bind<PlayerInputSystem>().AsSingle().NonLazy();
    }
}