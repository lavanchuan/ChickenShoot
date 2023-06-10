using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    
    Player player;
    GameObject touchCheck = null;
    public static readonly string TAG = "GameController";
    public GameDefine.GameState gameState;

    ButtonPauseGame btnPause;

    bool pressKeyEsc;
    readonly float TIME_ACTIVE_ESC = 0.5f;

    bool clickedBtnPause;

    private void Start() {
        gameState = GameDefine.GameState.PLAY;

        player = GameObject.FindGameObjectWithTag(Player.TAG).GetComponent<Player>();

        btnPause = GameObject.FindGameObjectWithTag(ButtonPauseGame.TAG).GetComponent<ButtonPauseGame>();
    }

    private void Update() {
        if(gameState == GameDefine.GameState.DIE){
            btnPause.DisableButton();
        }

        switch(SystemInfo.deviceType){
            case DeviceType.Desktop:
            DesktopController();
            break;
            case DeviceType.Handheld:
            AndroidController();
            break;
        }
    }

    void DesktopController(){
        if(Input.GetMouseButton(0)){
            if(!clickedBtnPause){
                GameObject touchCheck = (GameObject)Instantiate(Resources.Load(
                    TouchCheck.PATH_PREFABS));
                touchCheck.transform.localPosition = Camera.main.ScreenToWorldPoint(
                    Input.mousePosition
                );
                StartCoroutine(EffectClickButtonPause(touchCheck));
            }
        }

        if(gameState == GameDefine.GameState.PLAY){
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                player.transform.position = new Vector3(
                    player.transform.localPosition.x - player.movementSpeed * Time.deltaTime,
                    player.transform.localPosition.y,
                    0
                );
                return;
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                player.transform.position = new Vector3(
                    player.transform.localPosition.x + player.movementSpeed * Time.deltaTime,
                    player.transform.localPosition.y,
                    0
                );
                return;
            }
            if(Input.GetKey(KeyCode.Escape)){
                if(!pressKeyEsc){
                    StartCoroutine(EffectPressedEscKey());
                    gameState = GameDefine.GameState.PAUSE;
                }
                return;
            }
            if(Input.mousePresent){
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                player.transform.position = new Vector3(pos.x,
                    player.transform.localPosition.y,
                    0);
                return;
            }
        } else if(gameState == GameDefine.GameState.PAUSE){
            if(Input.GetKey(KeyCode.Escape)){
                if(!pressKeyEsc){
                    StartCoroutine(EffectPressedEscKey());
                    gameState = GameDefine.GameState.PLAY;
                }
                return;
            }
        }
    }

    IEnumerator EffectPressedEscKey(){
        pressKeyEsc = true;
        yield return new WaitForSeconds(TIME_ACTIVE_ESC);
        pressKeyEsc = false;
    }

    void AndroidController(){
        // if(Input.touchCount > 0){
        //     if(!clickedBtnPause){
        //         GameObject touchCheck = (GameObject)Instantiate(Resources.Load(
        //             TouchCheck.PATH_PREFABS));
        //         Touch touch = Input.GetTouch(0);
        //         touchCheck.transform.localPosition = Camera.main
        //                 .ScreenToWorldPoint(touch.position);
        //         StartCoroutine(EffectClickButtonPause(touchCheck));
        //     }
        // }

        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            switch(touch.phase){
                case TouchPhase.Began:
                touchCheck = (GameObject)Instantiate(Resources.Load(
                    TouchCheck.PATH_PREFABS));
                touchCheck.transform.localPosition = Camera.main
                    .ScreenToWorldPoint(touch.position);
                if(gameState == GameDefine.GameState.PLAY){
                    player.transform.localPosition = new Vector2(touchCheck.transform.localPosition.x,
                        player.transform.localPosition.y);
                }
                break;
                case TouchPhase.Moved:
                if(gameState == GameDefine.GameState.PLAY){
                    touchCheck.transform.localPosition = Camera.main
                        .ScreenToWorldPoint(touch.position);
                    player.transform.localPosition = new Vector2(touchCheck.transform.localPosition.x,
                        player.transform.localPosition.y);
                }
                break;
                case TouchPhase.Ended:
                Destroy(touchCheck);
                break;
            }
        }
        
    }

    IEnumerator EffectClickButtonPause(GameObject touch){
        clickedBtnPause = true;
        yield return new WaitForSeconds(0.1f);
        clickedBtnPause = false;
        Destroy(touch);
    }
}