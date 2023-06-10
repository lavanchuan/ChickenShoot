using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPauseGame : MonoBehaviour
{
    Controller controller;
    public static readonly string TAG = "BtnPause";
    Animator animator;
    public bool isPause;
    bool clicked;
    BoxCollider2D boxCollider2D;
    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        animator = GetComponent<Animator>();
        Vector3 relativePos = Camera.main.ScreenToWorldPoint(new Vector3(
            GameSetting.WIDTH/2,
            GameSetting.HEIGHT,
            0
        ));
        relativePos = new Vector3(relativePos.x, relativePos.y - transform.localScale.y, 0);
        transform.position = relativePos;

        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        animator.SetBool("IsPause", isPause);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider2D.size, 0);
        foreach(Collider2D collider in colliders){
            if(!clicked && collider.name.Contains(TouchCheck.NAME)){
                StartCoroutine(EffectPauseClick());
                PauseGame();
            }
        }
    }

    void PauseGame(){
        if(controller.gameState == GameDefine.GameState.PLAY){
            isPause = true;
            controller.gameState = GameDefine.GameState.PAUSE;
        } else {
            isPause = false;
            controller.gameState = GameDefine.GameState.PLAY;
        }
    }

    IEnumerator EffectPauseClick(){
        clicked = true;
        yield return new WaitForSeconds(0.5f);
        clicked = false;
    }

    // public void ClickButtonPause(){
    //     if(!clicked){
    //         StartCoroutine(EffectPauseClick());
    //         PauseGame();
    //     }
    // }

    public void DisableButton(){
        this.enabled = false;
    }
}
