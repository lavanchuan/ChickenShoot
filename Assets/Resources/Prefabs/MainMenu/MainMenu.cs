using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button btnPlay, btnSetting, btnQuit;

    public static readonly string playScene = "Scenes/PlayScene";
    public static readonly string settingScene = "Scenes/SettingScene";
    public static readonly string mainMenuScene = "Scenes/MainMenuScene";

    private void Start() {
        Setup();

        btnPlay.onClick.AddListener(LoadScenePlay);
        btnSetting.onClick.AddListener(LoadSceneSetting);
        btnQuit.onClick.AddListener(Quit);
    }

    public void LoadScenePlay(){
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(playScene);
    }

    void LoadSceneSetting(){
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(settingScene);
    }

    void Quit(){
        Application.Quit();
    }

    void Setup(){
        
    }
}
