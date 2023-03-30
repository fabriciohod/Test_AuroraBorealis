using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace FabriciohodDev.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
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
            DashAction.action.canceled += OnStopDash;

            dashColldownTimer.OnTimerTick.AddListener((i) => Debug.Log(i));
        }

        private void OnDisable()
        {
            movementAction.action.performed -= OnMove;
            movementAction.action.canceled -= OnStopMove;

            DashAction.action.performed -= OnDashing;
            DashAction.action.canceled -= OnStopDash;
        }

        private void FixedUpdate() => physics.velocity = InputDir * speed;
        private void OnMove(InputAction.CallbackContext ctx) => InputDir = ctx.ReadValue<Vector2>();
        private void OnStopMove(InputAction.CallbackContext ctx)
        {
            LeastInputDir = InputDir;
            InputDir = Vector2.zero;
        }

        private void OnDashing(InputAction.CallbackContext ctx)
        {
            dashColldownTimer.StartTimer(() => Debug.Log("end"));
            if (InputDir == Vector2.zero)
                return;

            physics.AddForce(transform.position.normalized * 100f);

            isDashing = true;
        }

        private void OnStopDash(InputAction.CallbackContext ctx)
        {
            isDashing = false;
        }
    }
}
