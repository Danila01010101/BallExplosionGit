using System.Collections.Generic;
using UnityEngine;

public class DetectBarriers : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private int _amountOfCollisions;

    private string _enemyBarrierTag = "EnemyBarrier";

    private List<GameObject> _collidingBarriers;

    private void Awake()
    {
        _collidingBarriers = new List<GameObject>();
    }

    private void OnEnable()
    {
        Infection.RockRemoved += DeleteRock;
    }

    private void OnDisable()
    {
        Infection.RockRemoved -= DeleteRock;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _enemyBarrierTag)
        {
            _collidingBarriers.Add(collision.gameObject);
            _amountOfCollisions += 1;
        }
        else
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(_enemyBarrierTag))
        {
            _collidingBarriers.Remove(collision.gameObject);
            _amountOfCollisions -= 1;
            _player.GetComponent<WinCondition>().CheckIsGameWon();
        }
        
    }

    public int GetCollisionsAmount()
    {
        return _amountOfCollisions;
    }

    private void DeleteRock(GameObject deletedRock)
    {
        if (_collidingBarriers.Contains(deletedRock))
            _amountOfCollisions -= 1;
        _player.GetComponent<WinCondition>().CheckIsGameWon();
    }
}
