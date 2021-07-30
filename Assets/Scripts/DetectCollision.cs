using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject _detector;

    private void OnCollisionEnter(Collision collision)
    {
        _detector.SetActive(true);
    }
}
