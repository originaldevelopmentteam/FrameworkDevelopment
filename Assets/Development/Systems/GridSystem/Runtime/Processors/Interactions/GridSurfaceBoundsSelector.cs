using System;
using ProjectInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GridSystem.Runtime.Processors.Interactions
{
    public class GridSurfaceBoundsSelector : IProcessor
    {
        private readonly UserInputActions.RTS_ControlsActions _rtsControlsActions;
        private SelectionRectInteractionProcessor _selectionRectInteractionProcessor;

        public GridSurfaceBoundsSelector(UserInputActions userInputActions)
        {
            _rtsControlsActions = userInputActions.RTS_Controls;
            _selectionRectInteractionProcessor = new SelectionRectInteractionProcessor(_rtsControlsActions);
            _rtsControlsActions.CameraMovement.performed += OnCameraMovement;
        }

        public void Process()
        {
            throw new NotImplementedException();
        }
        
        private static void OnCameraMovement(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>().ToString());
        }
    }
}