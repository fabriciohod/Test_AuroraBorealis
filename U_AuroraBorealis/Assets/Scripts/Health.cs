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
        public UnityEvent OnDamageRecevi;
        public UnityEvent OnDeath;

        public bool ReceviDamage(int damage)
        {
            hitPoints -= damage;
            OnDamageRecevi?.Invoke();
            Debug.Log("hit");

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
