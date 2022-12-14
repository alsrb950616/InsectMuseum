using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;
    [SerializeField] private int _index = 0;
    [SerializeField] private Image _progressBar = null;

    // Update is called once per frame
    void Update()
    {
        switch (_index)
        {
            case 1: // Timer
                _progressBar.fillAmount = _shootingMode.GetLeftLimitTime();
                break;
            case 2: // LeftGermNum
                _progressBar.fillAmount = _shootingMode.GetDeathcunt();
                break;
            default:
                break;
        }
    }
}
