using System.Collections;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftGate;
    [SerializeField]
    private GameObject _rightGate;

    [SerializeField]
    private float _rotationSpeed;

    private Vector3 _rotationAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OpenGates();
    }

    private void Update()
    {
        _leftGate.transform.Rotate(_rotationAngle);
        _rightGate.transform.Rotate(-_rotationAngle);
    }

    public void OpenGates()
    {
        _rotationAngle = Vector3.up * _rotationSpeed;
        StartCoroutine(StopRotationAfterSeconds(2.8f));
    }

    IEnumerator StopRotationAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _rotationAngle = Vector3.zero;
    }
}
