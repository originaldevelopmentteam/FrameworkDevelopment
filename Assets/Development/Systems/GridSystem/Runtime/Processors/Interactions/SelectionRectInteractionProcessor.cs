using ProjectInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GridSystem.Runtime.Processors.Interactions
{
    public sealed class SelectionRectInteractionProcessor
    {
        public Bounds selectionBounds => _selectionBounds;
        
        private readonly UserInputActions.RTS_ControlsActions _rtsControlsActions;
        private Bounds _selectionBounds;

        public SelectionRectInteractionProcessor(in UserInputActions.RTS_ControlsActions rtsControlsActions)
        {
            _rtsControlsActions = rtsControlsActions;
            _rtsControlsActions.SelectSceneArea.performed += OnSelectSceneArea;
            _rtsControlsActions.SelectSceneArea.canceled += OnSelectSceneAreaCanceled;
        }

        private void OnSelectSceneArea(InputAction.CallbackContext context)
        {
            _selectionBounds.min = context.ReadValue<Vector2>();
            _rtsControlsActions.CursorPosition.performed += OnMousePositionChanged;
            Debug.Log(_selectionBounds.min.ToString());
        }
        
        private void OnSelectSceneAreaCanceled(InputAction.CallbackContext context)
        {
            Debug.Log(nameof(OnSelectSceneAreaCanceled));
            _rtsControlsActions.CursorPosition.performed -= OnMousePositionChanged;
        }
        
        private void OnMousePositionChanged(InputAction.CallbackContext context)
        {
            _selectionBounds.max = context.ReadValue<Vector2>();
            Debug.Log(_selectionBounds.max.ToString());
        }
    }
}