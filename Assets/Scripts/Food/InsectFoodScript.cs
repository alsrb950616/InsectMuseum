using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectFoodScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> _foodImg = null;

    [SerializeField] private float _speed = 10.0f;

    private int _index = 0;
    private FoobMainCanvasScript _main = null;

    // Update is called once per frame
    private bool _isRun = true;

    void Update()
    {
     //   if (!_isRun) return;
        transform.position += this.transform.up * _speed * Time.deltaTime * -1;
        
        if(transform.position.y < -200)
        {
            Destroy(this.gameObject);
        }

    }

    public void Setup(int value, FoobMainCanvasScript obj)
    {
        _index = value;
        _main = obj;
      
        Image img = this.gameObject.GetComponent<Image>();
        img.sprite = _foodImg[_index];

        switch(_main.GetInsectType())
        {
            case FoobMainCanvasScript.InsectType.BUTTERFLY:
                _speed = 25;
                break;
            case FoobMainCanvasScript.InsectType.CICADA:
                _speed = 35;
                break;
            case FoobMainCanvasScript.InsectType.DRAGONFLY:
                _speed = 15;
                break;
            case FoobMainCanvasScript.InsectType.HONEYBEE:
                _speed = 25;
                break;
            case FoobMainCanvasScript.InsectType.STAGBEETLE:
                _speed = 15;
                break;
        }
     //   this.transform.position = Vector3.zero;
    }

    public void OnClickEvent()
    {

        int value = 0;

        if (_index == 0)
        {
            value = 1;
        }
        else if (_index == 1 || _index == 3 || _index == 4)
        {
            value = 2;
        }
        else if(_index == 2)
        {
            value = 3;
        }
        else if(_index == 5)
        {
            value = 4;
        }
        _main.CheckFoodAnswer(value);
    }
}
