using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static readonly string NAME = "Food";
    float timer;
    readonly long BASIC_SCORE = 50;
    bool onGround;
    readonly float TIME_PICKUP = 5;
    float gravityDefault;
    Rigidbody2D rigidbody2D;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(1000, 10000) % 360);
    
        rigidbody2D = GetComponent<Rigidbody2D>();

        gravityDefault = rigidbody2D.gravityScale;
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            rigidbody2D.gravityScale = 0;
            return;
        } else {
            rigidbody2D.gravityScale = gravityDefault;
        }

        if(!onGround){
            foreach(Collider2D collider in Physics2D.OverlapBoxAll(transform.position,
                GetComponent<BoxCollider2D>().size, 0)){
                if(collider.name.Contains("Ground")){
                    onGround = true;
                }
            }
        }

        if(onGround){
            timer += Time.deltaTime;
            if(timer >= TIME_PICKUP){
                DestroyObject();
            }
        }
    }

    public void DestroyObject(){
        Destroy(gameObject);
    }

    public long GetScore(){
        return BASIC_SCORE * Int32.Parse(name.Substring(NAME.Length, 2));
    }
}
