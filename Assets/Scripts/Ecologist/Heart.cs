using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject[] Hearts = null;

    public void CheckHeart(int j)
    {
        for(int i = 0; i < Hearts.Length; i++)
        {
            if(i < j)
            {
                Hearts[i].gameObject.SetActive(true);
            }
            else
            {
                Hearts[i].gameObject.SetActive(false);
            }
        } 
    }

    public void Reset()
    {
        for(int i = 0;i < Hearts.Length; i++)
        {
            Hearts[i].gameObject.SetActive(true);
        }
    }
}
