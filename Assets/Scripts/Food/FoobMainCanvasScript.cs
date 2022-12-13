using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoobMainCanvasScript : MonoBehaviour
{
    private enum InsectType
    { 
        NONE,
        BUTTERFLY,
        STAGBEETLE,
        CICADA,
        DRAGONFLY,
        HONEYBEE,
    }


    [SerializeField] private List<GameObject> _panelList = null;
    [SerializeField] private InsectType _curInsect = InsectType.NONE;
    [SerializeField] private int _gameCount = 10;
    [SerializeField] private int _totalCount = 10;
    [SerializeField] private int _answerCount = 0;
    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        // all paenl Activate false
        PanelDisable();

        // title paenl Enable
        PanelEnable(0);
    }

    private void PanelDisable()
    {
        foreach(var obj in _panelList)
        {
            obj.SetActive(false);
        }
    }

    private void PanelEnable(int index)
    {
        _panelList[index].SetActive(true);
    }

    public void ResetDada()
    {
        PanelDisable();
        PanelEnable(0);
        _curInsect = InsectType.NONE;
        _gameCount = _totalCount;
        _answerCount = 0;
    }

    public void ButtonActivate(int index)
    {
        PanelDisable();
        PanelEnable(index);
    }

    public void SetInsectType(int index)
    {
        _curInsect = (InsectType)index;
    }

    public void CheckEqualAnswer(int index)
    {
        if((InsectType)index == _curInsect)
        {
            PanelDisable();
            PanelEnable(2);
        }
    }

    public int GetCount()
    {
        return _gameCount;
    }

    public bool GetResult()
    {
        float value = (float)_answerCount / (float)_totalCount;

        Debug.Log(value.ToString());

        if(value < 0.4)
        {
            return false;
        }
        return true;
    }

    public float GetPercent()
    {
        float value = (float)_answerCount / (float)_totalCount;
        return value;
    }

    public void CheckFoodAnswer(int value)
    {
        if(value == 1)
        {
            if(_curInsect == InsectType.BUTTERFLY || _curInsect == InsectType.HONEYBEE)
            {
                _answerCount++;
            }
        }
        else if(value == 2)
        {
            if(_curInsect == InsectType.STAGBEETLE)
            {
                _answerCount++;
            }
        }
        else if(value == 3)
        {
            if(_curInsect == InsectType.CICADA)
            {
                _answerCount++;
            }
        }
        else if(value == 4)
        {
            if(_curInsect == InsectType.DRAGONFLY)
            {
                _answerCount++;
            }
        }

        _gameCount--;
    }

}
