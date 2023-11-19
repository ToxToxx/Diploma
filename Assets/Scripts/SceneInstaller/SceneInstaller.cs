using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;
    [SerializeField] private PlayerRunningConfig _playerRunningConfig;

    public override void InstallBindings()
    {
        PlayerInstallersBind();
    }

    private void PlayerInstallersBind()
    {
        Container.Bind<PlayerMovementConfig>().FromInstance(_playerMovementConfig);
        Container.Bind<PlayerRunningConfig>().FromInstance(_playerRunningConfig);
        Container.Install<PlayerInstaller>();
    }

}