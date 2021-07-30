using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    public void Shoot(GameObject bullet)
    {
        MoveForvard moveForvard = bullet.GetComponent<MoveForvard>();
        if (moveForvard != null)
        {
            moveForvard.AllowMovement();
        }
    }
    
    public GameObject CreateBullet()
    {
        return Instantiate(_bulletPrefab, gameObject.transform.position + Vector3.right * 4f, _bulletPrefab.transform.rotation);
    }
}
