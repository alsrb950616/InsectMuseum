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

    private int Criterianum = 0; // 결과를 위한 기준 번호
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

        Limittime = 60.0f; // 제한시간 1분
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
        if (IsStart) // 게임 화면이 활성화 되면 게임 시작
        {
            StartTimer();

            foreach (var go in _spawners)
                go.SetActive(true); // 스폰하기

            if (Limittime > 0) // 시간이 남아있을 때
            {
                if (Deathcount != Maxcunt) return; // 세균을 다 잡기전에 끝나지 않을테니까

                OpenResult();
            }
            else // 시간 경과 시
            {
                OpenResult();
            }
        }
    }

    void StartTimer()
    {
        Limittime -= Time.deltaTime;
    }

    void OpenResult() // 결과창 오픈
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
