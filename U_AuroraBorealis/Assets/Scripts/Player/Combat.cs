using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace FabriciohodDev.Player
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private InputActionReference slashAttackAction;
        [SerializeField] private InputActionReference aoeAttackAction;
        [SerializeField] private PlayableDirector aoeAttackPrefab;
        [SerializeField] private Timer slashColldown;
        [SerializeField] private Timer aoeAttackColldown;
        public static bool IsUsingSlash { get; private set; }
        private bool canUseSlash = true;
        private bool canUseAoeAttack = true;

        void OnEnable()
        {
            slashAttackAction.action.performed += OnAttack1;
            slashAttackAction.action.canceled += OnStopAttack1;

            aoeAttackAction.action.performed += OnAttack2;
        }

        public void OnDisable()
        {
            slashAttackAction.action.performed -= OnAttack1;
            slashAttackAction.action.canceled -= OnStopAttack1;

            aoeAttackAction.action.performed -= OnAttack2;
        }

        private void OnAttack1(InputAction.CallbackContext ctx)
        {
            if (!canUseSlash)
                return;

            IsUsingSlash = true;
            canUseSlash = false;

            slashColldown.StartTimer(() => canUseSlash = true);
        }

        private void OnStopAttack1(InputAction.CallbackContext ctx)
        {
            IsUsingSlash = false;
        }

        private void OnAttack2(InputAction.CallbackContext ctx)
        {
            if (!canUseAoeAttack)
                return;

            canUseAoeAttack = false;
            aoeAttackPrefab.Play();

            aoeAttackColldown.StartTimer(() => canUseAoeAttack = true);
        }
    }
}
