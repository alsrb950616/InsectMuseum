using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviromment : MonoBehaviour
{
    [SerializeField] private GameObject clear = null;
    [SerializeField] private GameObject notClear = null;
    private bool interactable = false;

    public void SetClear(bool clearCheck)
    {
        if (!interactable)
        {
            interactable = true;
            if (clearCheck)
            {
                clear.SetActive(true);
            }
            else
            {
                notClear.SetActive(true);
            }
        }
    }

    public void Reset()
    {
        interactable = false;
        clear.SetActive(false);
        notClear.SetActive(false);
    }
}
