using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace FabriciohodDev
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private InputActionReference attack1Action;
        [SerializeField] private InputActionReference attack2Action;
        [SerializeField] private PlayableDirector aoeAttackPrefab;
        [SerializeField] private Timer slashColldown;
        [SerializeField] private Timer aoeAttackColldown;
        public static bool IsUsigAttack1 { get; private set; }
        private bool canUseAttack1 = true;
        private bool canUseAttack2 = true;

        void OnEnable()
        {
            attack1Action.action.performed += OnAttack1;
            attack1Action.action.canceled += OnStopAttack1;

            attack2Action.action.performed += OnAttack2;
        }

        public void OnDisable()
        {
            attack1Action.action.performed -= OnAttack1;
            attack1Action.action.canceled -= OnStopAttack1;

            attack2Action.action.performed -= OnAttack2;
        }

        private void OnAttack1(InputAction.CallbackContext ctx)
        {
            if (!canUseAttack1)
                return;

            IsUsigAttack1 = true;
            canUseAttack1 = false;

            slashColldown.StartTimer(() => canUseAttack1 = true);
        }

        private void OnStopAttack1(InputAction.CallbackContext ctx)
        {
            IsUsigAttack1 = false;
        }

        private void OnAttack2(InputAction.CallbackContext ctx)
        {
            if (!canUseAttack2)
                return;

            canUseAttack2 = false;
            aoeAttackPrefab.Play();

            aoeAttackColldown.StartTimer(() => canUseAttack2 = true);
        }
    }
}
