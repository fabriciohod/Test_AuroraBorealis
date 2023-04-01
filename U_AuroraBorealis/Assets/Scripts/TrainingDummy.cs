using System.Collections;
using UnityEngine;

namespace FabriciohodDev
{
    public class TrainingDummy : MonoBehaviour
    {
        [SerializeField] private GameObject hitSparks;
        private Health health;
        private SpriteRenderer spriteRenderer;
        private WaitForSeconds waitForSeconds;
        private bool isAnimating;
        private int hitProp = Shader.PropertyToID("_Hit");

        private void Awake()
        {
            health = GetComponent<Health>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            waitForSeconds = new(0.1f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("SwordArea"))
                return;

            health.ReceiveDamage(1);
            isAnimating = true;
            StartCoroutine(nameof(C_DamageTick));
        }

        IEnumerator C_DamageTick()
        {
            if (isAnimating)
                yield return null;

            hitSparks.SetActive(true);

            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 0);

            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 0);

            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            spriteRenderer.material.SetInt(hitProp, 0);

            hitSparks.SetActive(false);

            isAnimating = false;
        }
    }
}
