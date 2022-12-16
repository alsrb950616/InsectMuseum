using HKY;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchEventManager : MonoBehaviour
{
    [SerializeField] private RectTransform recttransform;
    [SerializeField] private URGSensorObjectDetector sensorobject;

    void Update()
    {
        for (int i = 0; i < sensorobject.detectedObjects.Count; i++)
        {
            recttransform.anchoredPosition = sensorobject.detectedObjects[i].position;
            Vector3 mos = recttransform.position - Camera.main.transform.position;
            RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position, mos*500, Color.green);
            if (Physics.Raycast(Camera.main.transform.position, mos, out hit, 500.0f))
            {
                Debug.Log("DrawLine Ray : " + hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "TouchSystem")
                {
                    hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                if (hit.transform.gameObject.tag == "TouchUi")
                {
                    hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
