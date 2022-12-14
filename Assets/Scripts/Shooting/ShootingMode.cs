using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingMode : MonoBehaviour
{
    [SerializeField] private List<GameObject> _loadpanels = null;
    [SerializeField] private GameObject _game = null;
    [SerializeField] private List<GameObject> _spawners = null;
    [SerializeField] private List<GameObject> _resultPanels = null;

    private bool IsStart = false;

    private float MaxLimittime = 0;
    private float Limittime = 0;
    private float Deathcount = 0.0f;
    private float Maxcunt = 9.0f;

    private int Criterianum = 0; // ����� ���� ���� ��ȣ
    private int CurrentPhase = 0;


    private void Awake()
    {
        foreach (var go in _loadpanels)
            go.SetActive(false);
        foreach(var go in _spawners)
            go.SetActive(false);
        foreach (var go in _resultPanels)
            go.SetActive(false);
        _game.SetActive(false);

        Limittime = 60.0f; // ���ѽð� 1��
        MaxLimittime = 60.0f;
        Criterianum = (_spawners.Count / 3);
        CurrentPhase = 0;
    }

    void Start()
    {
        _loadpanels[CurrentPhase].SetActive(true);
    }

    void Update()
    {
        if (IsStart) // ���� ȭ���� Ȱ��ȭ �Ǹ� ���� ����
        {
            StartTimer();

            foreach (var go in _spawners)
                go.SetActive(true); // �����ϱ�

            if (Limittime > 0) // �ð��� �������� ��
            {
                if (Deathcount != Maxcunt) return; // ������ �� ������� ������ �����״ϱ�

                OpenResult();
            }
            else // �ð� ��� ��
            {
                OpenResult();
            }
        }
    }

    void StartTimer()
    {
        Limittime -= Time.deltaTime;
    }

    void OpenResult() // ���â ����
    {
        int result = ((int)Deathcount / Criterianum);

        switch (result)
        {
            case 0:
                _resultPanels[result].SetActive(true);
                break;
            case 1:
                _resultPanels[result].SetActive(true);
                break;
            case 2:
                _resultPanels[result].SetActive(true);
                break;
            case 3:
                _resultPanels[result].SetActive(true);
                break;
            default:
                break;
        }
    }

    void onAnimationEnvent()
    {

    }

    void OnButtonEvent()
    {
        CurrentPhase++;

        _loadpanels[CurrentPhase].SetActive(true);
    }

    public float GetLeftLimitTime()
    {
        return (Limittime / MaxLimittime);
    }

    public float GetDeathcunt()
    {
        return (Maxcunt - Deathcount) / Maxcunt;
    }
}
