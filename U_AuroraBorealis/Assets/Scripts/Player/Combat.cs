using UnityEngine;
using UnityEngine.InputSystem;

namespace FabriciohodDev
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private InputActionReference attackAction;
        [SerializeField] private Timer slashColldown;
        public static bool IsAttack { get; private set; }
        private bool canAttack = true;

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
            if (!canAttack)
                return;

            IsAttack = true;
            canAttack = false;

            slashColldown.StartTimer(() => canAttack = true);
        }

        private void OnStopAttack(InputAction.CallbackContext ctx)
        {
            IsAttack = false;
        }
    }
}
