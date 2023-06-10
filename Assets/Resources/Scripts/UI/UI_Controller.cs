using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public Text ui_healthPoint, ui_coinPicked, ui_bulletQuantity, ui_timer, ui_scoreNumber;
    public Text ui_playerDie;
    public Button btnReplay, btnMainMenu;
    Player player;
    Timer timer;
    ScoreNumber scoreNumber;
    ButtonPauseGame buttonPauseGame;
    static readonly string HEALTH_POINT_SHOW = "♥";
    static readonly string BULLET_SHOW = "B";

    Controller controller;

    // BUTTON
    Vector2 posBtnReplayDefault, posBtnMenuDefault;
    Vector2 posHidden = new Vector2(99999999, 99999999);


    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        player = GameObject.FindGameObjectWithTag(Player.TAG).GetComponent<Player>();
        timer = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Timer>();
        scoreNumber = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<ScoreNumber>();
        buttonPauseGame = GameObject.FindGameObjectWithTag(ButtonPauseGame.TAG).GetComponent<ButtonPauseGame>();

        posBtnReplayDefault = btnReplay.transform.localPosition;
        posBtnMenuDefault = btnMainMenu.transform.localPosition;

        btnReplay.onClick.AddListener(LoadPlayScene);
        btnMainMenu.onClick.AddListener(LoadMainMenuScene);
    }

    private void Update() {
        DrawHealthPointUI();
        DrawCoinPicked();
        DrawBulletQuantity();
        DrawTimer();
        DrawScoreNumber();

        // BUTTON
        if(controller.gameState != GameDefine.GameState.DIE){
            ShowPauseScreen(buttonPauseGame.isPause);
        }

        // PLAYER DIE
        if(controller.gameState == GameDefine.GameState.DIE){
            ShowDieScreen();
        }

    }

    void DrawHealthPointUI(){
        if(player.GetHealthPointCurrent() > 1) ui_healthPoint.color = Color.black;
        else ui_healthPoint.color = Color.red;
        string text = StringFunction.GetMultiplyString(HEALTH_POINT_SHOW, player.GetHealthPointCurrent());
        float width = 0.2f * GameSetting.WIDTH;
        float height = 0.1f * GameSetting.HEIGHT;
        float x = 0;
        float y = GameSetting.HEIGHT/2 - height/2;
        float fontSize = 0.8f * height;
        ui_healthPoint.rectTransform.localPosition = new Vector2(x, y);
        ui_healthPoint.rectTransform.sizeDelta = new Vector2(width, height);
        ui_healthPoint.fontSize = (int)fontSize;
        ui_healthPoint.alignment = TextAnchor.MiddleCenter;
        ui_healthPoint.fontStyle = FontStyle.Bold;
        ui_healthPoint.text = text;
    }

    void DrawCoinPicked(){
        string text = "Coin: " + player.GetCoinPicked();
        float width = 0.2f * GameSetting.WIDTH;
        float height = 0.1f * GameSetting.HEIGHT;
        float x = GameSetting.WIDTH/2 - width - 0.05f * GameSetting.WIDTH;
        float y = GameSetting.HEIGHT/2 - height/2;
        float fontSize = 0.7f * height;
        ui_coinPicked.rectTransform.localPosition = new Vector2(x, y);
        ui_coinPicked.rectTransform.sizeDelta = new Vector2(width, height);
        ui_coinPicked.fontSize = (int)fontSize;
        ui_coinPicked.alignment = TextAnchor.MiddleRight;
        ui_coinPicked.fontStyle = FontStyle.Bold;
        ui_coinPicked.text = text;
    }
