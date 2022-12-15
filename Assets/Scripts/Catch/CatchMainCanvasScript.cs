using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMainCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject _title = null;

    [SerializeField] private GameObject _timer = null;
    [SerializeField] private PlayPanelScript _play = null;

    private void Start()
    {
        ResetGame();
    }

    public void OnGameStart()
    {
        _title.SetActive(false);

        _timer.SetActive(true);
        _play.StartGame();
    }

    public void ResetGame()
    {
        _title.SetActive(true);
        _timer.SetActive(false);
        _play.WaitGame();
    }
}
