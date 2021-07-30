using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject _path;

    private bool _isLevelEnded = false;

    private void OnEnable()
    {
        DestroyOnTriggerEnter.ExplosionEnded += CheckIsGameWon;
    }

    private void OnDisable()
    {
        DestroyOnTriggerEnter.ExplosionEnded -= CheckIsGameWon;
    }

    public void CheckIsGameWon()
    {
        int collisionsAmount = _path.GetComponent<DetectBarriers>().GetCollisionsAmount();
        if (collisionsAmount == 0)
        {
            StartWinAnimation();
        }
    }

    private void StartWinAnimation()
    {
        StartCoroutine(JumpToEndOfLevel());
        GetComponent<PlayerInput>().SetGameEnded();
        Debug.Log("win");
    }

    IEnumerator JumpToEndOfLevel()
    {
        Jump();
        yield return new WaitForSeconds(1f);
        if (!_isLevelEnded)
            StartCoroutine(JumpToEndOfLevel());
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 2.5f + Vector3.right * 5.5f;
    }

    public void EndLevel()
    {
        _isLevelEnded = true;
    }
}
