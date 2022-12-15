using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScript : MonoBehaviour
{
    [SerializeField] private GameSystemScript _system = null;
   
    public void AnimationEvent(string data)
    {
        if(data.Equals("start"))
        {
            _system.EnableTimer();
            this.gameObject.SetActive(false);
        }
    }
}
