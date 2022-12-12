using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanelScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttonList = null;

    private void OnEnable()
    {
        foreach(var obj in _buttonList)
        {
            obj.SetActive(false);

        }

        _buttonList[0].SetActive(true);
    }
}
