using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFly : MonoBehaviour
{
    public Vector2 endPos;
    float flySpeed = 0.05f;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }
        FlyOne();
    }

    void FlyOne(){
        if(transform.localPosition.y > endPos.y){
            GetComponent<BoxCollider2D>().isTrigger = true;
            float a = Mathf.Abs(endPos.x - transform.localPosition.x);
            float b = Mathf.Abs(endPos.y - transform.localPosition.y);
            float alpha = (transform.localPosition.x > endPos.x ? -1 : 1)
                * Mathf.Atan(a/b) * 180 / Mathf.PI;
            transform.rotation = Quaternion.Euler(0,0,alpha);
            transform.Translate(Vector2.down * flySpeed);
        } else {
            GetComponent<BoxCollider2D>().isTrigger = false;
            transform.localPosition = endPos;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
