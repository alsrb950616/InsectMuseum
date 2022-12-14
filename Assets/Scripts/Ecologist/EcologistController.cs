using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EcologistController : MonoBehaviour
{
    [SerializeField] private ContentState[] contents;
    [SerializeField] private EcologistEnum ecologistEnum;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject select;
    [SerializeField] private GameObject selectEgg;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject clear;
    [SerializeField] private GameObject[] clearImage;
    [SerializeField] private CharacterMove[] insects;
    private static EcologistController instance = null;
    private int clearInt = 0;

    public ContentState[] Contents { get { return contents; } }
    public EcologistEnum EcologistEnum { get { return ecologistEnum; } }
    public int ClearInt { get { return clearInt; } }

    public static EcologistController Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        contents = Resources.LoadAll<ContentState>("Ecologist");
        //Resets();
    }

    private void Resets()
    {
        title.SetActive(true);
        select.SetActive(false);
        selectEgg.SetActive(false);
        main.SetActive(false);
        clear.SetActive(false);
        foreach (var clearImage in clearImage)
        {
            clearImage.SetActive(false);
        }
        foreach (var insects in insects)
        {
            insects.gameObject.SetActive(true);
            insects.Reset();
        }
    }

    public void ResetButton()
    {
        Resets();
    }

    public void TitleSelect()
    {
        select.SetActive(true);
        title.SetActive(false);
        foreach (var insects in insects)
        {
            insects.gameObject.SetActive(false);
        }
    }

    public void Select(EcologistEnum ecologistEnum)
    {
        this.ecologistEnum = ecologistEnum;
        selectEgg.SetActive(true);
        select.SetActive(false);
        main.SetActive(false);
    }

    public void SelectEgg()
    {
        main.SetActive(true);
        selectEgg.SetActive(false);
        select.SetActive(false);
        foreach (var insects in insects)
        {
            if(insects.EcologistEnum == ecologistEnum)
                insects.gameObject.SetActive(true);
        }
    }

    public void Clear(int index, string text)
    {
        clearInt = index;
        endText.text = text;
        Clear();
    }

    public void Clear()
    {
        main.SetActive(false);
        clear.SetActive(true);
        switch (clearInt)
        {
            case 0:
                clearImage[0].SetActive(true);
                break;
            case 1:
                clearImage[1].SetActive(true);
                break;
            case 2:
                clearImage[2].SetActive(true);
                break;
            case 3:
                clearImage[3].SetActive(true);
                break;
        }
    }

    public void SizeUp(int index)
    {
        float i = 0f;
        switch (index)
        {
            case 1:
                i = 1.3f;
                break;
            case 2:
                i = 1.6f;
                break;
            case 3:
                i = 2f;
                break;
        }
        foreach (var insects in insects)
        {
            if (insects.EcologistEnum == ecologistEnum)
                insects.transform.localScale = new Vector3(i,i,i);
        }
    }
}
