using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Shooting _shooting;

    [SerializeField]
    private SizeChanger _pathSizeChanger; 

    [SerializeField]
    private GameObject _loseText;
    private GameObject _currentBullet;

    private bool _isGameEnded = false;

    private void Update()
    {
        if (Input.touchCount > 0 && !_isGameEnded)
        {
            Touch touch = Input.GetTouch(0);
            if (gameObject.transform.localScale.x <= 0.5f)
            {
                SetGameEnded();
                LoseGame();
                touch.phase = TouchPhase.Ended;
            }
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _currentBullet = _shooting.CreateBullet();
                    break;
                case TouchPhase.Ended:
                    _currentBullet.GetComponent<MoveForvard>().AllowMovement();
                    break;
                default:
                    _pathSizeChanger.ChangeSize(Vector3.back * 0.01f);
                    gameObject.transform.localScale -= Vector3.one * 0.01f;
                    _currentBullet.transform.localScale += Vector3.one * 0.01f;
                    break;
            }
        }
    }

    private void LoseGame()
    {
        _loseText.SetActive(true);
        StartCoroutine(RestartLevelAfterSeconds(2.8f));
    }

    public void SetGameEnded()
    {
        _isGameEnded = true;
    }

    IEnumerator RestartLevelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
