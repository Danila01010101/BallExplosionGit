using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2;

    private bool _canMove = false;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
            _rigidbody.velocity = Vector3.right * _speed * 50 * Time.deltaTime;
    }

    public void AllowMovement()
    {
        _canMove = true;
    }

}
