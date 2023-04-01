using UnityEngine;
using UnityEngine.Events;

namespace FabriciohodDev
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int hitPoints;
        [SerializeField] bool canDespawn = true;
        [SerializeField] Timer despawnTimer;
        
        [Space]
        public UnityEvent OnDamageReceive;
        public UnityEvent OnDeath;

        public bool ReceiveDamage(int damage)
        {
            hitPoints -= damage;
            OnDamageReceive?.Invoke();

            if(hitPoints <= 0) 
            {
                OnDeath?.Invoke();

                if(canDespawn)
                    despawnTimer.StartTimer(() => Destroy(gameObject));

                return true;
            }

            return false;
        }
    }
}
