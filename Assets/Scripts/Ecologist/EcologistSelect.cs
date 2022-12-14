using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcologistSelect : MonoBehaviour
{
    [SerializeField] private EcologistEnum ecologistEnum;
    public Button selectButton = null;
    public Button selectEggButton = null;

    public void Awake()
    {
        if(selectButton != null) selectButton.onClick.AddListener(Select);
        if(selectEggButton != null) selectEggButton.onClick.AddListener(SelectEgg);
    }

    public void Select()
    {
        EcologistController.Instance.Select(ecologistEnum);
    }

    public void SelectEgg()
    {
        if(EcologistController.Instance.EcologistEnum == ecologistEnum)
            EcologistController.Instance.SelectEgg();
    }
}
