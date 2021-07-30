using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionEffect;

    public delegate void OnRemovingRock(GameObject removedRock);
    public static event OnRemovingRock RockRemoved;

    public void Infect()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        StartCoroutine(ExplodeAfterSeconds(0.4f));
    }

    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _explosionEffect.transform.localScale = Vector3.one * 2f;
        Instantiate(_explosionEffect, transform.position + Vector3.up * 4, _explosionEffect.transform.rotation);
        RockRemoved(gameObject);
        Destroy(gameObject);
    }
}
