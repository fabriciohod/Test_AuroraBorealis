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
        private int isDashing = Animator.StringToHash("IsDashing");
        private int isAttacking = Animator.StringToHash("IsAttacking");

        void Update()
        {
            if (Movement.InputDir == Vector2.zero)
                anim.SetBool(isMoving, false);
            else
                anim.SetBool(isMoving, true);

            anim.SetFloat(idleX, Movement.LeastInputDir.x);
            anim.SetFloat(idleY, Movement.LeastInputDir.y);

            anim.SetBool(isAttacking, Combat.IsUsingSlash);
            anim.SetBool(isDashing, Movement.isDashing);

            anim.SetFloat(moveX, Movement.InputDir.x);
            anim.SetFloat(moveY, Movement.InputDir.y);
        }
    }
}
