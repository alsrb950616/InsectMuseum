using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private Image _victroyImage = null;

    [SerializeField] private List<Sprite> _imageSprite = null;
    [SerializeField] private FoobMainCanvasScript _main = null;

    private void OnEnable()
    {
        if(_main != null)
        {
            if(_main.GetPercent() > 0.8)
            {
                _victroyImage.sprite = _imageSprite[0];
            }
            else if( _main.GetPercent() <= 0.8 && _main.GetPercent() > 0.6)
            {
                _victroyImage.sprite = _imageSprite[1];
            }
            else
            {
                _victroyImage.sprite = _imageSprite[2];
            }
        }
    }
}
