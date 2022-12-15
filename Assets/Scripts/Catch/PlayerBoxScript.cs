using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoxScript : MonoBehaviour
{
    [SerializeField] private Image _boxImage = null;

    [SerializeField] private List<Sprite> _gameImg = null;
    [SerializeField] private CatchResultScript _result = null;

    [SerializeField] private int _playerIndex = 0;

    [SerializeField] private int _score = 0;

    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip _catch = null;

    public void Setup()
    {

    }


    public void WaitGame()
    {
        _result.gameObject.SetActive(false);
        _boxImage.sprite = _gameImg[0];
    }
    

    public void StartGame()
    {
        _result.gameObject.SetActive(false);
        _boxImage.sprite = _gameImg[1];
    }

    public void ResultGame(bool iswin)
    {
        _result.gameObject.SetActive(true);
        _result.SetResultImage(iswin);
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int value)
    {
        _audio.PlayOneShot(_catch);
        _score += value;
    }

    public int GetIndex()
    {
        return _playerIndex;
    }
}
