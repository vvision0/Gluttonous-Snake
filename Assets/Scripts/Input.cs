using UnityEngine;

namespace SNAKE
{
    public class SnakeInput : MonoBehaviour
    {
        private PlayerInput inputAction;

        public Vector2 MovementInput
        { 
            get
            {
                if (lastInput.x * movementInput.x == -1 || lastInput.y * movementInput.y == -1)
                {
                    movementInput = lastInput;
                    return lastInput;
                }
                else
                {
                    return movementInput; 
                }
            }

            set { movementInput = value ; }
        }
        private Vector2 movementInput;
        private Vector2 lastInput;

        private void Awake()
        {
            inputAction = new PlayerInput();
            inputAction.Enable();

            inputAction.Snake.Move.performed += OnMovementPerformed;
        }

        private void OnMovementPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            lastInput = movementInput;
            Vector2 movementRawInput = context.ReadValue<Vector2>();
            movementInput = movementRawInput;
        }

        public void EnableInput()
        {
            //inputAction.Snake.Move.performed += OnMovementPerformed;
            inputAction.Enable();
        }

        public void DisableInput()
        {
            //inputAction.Snake.Move.performed -= OnMovementPerformed;
            inputAction.Disable();
        }
    }
}
