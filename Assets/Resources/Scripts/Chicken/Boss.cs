using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static readonly int MAX_LEVEL = 7;

    Vector2 center = new Vector2(0,2);

    public long health;

    Space space;

    Controller controller;

    bool flyToCentered;

    float speedFlyToCenter = 0.01f;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        space = GameObject.FindGameObjectWithTag(Space.TAG).GetComponent<Space>();

        // GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<BoxCollider2D>().enabled = false;
        
        // health = (long)Math.Pow(10, space.bossLevel);

        // StartCoroutine(EffectFlyToCenter());
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        if(!flyToCentered){
            transform.Translate(Vector2.down * speedFlyToCenter);
            if(transform.localPosition.y <= center.y){
                transform.localPosition = center;
                // GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<BoxCollider2D>().enabled = true;
                flyToCentered = true;
            }
        }
    }

    // FLY TO CENTER
    IEnumerator EffectFlyToCenter(){
        while(transform.localPosition.y > center.y){
            yield return new WaitForSeconds(0.01f);
            transform.Translate(Vector2.down * 0.05f);
        }
        transform.localPosition = center;
        GetComponent<BoxCollider2D>().isTrigger = false;
        
    }

    public long GetHealth(){return this.health;}

    public void BossDie(){
        Debug.Log("BOSS DIE");
        GetComponent<BoxCollider2D>().isTrigger = true;
        space.IncreaseBossLevel();

        GetComponent<DropItem>().DropItemObjects();

        Destroy(gameObject);
    }
}

