using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInsectScript : MonoBehaviour
{
    private BoxCollider2D _box = null;

    [SerializeField] private Vector3 _goal = Vector3.zero;
   

    [SerializeField] private List<GameObject> _meshs = null;
    [SerializeField] private CatcherScript _catcher = null;
    [SerializeField] private int _score = 100;
    [SerializeField] private InsectSpawner insectSpawner = null;
    [SerializeField] private GameObject _catchEffect = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_catcher != null) 
        {

            this.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
        else
        {
            float dist = 0;
            Vector3 rectPos = this.GetComponent<RectTransform>().anchoredPosition;

            dist = Vector2.Distance(rectPos, _goal);

            if (dist < 10)
            {
                float randomPosX = Random.Range(-1 * ((_box.size.x - 20) / 2), (_box.size.x - 20) / 2);
                float randomPosY = Random.Range(-1 * ((_box.size.y - 20) / 2), (_box.size.y - 20) / 2);

                _goal = new Vector2(randomPosX, randomPosY);
            }

            Vector2 dir = _goal - rectPos;


            Vector2 movespeed = dir.normalized * 15.0f * Time.deltaTime;

            //Vector2 lerpDir = new Vector2(90,dir.y);

            //Vector2 rot = Vector2.Lerp(lerpDir, this.GetComponent<RectTransform>().forward, Time.deltaTime);
            //this.GetComponent<RectTransform>().forward = new Vector3(rot.y, 90, 0);

            this.GetComponent<RectTransform>().anchoredPosition += movespeed;

        }


    }

    public void Setup(BoxCollider2D box, InsectSpawner spawner)
    {
        _box = box;
        insectSpawner = spawner;

        float randomPosX = Random.Range(-1 * ((_box.size.x-20) / 2), (_box.size.x - 20) / 2);
        float randomPosY = Random.Range(-1 * ((_box.size.y -20)/ 2), (_box.size.y - 20) / 2);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomPosX, randomPosY);
      //  this.transform.position = new Vector3(randomPosX, randomPosY, 0);

        _goal = new Vector2(randomPosX, randomPosY);

        int rand = Random.Range(0, _meshs.Count);

        Instantiate(_meshs[rand], this.gameObject.transform);

    }

    public void InsectCatch(CatcherScript catcher)
    {
        _catcher = catcher;

        this.transform.parent = _catcher.transform;
        _catchEffect.SetActive(true);
    }

    public int GetInsectScore()
    {
        insectSpawner.Despawn();
        Destroy(this.gameObject);
        return _score;
    }
}
