using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainQuestion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MainText;
    [SerializeField] private TextMeshProUGUI Question;
    [SerializeField] private ButtonQuestion firstQuestions;
    [SerializeField] private ButtonQuestion secondQuestions;
    [SerializeField] private ButtonQuestion thirdQuestions;
    [SerializeField] private Enviromment tempScript;
    [SerializeField] private Enviromment humidtyScript;
    [SerializeField] private Enviromment locationScript;
    [SerializeField] private ClearStar clearStar;
    [SerializeField] private Heart heart;
    [SerializeField] private EnvironmentEnum environment;
    [SerializeField] private GameObject checkObject;

    private string insectName = string.Empty;
    private bool temperatureOff = false;
    private bool humidityOff = false;
    private bool locationOff = false;
    private bool interactable = false;
    private int clearInt = 0;
    private int deathCount = 3;


    private void Awake()
    {
        environment = EnvironmentEnum.Temperature;
    }

    private void OnEnable()
    {
        checkObject.SetActive(true);
        Setting();
    }

    private void OnDisable()
    {
        Reset();
    }

    public void Setting()
    {
        foreach (var Contents in EcologistController.Instance.Contents)
        {
            if (Contents.EcologistEnum == EcologistController.Instance.EcologistEnum)
            {
                MainText.text = "알에서 이제 막 깨어난 " + Contents.Name + "!! " + Contents.Name + "의 성장을 도와주세요";
                insectName = Contents.Name;
                for (int i = 0; i < Contents.ContentsStats.Count; i++)
                {
                    if (environment == Contents.ContentsStats[i].environmentEnum)
                    {
                        Question.text = Contents.ContentsStats[i].question;
                        string answer = string.Empty;
                        if (environment == EnvironmentEnum.Temperature) answer = Contents.Temperature;
                        if (environment == EnvironmentEnum.Location) answer = Contents.Location;
                        if (environment == EnvironmentEnum.Humidity) answer = Contents.Humidity;
                        if (firstQuestions != null) firstQuestions.SetQuestion(Contents.ContentsStats[i].firstProblem, Contents.ContentsStats[i].firstProblem.Equals(answer));
                        if (secondQuestions != null) secondQuestions.SetQuestion(Contents.ContentsStats[i].secondProblem, Contents.ContentsStats[i].secondProblem.Equals(answer));
                        if (thirdQuestions != null) thirdQuestions.SetQuestion(Contents.ContentsStats[i].thirdProblem, Contents.ContentsStats[i].thirdProblem.Equals(answer));

                    }
                }
            }
        }
    }

    public void FirstSelect()
    {
        if (interactable)
            return;
        interactable = true;
        bool check = firstQuestions.SelectQuestion();
        Select(check);
        if (check)
        {
            clearInt++;
            StartCoroutine(ClearCorutine());
        }
        else
        {
            deathCount--;
            heart.CheckHeart(deathCount);
            StartCoroutine(FailCorutine());
        }

    }

    public void SecondSelect()
    {
        if (interactable)
            return;
        interactable = true;
        bool check = secondQuestions.SelectQuestion();
        Select(check);
        if (check)
        {
            clearInt++;
            StartCoroutine(ClearCorutine());
        }
        else
        {
            deathCount--;
            heart.CheckHeart(deathCount);
            StartCoroutine(FailCorutine());
        }
    }

    public void ThirdSelect()
    {
        if (interactable)
            return;
        interactable = true;
        bool check = thirdQuestions.SelectQuestion();
        Select(check);
        if (check)
        {
            clearInt++;
            StartCoroutine(ClearCorutine());
        }
        else
        {
            deathCount--;
            heart.CheckHeart(deathCount);
            StartCoroutine(FailCorutine());
        }
    }

    public void Select(bool check)
    {
        firstQuestions.SelectQuestion();
        secondQuestions.SelectQuestion();
        thirdQuestions.SelectQuestion();
        if (environment == EnvironmentEnum.Temperature)
        {
            temperatureOff = true;
            tempScript.SetClear(check);
            if (!locationOff) environment = EnvironmentEnum.Location;
            if (!humidityOff) environment = EnvironmentEnum.Humidity;
        }
        else if (environment == EnvironmentEnum.Humidity)
        {
            humidityOff = true;
            humidtyScript.SetClear(check);
            environment = EnvironmentEnum.Location;
            if (!temperatureOff) environment = EnvironmentEnum.Temperature;
            if (!locationOff) environment = EnvironmentEnum.Location;
        }
        else if (environment == EnvironmentEnum.Location)
        {
            locationOff = true;
            locationScript.SetClear(check);
            if (!temperatureOff) environment = EnvironmentEnum.Temperature;
            if (!humidityOff) environment = EnvironmentEnum.Humidity;
        }
    }

    public void Temp()
    {
        if (!temperatureOff)
        {
            ResetQuestion();
            environment = EnvironmentEnum.Temperature;
            Setting();
        }
    }

    public void Humidty()
    {
        if (!humidityOff)
        {
            ResetQuestion();
            environment = EnvironmentEnum.Humidity;
            Setting();
        }
    }

    public void Location()
    {
        if (!locationOff)
        {
            ResetQuestion();
            environment = EnvironmentEnum.Location;
            Setting();
        }
    }

    public void EndQuestion()
    {
        clearStar.gameObject.SetActive(false);
        ResetQuestion();
        if (temperatureOff && humidityOff && locationOff)
        {
            string a = string.Empty;
            if (clearInt > 0)
            {
                a = "여러분 덕분에 " + insectName + " 치료에 성공했어요";
            }
            else
            {
                a = "아쉽게도 " + insectName + " 치료에 실패하였어요";
            }
            EcologistController.Instance.Clear(clearInt, a);
        }
        if (!temperatureOff || !humidityOff || !locationOff)
        {
            checkObject.SetActive(true);
            Setting();
        }
    }

    public void ResetQuestion()
    {
        clearStar.gameObject.SetActive(false);
        firstQuestions.Reset();
        secondQuestions.Reset();
        thirdQuestions.Reset();
        interactable = false;
    }

    public void Reset()
    {
        clearInt = 0;
        deathCount = 3;

        temperatureOff = false;
        humidityOff = false;
        locationOff = false;
        environment = EnvironmentEnum.Temperature;

        tempScript.Reset();
        humidtyScript.Reset();
        locationScript.Reset();
        heart.Reset();
        ResetQuestion();
    }

    IEnumerator ClearCorutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        clearStar.gameObject.SetActive(true);
        checkObject.SetActive(false);
        EcologistController.Instance.SizeUp(clearInt);
        clearStar.SetUp(clearInt);
    }

    IEnumerator FailCorutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        EndQuestion();
    }
}
