using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_SettingController : MonoBehaviour
{

    public Button btnBacktrack;

    void Start()
    {
        btnBacktrack.onClick.AddListener(LoadMainMenuScene);
    }

    void Update()
    {
        
    }

    void LoadMainMenuScene(){
        SceneManager.LoadSceneAsync(MainMenu.mainMenuScene);
    }
}
