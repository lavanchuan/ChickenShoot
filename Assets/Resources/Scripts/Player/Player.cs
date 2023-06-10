using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly string TAG = "Player";
    public float movementSpeed = 5f;
    int pointHealthCurrent = 3;
    int coinTotal;
    int coinPicked;
    int bulletLevel = 1;
    int bulletQuantity = 1;
    bool beingTreated;
    float beingTreatedTimer;
    public static readonly float TIME_BEING_TREATED = 5f;
    public static readonly string NAME = "Player";
    public static readonly int DAMAGE_BASIC = 5;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        Vector2 relativePos =
            (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(GameSetting.WIDTH/2, 
            0));
        transform.localPosition = new Vector3(relativePos.x, 
            relativePos.y + transform.localScale.y, 0);
        
    }

    private void Update() {
        
        if(controller.gameState != GameDefine.GameState.PLAY) return;

        updatePosition();

        if(beingTreated){
            beingTreatedTimer += Time.deltaTime;
            if(beingTreatedTimer >= TIME_BEING_TREATED){
                beingTreatedTimer = 0;
                beingTreated = false;
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }
    }

    void updatePosition(){
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        if(pos.x < 0) pos = new Vector2(GameSetting.WIDTH, pos.y);
        if(pos.x > GameSetting.WIDTH) pos = new Vector2(0, pos.y);
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.localPosition = new Vector3(pos.x, pos.y, 0);
    }

    public void DecreasePointHealth(int pointHealth){
        if(!beingTreated){
            beingTreated = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().color = Color.black;
            pointHealthCurrent -= pointHealth;
            ResetBulletQuantity();
            if(pointHealthCurrent <= 0){
                PlayerDie();
            }
        }
    }

    public int GetHealthPointCurrent(){
        return this.pointHealthCurrent;
    }

    public void IncreaseCoinPicked(int quantity){
        this.coinPicked += quantity;
    }

    public int GetCoinPicked(){return this.coinPicked;}

    // BULLET
    public void IncreaseBulletQuantity(int quantity){
        this.bulletQuantity += quantity;
        if(this.bulletQuantity >= UpgradeBulletQuantity.MAX_BULLET_QUANTITY){
            if(this.bulletLevel >= Bullet.BULLET_LEVEL_MAX)
                this.bulletQuantity = UpgradeBulletQuantity.MAX_BULLET_QUANTITY;
            else {
                this.bulletLevel++;
                this.bulletQuantity = 1;
            }
        }
        // DEBUG
        // Debug.Log("Level "+ this.bulletLevel+ " Quantity "+ this.bulletQuantity);
    }

    public void ResetBulletQuantity(){
        this.bulletQuantity = 1;
        this.bulletLevel = 1;
    }

    public void PlayerDie(){
        controller.gameState = GameDefine.GameState.DIE;
        Destroy(gameObject);
    }

    public int GetBulletLevel(){return this.bulletLevel;}

    public int GetBulletQuantity(){return this.bulletQuantity;}

    public long GetDamage(){
        return DAMAGE_BASIC * bulletLevel * (long)Math.Pow(10, bulletLevel / 2);
    }
}
