using Systems.GridSystem.Runtime.Interfaces;
using UnityEditor;
using UnityEngine;
using Zenject;

public class InteractiveGridEditorZenject : ZenjectEditorWindow
{
    #region Dependecies

    [Inject]
    private IGridSystem _gridSystem;

    #endregion
    
    [MenuItem("Window/InteractiveGridEditorZenject")]
    public static InteractiveGridEditorZenject GetOrCreateWindow()
    {
        var window = GetWindow<InteractiveGridEditorZenject>();
        window.titleContent = new GUIContent("InteractiveGridEditorZenject");
        return window;
    }

    public override void InstallBindings()
    {
        
    }
}