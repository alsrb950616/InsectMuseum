using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCountScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText = null;
    [SerializeField] private FoobMainCanvasScript _main = null;

    private bool _isRun = true;

    private void OnEnable()
    {
        _isRun = true;
    }

    void Update()
    {
        if (!_isRun) return;

        if(_countText != null)
        {
            if(_main.GetCount() <= 0)
            {
                _countText.text = "0";
                _isRun = false;
                _main.ButtonActivate(3);

            }
            else
            {
                _countText.text = _main.GetCount().ToString();
            }


        }
    }
}
