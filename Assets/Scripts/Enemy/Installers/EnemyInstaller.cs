using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        EnemyHealthBindings();
    }

    private void EnemyHealthBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemyHealthModel>().AsTransient().WithArguments<int>(100);
        Container.Bind<EnemyHealthVIew>().AsTransient();
        Container.BindInterfacesAndSelfTo<EnemyHealthController>().AsTransient();
    }
}