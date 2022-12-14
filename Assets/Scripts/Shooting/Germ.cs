using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Germ : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;
    [SerializeField] private List<GameObject> _germs = null;
    [SerializeField] private List<GameObject> _vacsines = null;

    private int _hp = 0;
    private int _scaleNum = 0;
    private bool _isDead = false;
    private float _deathTime = 0;

    private void Awake()
    {
        foreach (var go in _germs)
            go.SetActive(false);

        foreach (var go in _vacsines)
            go.SetActive(false);
    }
    void Start()
    {
        _germs[_hp].SetActive(true);
    }

    private void Update()
    {
        if (_isDead)
        { 
            _deathTime += Time.deltaTime;

            if (_deathTime >= 1)
                Die();
        }
    }

    private void OnEnable()
    {
        _scaleNum = Random.Range(1, 4);

        Debug.Log("_scaleNum : " + _scaleNum);

        switch (_scaleNum)
        {
            case 1: // 난이도 상 - 크기 좀 작아짐
                gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0);
                break;
            case 2: // 난이도 하 - 크기 좀 커짐
                gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 0);
                break;
            default: // 난이도 중
                break;
        }
    }

    public void OnDamage()
    {
        Debug.Log("Germ OnDam");
        Debug.Log("before HP : " + _hp);
        _germs[_hp].SetActive(false);
        _vacsines[_hp].SetActive(true);


        if (_hp>=2)
        {
            _shootingMode.PlusDeathcunt();

            _isDead = true;
        }
        else
        {
        _hp++;
        _germs[_hp].SetActive(true);
        }
        Debug.Log("After HP : " + _hp);

    }

    void Die()
    {
        Debug.Log("Die");
        foreach (var go in _germs)
            Destroy(go);
    }

}
