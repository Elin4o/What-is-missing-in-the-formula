using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenu : MonoBehaviour {
    public ToggleGroup questionsGroup;
    public ToggleGroup timerGroup;

    public AudioSource click;

    bool isMuted = false;
    void Start() 
    {
        if (PlayerPrefs.HasKey("isMuted"))
        {
            isMuted = bool.Parse(PlayerPrefs.GetString("isMuted"));
        }
        else
        {
            isMuted = false;
        }
        LoadSound();

    }
    public void SelectDifficulty()
    {
        PlayClickSound();
        Toggle questions = questionsGroup.ActiveToggles().FirstOrDefault();
        Toggle timer = timerGroup.ActiveToggles().FirstOrDefault();
        switch (questions.name)
        {
            case "10":
                Debug.Log("10 questions");
                SetQuestions(10);
                break;
            case "25":
                Debug.Log("25 questions");
                SetQuestions(25);
                break;
            case "All":
                Debug.Log("All questions");
                SetQuestions(254);
                break;
            default:
                SetQuestions(10);
                break;
        }

        switch (timer.name)
        {
            case "None":
                Debug.Log("No timer");
                SetTimer(0);
                break;
            case "30":
                Debug.Log("30 seconds");
                SetTimer(30);
                break;
            case "20":
                Debug.Log("20 seconds");
                SetTimer(20);
                break;
            case "10":
                Debug.Log("10 seconds");
                SetTimer(10);
                break;
            default:
                break;
        }
    }
    public void SetQuestions(byte chosenQuestionOption)
    {
        PlayerPrefs.SetInt("QuestionsAmmount", chosenQuestionOption);
    }
    public void SetTimer(byte chosenTimerOption)
    {
        PlayerPrefs.SetInt("TimerTime", chosenTimerOption);
    }
    public void PlayGame() 
    {
        SelectDifficulty();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void PlayClickSound()
    {
        click.Play();
    }
    public void LoadSound()
    {
        if (isMuted == true)
        {
            AudioListener.volume = 0;
        }
        else if (isMuted == false)
        {
            AudioListener.volume = 1;
        }
    }
}
