using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour 
{
    public List<QuestionsAndAnswers> QA;
    public int currentQuestion;
    public bool isCorrect = false;

    public Text questionText;
    public Text answeredQuestionsText;
    public Text timerText;
    public Text answeredQuestionsCount;

    public int answeredQuestions = 0;

    public string clickedButton;

    public Score score;

    public float timer = 20.0f;
    public float remainingTime;
    public int scoreMultiplier;
    public enum TimerSelector
    { 
        EASY,
        NORMAL,
        HARD,
        NOTIME
    }
    public TimerSelector selectedTimer;

    public int questionsToCycle;
    public enum QuestionAmmountSelector
    { 
        TEN,
        TWENTYFIVE,
        ALL
    }
    public QuestionAmmountSelector questionAmmount;

    public LoadImages loadImages;

    public AudioSource click;
    public AudioSource correct;
    bool isMuted = false;

    public GameObject GamePanel;
    public GameObject GameOverPanel;

    private void Start()
    {
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        CheckQuestionAmmount();
        SetQuestionAmmount();
        CheckTimer();
        SetTimer();
        GenerateQuestion();

        SetQuestionsText();

        if (PlayerPrefs.HasKey("isMuted"))
        {
            isMuted = bool.Parse(PlayerPrefs.GetString("isMuted"));
        }
        else
        {
            isMuted = false;
        }
        LoadSound();

        Debug.Log(isMuted);
    }
    void Update()
    {
        if (selectedTimer != TimerSelector.NOTIME)
        {
            TimerCountdown();
        }
    }
    void GenerateQuestion()
    {
        if (questionsToCycle - 1 > answeredQuestions)
        {
            currentQuestion = Random.Range(0, QA.Count);

            questionText.text = QA[currentQuestion].Question;

            clickedButton = "";

            SetTimer();

        }
        else
        {
            Debug.Log("No more questions");
            GameOver();
        }
    }
    public void SetAnswer()
    {
        if (QA[currentQuestion].CorrectAnswers.ToString() == clickedButton)
        {
            isCorrect = true;
            CorrectAnswer();           
        }
        else
        {
            isCorrect = false;
            WrongAnswer();
        }
    }
    public void CorrectAnswer()
    {
        QA.RemoveAt(currentQuestion);
        score.AddScore(100);
        score.AddScore(scoreMultiplier * Mathf.RoundToInt(remainingTime));
        GenerateQuestion();
        AnsweredQuestionIncrement();
        correct.Play();
    }
    public void WrongAnswer()
    {
        GameOver();
    }
    private void AnsweredQuestionIncrement()
    {
        answeredQuestions++;
        SetQuestionsText();
    }

    private void SetQuestionsText()
    {
        answeredQuestionsText.text = answeredQuestions + 1 + " / " + questionsToCycle;
    }
    public void CheckQuestionAmmount()
    {
        int checkedQuestionAmmount = PlayerPrefs.GetInt("QuestionsAmmount");
        switch (checkedQuestionAmmount)
        {
            case 10:
                questionAmmount = QuestionAmmountSelector.TEN;
                break;
            case 25:
                questionAmmount = QuestionAmmountSelector.TWENTYFIVE;
                break;
            case 254:
                questionAmmount = QuestionAmmountSelector.ALL;
                break;
            default:
                questionAmmount = QuestionAmmountSelector.TEN;
                break;
        }
    }
    public void SetQuestionAmmount()
    {
        switch (questionAmmount)
        {
            case QuestionAmmountSelector.TEN:
                questionsToCycle = 10;
                break;
            case QuestionAmmountSelector.TWENTYFIVE:
                questionsToCycle = 25;
                break;
            case QuestionAmmountSelector.ALL:
                questionsToCycle = QA.Count;
                break;
            default:
                 questionsToCycle = 10;
                break;
        }
    }
    private void TimerCountdown()
    {        
        timer -= Time.deltaTime;
        remainingTime = timer;
        timerText.text = "Време\n" + timer.ToString("F2");
        if (timer <= 0)
        {
            GameOver();
            enabled = false;
        }
    }
    public void CheckTimer() 
    {
       int timerTime = PlayerPrefs.GetInt("TimerTime");
       switch (timerTime)
       {
            case 0:
                selectedTimer = TimerSelector.NOTIME;
                break;
            case 30:
                selectedTimer = TimerSelector.EASY;
                break;
            case 20:
                selectedTimer = TimerSelector.NORMAL;
                break;
            case 10:
                selectedTimer = TimerSelector.HARD;
                break;
            default:
                selectedTimer = TimerSelector.NOTIME;
                break;
       }
    }
    public void SetTimer()
    {
        switch (selectedTimer)
        {
            case TimerSelector.EASY:
                timer = 30.0f;
                scoreMultiplier = 1;
                break;
            case TimerSelector.NORMAL:
                timer = 20.0f;
                scoreMultiplier = 4;
                break;
            case TimerSelector.HARD:
                timer = 10.0f;
                scoreMultiplier = 12;
                break;
            case TimerSelector.NOTIME:
                timerText.text = "Време\n∞";
                break;
            default:
                break;
        }
    }
    public void GameOver() 
    {
        score.CheckHighscore();
        GamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        score.SetHighscore();
        score.SetFinalScoreText();
        answeredQuestionsCount.text = answeredQuestions + 1 + " / " + questionsToCycle;
        loadImages.LoadScoreUI();
    }
    public void Restart()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMenu()
    {
        click.Play();
        SceneManager.LoadScene(0);
    }
    public void Mute() 
    {
        isMuted = !isMuted;
        PlayerPrefs.SetString("isMuted", isMuted.ToString());
        LoadSound();
        Debug.Log(isMuted);
        Debug.Log(PlayerPrefs.GetString("isMuted"));
    }
    public void LoadSound()
    {
        if (isMuted == true)
        {
            loadImages.LoadMuteSoundUI();
            AudioListener.volume = 0;
        }
        else if (isMuted == false)
        {
            loadImages.LoadSoundUI();
            AudioListener.volume = 1;
        }
    }
}
