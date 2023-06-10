using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public static readonly float MIN_FALLING_SPEED = 0.01f;
    public static readonly float MAX_FALLING_SPEED = 0.1f;
    float fallingSpeed = MIN_FALLING_SPEED;
    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        transform.Translate(Vector2.down * fallingSpeed);

        if(transform.localPosition.y < Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y){
            Destroy(gameObject);
        }
    }

    public void SetFallingSpeed(float fallingSpeed){
        this.fallingSpeed = fallingSpeed;
        if(this.fallingSpeed < MIN_FALLING_SPEED) this.fallingSpeed = MIN_FALLING_SPEED;
        else if(this.fallingSpeed > MAX_FALLING_SPEED) this.fallingSpeed = MAX_FALLING_SPEED;
    }

    public float GetFallingSpeed(){return this.fallingSpeed;}
}
