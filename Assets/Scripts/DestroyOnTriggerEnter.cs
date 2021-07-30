using UnityEngine;
using System.Collections;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionEffect;

    public delegate void OnExplosionEnd();
    public static event OnExplosionEnd ExplosionEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBarrier"))
        {
            other.GetComponent<Infection>().Infect();
        }
        ExplosionEnded();
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject.transform.parent.gameObject);
        if (transform.parent.gameObject == null)
            Destroy(gameObject);
    }
}
