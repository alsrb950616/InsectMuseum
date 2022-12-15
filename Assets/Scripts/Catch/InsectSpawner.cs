using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabs = null;

    [SerializeField] private BoxCollider2D _collision = null;

    // Start is called before the first frame update

    private float _tickTime = 0;
    private float _spawnTime = 0;
    private float _defaultTime = 1.0f;


    [SerializeField] private int _spawnCount = 0;
    void Start()
    {
        _spawnTime = _defaultTime + Random.Range(0.5f, 0.8f);        
    }

    // Update is called once per frame
    void Update()
    {
        if(_tickTime >= _spawnTime)
        {
            _tickTime = 0;
            _spawnTime = _defaultTime + Random.Range(0.5f, 0.8f);
            SpawnInsect();
        }
        else
        {
            _tickTime += Time.deltaTime;
        }
    }

    private void SpawnInsect()
    {
        if (_spawnCount >= 1) return;
        Vector2 colliderPos = _collision.offset;
        float randomPosX = Random.Range(-1 * (_collision.size.x / 2), _collision.size.x / 2);
        float randomPosY = Random.Range(-1 * ( _collision.size.y / 2), _collision.size.y / 2);

        CatchInsectScript insect = Instantiate(_prefabs,  this.transform).GetComponent<CatchInsectScript>();
        insect.Setup(_collision, this);

        _spawnCount++;
    }

    public BoxCollider2D GetCollider()
    {
        return _collision;
    }

    public void Despawn()
    {
        _spawnCount--;
    }
}
