using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Germ : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;
    [SerializeField] private List<GameObject> _germs = null;
    [SerializeField] private List<GameObject> _vacsines = null;

    private int HP = 0;


    private void Awake()
    {
        foreach (var go in _germs)
            go.SetActive(false);

        foreach (var go in _vacsines)
            go.SetActive(false);
    }
    void Start()
    {
        _germs[HP].SetActive(true);
    }

    public void OnDamage()
    {
        Debug.Log("Germ OnDam");

        _germs[HP].SetActive(false);
        _vacsines[HP].SetActive(true);
        HP++;

        if (HP>=3)
        {
            _shootingMode.PlusDeathcunt();

            Die();
        }

        _germs[HP].SetActive(true); // 3은 없으니까
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
