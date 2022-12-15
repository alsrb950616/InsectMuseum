using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CatchResultScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText = null;
    
    [SerializeField] private PlayerBoxScript _player = null;
    [SerializeField] private Image _image = null;

    [SerializeField] private List<Sprite> _resultImg = null;
    private void OnEnable()
    {
        _scoreText.text = "Á¡¼ö : " + _player.GetScore().ToString() + " Á¡";
    }

    private void OnDisable()
    {
        _scoreText.text = string.Empty;
    }

    public void SetResultImage(bool isWin)
    {
        if(isWin)
        {
            _image.sprite = _resultImg[0];
        }
        else
        {
            _image.sprite = _resultImg[1];
        }
    }
}
