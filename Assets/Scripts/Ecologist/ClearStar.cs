using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearStar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Star = null;
    
    public void SetUp(int StarIndex)
    {
        Star.text = StarIndex.ToString();
    }
}
