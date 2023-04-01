using UnityEngine;
using UnityEngine.InputSystem;

namespace FabriciohodDev.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float dashForce;
        [SerializeField] private Timer dashColldownTimer;


        [Header("Dependency's")]
        [SerializeField] private Rigidbody2D physics;
        [SerializeField] private InputActionReference movementAction;
        [SerializeField] private InputActionReference DashAction;

        public static Vector2 InputDir { get; private set; }
        public static Vector2 LeastInputDir { get; private set; }
        public static bool isDashing { get; private set; }

        private void OnEnable()
        {
            movementAction.action.performed += OnMove;
            movementAction.action.canceled += OnStopMove;

            DashAction.action.performed += OnDashing;
        }

        private void OnDisable()
        {
            movementAction.action.performed -= OnMove;
            movementAction.action.canceled -= OnStopMove;

            DashAction.action.performed -= OnDashing;
        }

        private void FixedUpdate()
        {
            if (isDashing)
                return;

            physics.velocity = InputDir * speed;
        }
        private void OnMove(InputAction.CallbackContext ctx) => InputDir = ctx.ReadValue<Vector2>();
        private void OnStopMove(InputAction.CallbackContext ctx)
        {
            LeastInputDir = InputDir;
            InputDir = Vector2.zero;
        }

        private void OnDashing(InputAction.CallbackContext ctx)
        {
            if (isDashing || InputDir == Vector2.zero)
                return;

            isDashing = true;

            physics.velocity = Vector2.zero;
            physics.AddForce(InputDir * dashForce, ForceMode2D.Impulse);


            dashColldownTimer.StartTimer(() =>
            {
                isDashing = false;
            });
        }
    }
}
