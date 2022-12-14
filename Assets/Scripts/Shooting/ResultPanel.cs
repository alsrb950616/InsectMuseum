using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels = null;
    [SerializeField] private AudioSource _sound = null;

    private bool _isEnd = false;
    private float _timer = 0.0f;

    private void Awake()
    {
        foreach (GameObject go in _panels)
            go.SetActive(false);
    }

    private void Update()
    {
        if (_isEnd)
        {
            _timer += Time.deltaTime;

            if (_timer >= 3)
                RestartGame();
        }
    }

    public void OpenResult(int result)
    {
        _isEnd = true;

        //_sound.Play();

        switch (result)
        {
            case 0:
                _panels[result].SetActive(true);
                break;
            case 1:
                _panels[result].SetActive(true);
                break;
            case 2:
                _panels[result].SetActive(true);
                break;
            case 3:
                _panels[result].SetActive(true);
                break;
            default:
                break;
        }
    }
    
    void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
