using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;
    [SerializeField] private int _index = 0;
    [SerializeField] private Slider _slider = null;

    // Update is called once per frame
    void Update()
    {
        switch (_index)
        {
            case 1: // Timer
                _slider.value = _shootingMode.GetLeftLimitTime();
                break;
            case 2: // LeftGermNum
                _slider.value = _shootingMode.GetDeathcunt();
                break;
            default:
                break;
        }
    }
}
