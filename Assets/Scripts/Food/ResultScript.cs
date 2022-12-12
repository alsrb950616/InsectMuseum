using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    [SerializeField] private GameObject _victory = null;
    [SerializeField] private GameObject _failed = null;


    [SerializeField] private FoobMainCanvasScript _main = null;

    private void OnEnable()
    {
        _victory.SetActive(false);
        _failed.SetActive(false);

        if (_main.GetResult())
        {
            _victory.SetActive(true);
        }
        else
        {
            _failed.SetActive(true);
        }
    }
}
