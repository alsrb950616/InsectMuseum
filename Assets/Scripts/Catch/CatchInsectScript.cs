using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInsectScript : MonoBehaviour
{
    private BoxCollider2D _box = null;

    [SerializeField] private Vector3 _goal = Vector3.zero;
    [SerializeField] float _lerpValue = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = 0;
        Vector3 rectPos = this.GetComponent<RectTransform>().anchoredPosition;
       
        dist = Vector2.Distance(rectPos, _goal);
        Debug.Log("update" + dist.ToString());

        if (dist < 10)
        {
            float randomPosX = Random.Range(-1 * ((_box.size.x - 20) / 2), (_box.size.x - 20) / 2);
            float randomPosY = Random.Range(-1 * ((_box.size.y - 20) / 2), (_box.size.y - 20) / 2);

            _goal = new Vector2(randomPosX, randomPosY);
        }

        Vector2 dir = _goal - rectPos;

        
        Vector2 movespeed = dir.normalized * 15.0f * Time.deltaTime;
     
        Vector3 lerpDir = new Vector3(90,dir.y, 0);

        Vector2 rot = Vector2.Lerp(lerpDir, this.GetComponent<RectTransform>().forward, Time.deltaTime);
        this.GetComponent<RectTransform>().forward = rot;

        this.GetComponent<RectTransform>().anchoredPosition += movespeed; 

       
    }

    public void Setup(BoxCollider2D box)
    {
        _box = box;
        
        float randomPosX = Random.Range(-1 * ((_box.size.x-20) / 2), (_box.size.x - 20) / 2);
        float randomPosY = Random.Range(-1 * ((_box.size.y -20)/ 2), (_box.size.y - 20) / 2);
        Debug.Log("aaa : " + randomPosX);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomPosX, randomPosY);
      //  this.transform.position = new Vector3(randomPosX, randomPosY, 0);

        _goal = new Vector2(randomPosX, randomPosY);

    }
}
