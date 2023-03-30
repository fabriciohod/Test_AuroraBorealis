using UnityEngine;
using UnityEngine.InputSystem;

namespace FabriciohodDev
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private InputActionReference attackAction;
        public static bool IsAttack { get; private set; }

        public void OnEnable()
        {
            attackAction.action.performed += OnAttack;
            attackAction.action.canceled += OnStopAttack;
        }

        public void OnDisable()
        {
            attackAction.action.performed -= OnAttack;
            attackAction.action.canceled -= OnStopAttack;
        }

        private void OnAttack(InputAction.CallbackContext ctx)
        {
            IsAttack = true;
        }

        private void OnStopAttack(InputAction.CallbackContext ctx)
        {
            IsAttack = false;
        }
    }
}
