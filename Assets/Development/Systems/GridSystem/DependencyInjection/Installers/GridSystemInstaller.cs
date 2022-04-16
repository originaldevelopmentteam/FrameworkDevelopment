using Systems.GridSystem.Runtime;
using Systems.GridSystem.Runtime.Interfaces;
using Systems.GridSystem.Runtime.Processors.Calculators;
using Systems.GridSystem.Runtime.Processors.Interactions;
using UnityEngine;
using Zenject;

namespace Systems.GridSystem.DependencyInjection.Installers
{
    public class GridSystemInstaller : Installer<GridSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInteractiveGridCalculator>().To<InteractiveGridCalculator>();
            
            Container.Bind<IGridSelector>().To<EditorGridSelector>().AsTransient();
            Container.Bind<IGridPositioner>().To<EditorGridPositioner>().AsTransient();
            
            Container.Bind<IGridSystem>().To<AdvancedGridSystem>().AsSingle().NonLazy();
            Debug.Log($"{nameof(GridSystemInstaller)}");
        }
    }
}