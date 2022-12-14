using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panels = null;

    private void Awake()
    {
        foreach (GameObject go in _panels)
            go.SetActive(false);
    }

    public void OpenResult(int result)
    {
        switch (result)
        {
            case 0:
                _panels[result].SetActive(true);
                break;
            case 1:
                _panels[result].SetActive(true);
                break;
            case 2:
                _panels[result].SetActive(true);
                break;
            case 3:
                _panels[result].SetActive(true);
                break;
            default:
                break;
        }
    }
    
    void RestartButton()
    {

    }

}
