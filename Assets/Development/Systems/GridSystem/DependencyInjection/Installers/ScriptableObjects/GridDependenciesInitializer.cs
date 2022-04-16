using UnityEngine;
using Zenject;

namespace Systems.GridSystem.DependencyInjection.Installers
{
    [CreateAssetMenu(fileName = nameof(GridDependenciesInitializer), menuName = nameof(Installers) + "/" + nameof(GridDependenciesInitializer))]
    public class GridDependenciesInitializer : ScriptableObjectInstaller<GridDependenciesInitializer>
    {
        public override void InstallBindings()
        {
            Debug.Log($"{nameof(GridDependenciesInitializer)} Is Installed!");
            // Container.Bind<IInteractiveGridCalculator>().To<InteractiveGridCalculator>().AsSingle();
        }
    }
}