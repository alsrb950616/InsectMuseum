using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonQuestion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question = null;
    [SerializeField] private GameObject clear = null;
    [SerializeField] private GameObject notClear = null;
    private bool answer = false;
    private bool interactable = false;

    public void SetQuestion(string question, bool answer)
    {
        this.question.text = question;
        this.answer = answer;
    }

    public bool SelectQuestion()
    {
        interactable = true;
        if (answer)
        {
            clear.SetActive(true);
            return true;
        }
        else
        {
            notClear.SetActive(true);
            return false;
        }
    }

    public void Reset()
    {
        clear.SetActive(false);
        notClear.SetActive(false);
    }
}
