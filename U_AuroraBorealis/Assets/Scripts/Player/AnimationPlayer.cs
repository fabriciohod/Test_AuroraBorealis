using UnityEngine;

namespace FabriciohodDev.Player
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private int moveX = Animator.StringToHash("MoveX");
        private int moveY = Animator.StringToHash("MoveY");

        private int idleX = Animator.StringToHash("IdleX");
        private int idleY = Animator.StringToHash("IdleY");

        private int isMoving = Animator.StringToHash("IsMoving");
        private int dashTrigger = Animator.StringToHash("Dash");

        void Update()
        {
            anim.SetBool(isMoving, false);
            anim.SetFloat(idleX, Movement.LeastInputDir.x);
            anim.SetFloat(idleY, Movement.LeastInputDir.y);

            if (Movement.InputDir == Vector2.zero)
                return;

            if(Movement.isDashing)
                anim.SetTrigger(dashTrigger);

            anim.SetBool(isMoving, true);
            anim.SetFloat(moveX, Movement.InputDir.x);
            anim.SetFloat(moveY, Movement.InputDir.y);
        }
    }
}
