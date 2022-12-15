using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPanelScript : MonoBehaviour
{
    [SerializeField] private List<PlayerBoxScript> _players = null;
    [SerializeField] private CatchMainCanvasScript _main = null;
    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip _result = null;

    public void WaitGame()
    {
        foreach(var player in _players)
        {
            player.WaitGame();
        }
    }

    public void StartGame()
    {
        foreach (var player in _players)
        {
            player.StartGame();
        }
    }

    public void ResultGame()
    {
        int winIndex = 0;
        int highscore = 0;
        for(int i = 0; i< _players.Count; i++)
        {
            if(highscore <= _players[i].GetScore())
            {
                highscore = _players[i].GetScore();
            }
        }

        foreach(var player in _players)
        {
            if(highscore == player.GetScore())
            {
                player.ResultGame(true);
            }
            else
            {
                player.ResultGame(false);
            }

        }
        _audio.PlayOneShot(_result);
        StartTimer();
    }

    public void StartTimer()
    {
        Invoke("ResetGame", 10);
    }

    private void ResetGame()
    {
        _main.ResetGame();
    }

    public void CancelTimer()
    {
        CancelInvoke("ResetGame");
    }
}
