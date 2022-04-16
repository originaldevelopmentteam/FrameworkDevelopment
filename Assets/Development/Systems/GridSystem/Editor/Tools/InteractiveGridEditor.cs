using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Systems.GridSystem.Runtime.Processors.Calculators;
using UnityEditor;
using UnityEngine;

namespace Systems.GridSystem.Editor.Tools
{
    public class InteractiveGridEditor : OdinEditorWindow
    {
        [AssetsOnly] private InteractiveGridCalculator interactiveGridController;

        [MenuItem(nameof(Tools) + "/" + nameof(InteractiveGridEditor))]
        private static void ShowWindow()
        {
            var window = GetWindow<InteractiveGridEditor>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }

        private Rect _gridBoundsRect;

        protected override void OnEnable()
        {
            base.OnEnable();
            // RenderPipelineManager.endFrameRendering += EndFrameRendering;
        }

        private void OnDisable()
        {
            // RenderPipelineManager.endFrameRendering -= EndFrameRendering;
        }

        /*private void EndFrameRendering(ScriptableRenderContext arg1, Camera[] arg2)
        {
            if (!interactiveGridController) return;
        }*/
    }
}