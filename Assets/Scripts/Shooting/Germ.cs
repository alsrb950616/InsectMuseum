using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Germ : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;
    [SerializeField] private List<GameObject> _germs = null;
    [SerializeField] private List<GameObject> _vacsines = null;
    [SerializeField] private GameObject _dieMotion = null;

    private int _hp = 0;
    private int _scaleNum = 0;
    private bool _isDead = false;
    private float _deathTime = 0;
    private GameObject _dieEffect = null;
    private void Awake()
    {
        foreach (var go in _germs)
            go.SetActive(false);

        foreach (var go in _vacsines)
            go.SetActive(false);
    }
    void Start()
    {
        _scaleNum = Random.Range(0, 3);

        Debug.Log("_scaleNum : " + _scaleNum);

        switch (_scaleNum)
        {
            case 1: // ���̵� �� - ũ�� �� �۾���
                gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0);
                _hp = 2;
                break;
            case 2: // ���̵� �� - ũ�� �� Ŀ��
                gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 0);
                _hp = 0;
                break;
            default: // ���̵� ��
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                _hp = 1;
                break;
        }

        _germs[_hp].SetActive(true);
    }

    private void Update()
    {
        if (_isDead)
        {
            if(_dieMotion != null)
            {
                if(_dieEffect == null)
                {
                    _dieEffect = Instantiate(_dieMotion, transform.position, Quaternion.identity); // ����Ʈ ����
                }
            }
            _deathTime += Time.deltaTime;

            if (_deathTime >= 1.5) // ����° ����� �����ְ� ����Ʈ ����Ǵ� �ð�
                Die();
        }
    }

    private void OnEnable()
    {
        //_scaleNum = Random.Range(0, 3);

        //Debug.Log("_scaleNum : " + _scaleNum);

        //switch (_scaleNum)
        //{
        //    case 1: // ���̵� �� - ũ�� �� �۾���
        //        gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0);
        //        _hp = 2;
        //        break;
        //    case 2: // ���̵� �� - ũ�� �� Ŀ��
        //        gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 0);
        //        _hp = 0;
        //        break;
        //    default: // ���̵� ��
        //        _hp = 1;
        //        break;
        //}

        //_germs[_hp].SetActive(true);

    }

    public void OnDamage()
    {
        Debug.Log("Germ OnDam");
        Debug.Log("before HP : " + _hp);

        foreach(var obj in _germs)
        {
            obj.SetActive(false);
        }
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
        //foreach (var go in _germs)
        //    Destroy(go);
        Destroy(this.gameObject); // �ڽ��� ������ �ִ� ������Ʈ �ı�
    }

}
