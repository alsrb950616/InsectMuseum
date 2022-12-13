using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreatorScript : MonoBehaviour
{
    [SerializeField] private GameObject _prefab = null;
    [SerializeField] private FoobMainCanvasScript _main = null;
    [SerializeField] private float _defaultDelay = 1.0f;
    private float _autoDelay = 0.0f;

    private float _tickTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_tickTime >= (_defaultDelay + _autoDelay))
        {
            InsectFoodScript food = Instantiate(_prefab, this.transform).GetComponent<InsectFoodScript>();


            food.Setup(Random.Range(0, 6), _main);
            _tickTime = 0;
            _autoDelay = Random.Range(0.2f, 0.7f);
        }
        else
        {
            _tickTime += Time.deltaTime;
        }
    }

    
}
