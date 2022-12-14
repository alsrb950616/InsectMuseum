using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMode : MonoBehaviour
{
    [SerializeField] private List<GameObject> _loadpanels = null;
    [SerializeField] private GameObject _game = null;
    [SerializeField] private List<GameObject> Germs = null;
    [SerializeField] private GameObject _resultPanelObj = null;
    [SerializeField] private ResultPanel _resultPanel = null;

    private bool IsStart = false;

    private float MaxLimittime = 60.0f;
    private float Limittime = 0;
    private float Maxcunt = 9.0f;
    private float Deathcount = 0.0f;
    private float Criterianum = 0; // 결과를 위한 기준 번호
    private int CurrentPhase = 0;


    private void Awake()
    {
        foreach (var go in _loadpanels)
            go.SetActive(false);
        //foreach(var go in Germs)
        //    go.SetActive(false);
        _resultPanelObj.SetActive(false);
        _game.SetActive(false);

        Limittime = 60.0f; // 제한시간 1분
        Debug.Log("Germs.Count :" + Germs.Count);
        Criterianum = (Germs.Count / 3);
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
            //Debug.Log("Game Start");
            StartTimer();

            if (Limittime > 0) // 시간이 남아있을 때
            {
                if (Deathcount != Maxcunt) return; // 세균을 다 잡기전에 끝나지 않을테니까
                Debug.Log("Game Over1");
                _game.SetActive(false);
                _resultPanelObj.SetActive(true);
                _resultPanel.OpenResult(GetResultNum());
            }
            else // 시간 경과 시
            {
                Debug.Log("Game Over2");
                _game.SetActive(false);
                _resultPanelObj.SetActive(true);
                _resultPanel.OpenResult(GetResultNum());
            }
        }
    }

    void StartTimer()
    {
        Limittime -= Time.deltaTime;
    }

    public int GetResultNum() // 결과창 오픈
    {
        int result = 0;
        Debug.Log("Deathcount : " + Deathcount + ", Criterianum : " + Criterianum);
        if (Deathcount != 0)
            result = (int)(Deathcount / Criterianum);
        Debug.Log("result : " + result);
        return result;
    }

    public void onAnimationEnvent()
    {
        IsStart = true;
        _loadpanels[CurrentPhase].SetActive(false);
        _game.SetActive(true);
    }

    public void OnButtonEvent()
    {
        _loadpanels[CurrentPhase].SetActive(false);

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

    public void PlusDeathcunt()
    {
        Debug.Log("Before Deathcount :" + Deathcount);
        Deathcount++;
        Debug.Log("After Deathcount :" + Deathcount);
    }
}
