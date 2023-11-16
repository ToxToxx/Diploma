using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;

    public override void InstallBindings()
    {
        PlayerInstallersBind();
    }

    private void PlayerInstallersBind()
    {
        Container.Bind<PlayerMovementConfig>().FromInstance(_playerMovementConfig);
        Container.Install<PlayerInstaller>();
    }

}