using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherScript : MonoBehaviour
{

    [SerializeField] private CatchInsectScript _curInsect = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_curInsect == null)
        {
            if (collision.gameObject.GetComponent<CatchInsectScript>())
            {
                _curInsect = collision.gameObject.GetComponent<CatchInsectScript>();
                _curInsect.InsectCatch(this);
            }
        }
        else
        {
            if(collision.gameObject.GetComponent<PlayerBoxScript>())
            {
                Debug.Log("player Box In");
                collision.gameObject.GetComponent<PlayerBoxScript>().SetScore(_curInsect.GetInsectScore());
                
                _curInsect = null;
            }
        }

    }

}
