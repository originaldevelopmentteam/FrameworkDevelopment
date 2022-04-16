using UnityEditor;
using Zenject;

namespace Systems.GridSystem.DependencyInjection.Installers.Editor
{
    [InitializeOnLoad]
    public class GridSystemEditorInstaller : EditorStaticInstaller<GridSystemEditorInstaller>
    {
        static GridSystemEditorInstaller()
        {
            Install();
        }
        public override void InstallBindings()
        {
            GridSystemInstaller.Install(Container);
        }
    }
}