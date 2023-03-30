using UnityEngine;
using UnityEngine.InputSystem;

namespace FabriciohodDev.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;

        [Header("Dependency's")]
        [SerializeField] private Rigidbody2D physics;
        [SerializeField] private InputActionReference movementAction;

        public Vector2 InputDir { get; private set; }

        private void OnEnable()
        {
            movementAction.action.performed += OnMove;
            movementAction.action.canceled += OnStopMove;
        }

        private void FixedUpdate() => physics.velocity = InputDir * speed;
        private void OnMove(InputAction.CallbackContext ctx) => InputDir = ctx.ReadValue<Vector2>();
        private void OnStopMove(InputAction.CallbackContext ctx)
        {
            InputDir = Vector2.zero;
            physics.velocity = Vector2.zero;
        }
    }
}
