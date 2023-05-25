using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour {
    Sprite startContainer;
    Sprite gameTitle;
    Sprite playButton;
    Sprite quitButton;
    Sprite infoContainer;
    Sprite infoTitle;

    Sprite questionMenuContainer;
    Sprite questionMenuTitle;
    Sprite timerMenuContainer;
    Sprite timerMenuTitle;
    Sprite buttonContainer;
    Sprite backButton;
    Sprite beginGameButton;

    Sprite backBox;
    Sprite timeImg;
    Sprite questImg;
    Sprite scoreImg;
    Sprite soundImg;
    Sprite questionImage;
    Sprite zero;
    Sprite one;
    Sprite two;
    Sprite three;
    Sprite four;
    Sprite five;
    Sprite six;
    Sprite seven;
    Sprite eight;
    Sprite nine;
    Sprite equal;
    Sprite plus;
    Sprite minus;
    Sprite divide;
    Sprite multiply;

    Sprite scoreContainer;
    Sprite correctQuestions;
    Sprite myScore;
    Sprite highscore;
    Sprite mainMenu;
    Sprite retry;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadMenuUI();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            LoadGameUI();
        }
    }
    public void LoadMenuUI() 
    {
        LoadUI(startContainer, "Box_Orange_Square", "StartContainer");
        LoadUI(gameTitle, "Box_Blank_Square", "GameTitle");
        LoadUI(playButton, "ButtonText_Large_Blank_Square", "StartButton");
        LoadUI(quitButton, "ButtonText_Large_Blank_Square", "ExitButton");
        LoadUI(infoContainer, "Box_Blank_Square", "InfoContainer");
        LoadUI(infoTitle, "Box_Blank_Square", "InfoTitle");
    }
    public void LoadSettingsUI() 
    {
        LoadUI(questionMenuContainer, "Box_Orange_Square", "QuestionAmmount");
        LoadUI(questionMenuTitle, "Box_Orange_Square", "QuestTitle");
        LoadUI(timerMenuContainer, "Box_Orange_Square", "TimerSpeed");
        LoadUI(timerMenuTitle, "Box_Orange_Square", "TimerTitle");
        LoadUI(buttonContainer, "Box_Orange_Square", "ButtonContainer");
        LoadUI(backButton, "ButtonText_Large_Blank_Square", "Back");
        LoadUI(beginGameButton, "ButtonText_Large_Blank_Square", "Play");
    }
    public void LoadGameUI()
    {
        LoadUI(backBox, "ButtonText_Large_Blank_Square", "BackBox");
        LoadUI(timeImg, "IconButton_Small_Blank_Square", "TimeImg");
        LoadUI(questImg, "IconButton_Small_Blank_Square", "QuestionImg");
        LoadUI(scoreImg, "IconButton_Small_Blank_Square", "ScoreImg");

        LoadUI(questionImage, "ButtonText_Large_Blank_Square", "QuestionImage");
        LoadUI(zero, "IconButton_Small_Blank_Square", "0");
        LoadUI(one, "IconButton_Small_Blank_Square", "1");
        LoadUI(two, "IconButton_Small_Blank_Square", "2");
        LoadUI(three, "IconButton_Small_Blank_Square", "3");
        LoadUI(four, "IconButton_Small_Blank_Square", "4");
        LoadUI(five, "IconButton_Small_Blank_Square", "5");
        LoadUI(six, "IconButton_Small_Blank_Square", "6");
        LoadUI(seven, "IconButton_Small_Blank_Square", "7");
        LoadUI(eight, "IconButton_Small_Blank_Square", "8");
        LoadUI(nine, "IconButton_Small_Blank_Square", "9");
        LoadUI(equal, "IconButton_Small_Blank_Square", "=");
        LoadUI(minus, "IconButton_Small_Blank_Square", "-");
        LoadUI(plus, "IconButton_Small_Blank_Square", "+");
        LoadUI(divide, "IconButton_Small_Blank_Square", "÷");
        LoadUI(multiply, "IconButton_Small_Blank_Square", "*");
    }
    public void LoadScoreUI()
    {
        LoadUI(scoreContainer, "Box_Orange_Square", "Container");
        LoadUI(correctQuestions, "ButtonText_Large_Blank_Square", "AnsweredImg");
        LoadUI(myScore, "ButtonText_Large_Blank_Square", "ScoreImg");
        LoadUI(highscore, "ButtonText_Large_Blank_Square", "HighscoreImg");
        LoadUI(mainMenu, "ButtonText_Large_Blank_Square", "MenuButton");
        LoadUI(retry, "ButtonText_Large_Blank_Square", "Restart");
    }

    public void LoadSoundUI()
    {
        LoadUI(soundImg, "Icon_Large_Music_Blank", "Sound");
    }
    public void LoadMuteSoundUI()
    {
        LoadUI(soundImg, "Icon_Large_MusicOff_Blank", "Sound");
    }
    public void LoadUI(Sprite sprite, string resourceToLoad, string imageUI)
    {
        sprite = Resources.Load<Sprite>(resourceToLoad);

        GameObject image = GameObject.Find(imageUI);
        image.GetComponent<Image>().sprite = sprite;
    }
}
