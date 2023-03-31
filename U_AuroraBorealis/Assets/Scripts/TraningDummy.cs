using System.Collections;
using UnityEngine;

namespace FabriciohodDev
{
    public class TraningDummy : MonoBehaviour
    {
        private Health health;
        private SpriteRenderer renderer;
        private bool isAnimating;
        private WaitForSeconds waitForSeconds;
        private int hitProp = Shader.PropertyToID("_Hit");

        private void Awake()
        {
            health = GetComponent<Health>();
            renderer = GetComponentInChildren<SpriteRenderer>();
            waitForSeconds = new(0.1f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("SwordArea"))
                return;

            health.ReceviDamage(1);
            isAnimating = true;
            StartCoroutine(nameof(C_DamageTick));
        }


        IEnumerator C_DamageTick()
        {
            if (isAnimating)
                yield return null;

            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 0);

            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 0);

            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 1);
            yield return waitForSeconds;
            renderer.material.SetInt(hitProp, 0);

            isAnimating = false;
        }
    }
}