public long test;
    void DrawScoreNumber(){
        string text = "Score: " + StringFunction.GetScoreNumberFormat(scoreNumber.GetScoreNumber());//scoreNumber.GetScoreNumber();
        float width = 0.3f * GameSetting.WIDTH;
        float height = 0.1f * GameSetting.HEIGHT;
        float x = GameSetting.WIDTH/2 - width;// - 0.05f * GameSetting.WIDTH;
        float y = GameSetting.HEIGHT/2 - height/2 - height;
        float fontSize = 0.5f * height;
        ui_scoreNumber.rectTransform.localPosition = new Vector2(x, y);
        ui_scoreNumber.rectTransform.sizeDelta = new Vector2(width, height);
        ui_scoreNumber.fontSize = (int)fontSize;
        ui_scoreNumber.alignment = TextAnchor.MiddleRight;
        ui_scoreNumber.fontStyle = FontStyle.Italic;
        ui_scoreNumber.text = text;
    }

    void DrawBulletQuantity(){
        string text = StringFunction.GetMultiplyString(BULLET_SHOW, player.GetBulletQuantity());
        float width = 0.2f * GameSetting.WIDTH;
        float height = 0.1f * GameSetting.HEIGHT;
        float x = -(GameSetting.WIDTH/2 - 0.1f * GameSetting.WIDTH);
        float y = GameSetting.HEIGHT/2 - height/2;
        float fontSize = 0.4f * height;
        ui_bulletQuantity.rectTransform.localPosition = new Vector2(x, y);
        ui_bulletQuantity.rectTransform.sizeDelta = new Vector2(width, height);
        ui_bulletQuantity.fontSize = (int)fontSize;
        ui_bulletQuantity.alignment = TextAnchor.MiddleRight;
        ui_bulletQuantity.fontStyle = FontStyle.Bold;
        ui_bulletQuantity.text = text;
    }

    void DrawTimer(){
        string text = TimeFormat.GetFullTime(timer.totalTimePlay);
        float width = 0.2f * GameSetting.WIDTH;
        float height = 0.1f * GameSetting.HEIGHT;
        float x = -(GameSetting.WIDTH/2 - 0.1f * GameSetting.WIDTH);
        float y = GameSetting.HEIGHT/2 - height/2 - height;
        float fontSize = 0.4f * height;
        ui_timer.rectTransform.localPosition = new Vector2(x, y);
        ui_timer.rectTransform.sizeDelta = new Vector2(width, height);
        ui_timer.fontSize = (int)fontSize;
        ui_timer.alignment = TextAnchor.MiddleCenter;
        ui_timer.fontStyle = FontStyle.Bold;
        ui_timer.text = text;
    }

    void DrawDieScene(){
        string text = "Game Over\nScore: " + scoreNumber.GetScoreNumber();
        float width = 0.8f * GameSetting.WIDTH;
        float height = 0.5f * GameSetting.HEIGHT;
        float x = 0;
        float y = 0.2f * height;
        float fontSize = 0.3f * height;
        ui_playerDie.rectTransform.localPosition = new Vector2(x, y);
        ui_playerDie.rectTransform.sizeDelta = new Vector2(width, height);
        ui_playerDie.fontSize = (int)fontSize;
        ui_playerDie.color = Color.red;
        ui_playerDie.alignment = TextAnchor.MiddleCenter;
        ui_playerDie.fontStyle = FontStyle.Bold;
        ui_playerDie.text = text;
        ui_playerDie.horizontalOverflow = HorizontalWrapMode.Overflow;
        ui_playerDie.verticalOverflow = VerticalWrapMode.Overflow;

        RectTransform replayRT = btnReplay.GetComponent<RectTransform>();
        RectTransform mainMenuRT = btnMainMenu.GetComponent<RectTransform>();
        replayRT.sizeDelta = new Vector2(0.4f * GameSetting.WIDTH,100);
        mainMenuRT.sizeDelta = new Vector2(0.4f * GameSetting.WIDTH,100);
        
        btnReplay.transform.localPosition = posBtnReplayDefault;
        btnMainMenu.transform.localPosition = posBtnMenuDefault;
    }
    public int k, h;

    void ShowPauseScreen(bool isPause){
        if(!isPause){
            btnReplay.transform.localPosition = posHidden;
            btnMainMenu.transform.localPosition = posHidden;
        } else {
            btnReplay.transform.localPosition = posBtnReplayDefault;
            btnMainMenu.transform.localPosition = posBtnMenuDefault;
        }
    }

    void ShowDieScreen(){
        DrawDieScene();
    }

    void LoadPlayScene(){
        SceneManager.LoadScene(MainMenu.playScene);
    }

    void LoadMainMenuScene(){
        SceneManager.LoadScene(MainMenu.mainMenuScene);
    }
}
