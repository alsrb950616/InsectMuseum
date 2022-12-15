using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystemScript : MonoBehaviour
{
    [SerializeField] private GameObject _ready = null;
    [SerializeField] private GameObject _timer = null;

    [SerializeField] private int _defaultTime = 60;
    [SerializeField] private int _timecount = 0;

    [SerializeField] private PlayPanelScript _play = null;

    private void OnEnable()
    {
        _timecount = _defaultTime;
        _ready.SetActive(true);
        _timer.SetActive(false);
    }

    private void OnDisable()
    {
        _timecount = _defaultTime;
        _ready.SetActive(false);
        _timer.SetActive(false);
        CancelInvoke("SetCountDown");
    }

    public void EnableTimer()
    {
        _timer.SetActive(true);
        SetCountDown();

        InvokeRepeating("SetCountDown", 1, 1);
    }

    private void SetCountDown()
    {
        if (_timecount <= 0)
        {
            this.gameObject.SetActive(false);
            _play.ResultGame();
        }

        string time = string.Empty;
        int minute = _timecount / 60;
        int second = _timecount % 60;
        if(minute > 10)
        {
            time += minute.ToString();   
        }
        else
        {
            time += "0" + minute.ToString();
        }

        time += ":";
        
        if(second > 0)
        {
            if(second < 10)
            {
                time += "0" + second.ToString();
            }
            else
            {
                time += second;
            }
        }
        else
        {
            time += "00";
        }

        _timer.GetComponent<TextMeshProUGUI>().text = time;
        _timecount--;

    

    }
}
