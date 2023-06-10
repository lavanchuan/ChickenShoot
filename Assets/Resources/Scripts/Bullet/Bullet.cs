using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float movementSpeed = 0.5f;
    public int hardLevel;
    public long damage;
    public static readonly string NAME = "Bullet";
    public static readonly int BULLET_LEVEL_MAX = 7;
    Player player;
    Controller controller;
    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        player = GameObject.FindGameObjectWithTag(Player.TAG).GetComponent<Player>();
        hardLevel = player.GetBulletLevel();

        damage = 5 * hardLevel * (long)Math.Pow(10, 1 + hardLevel/2);
    }
    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        transform.Translate(Vector2.up * movementSpeed);

        if(transform.localPosition.y >
            Camera.main.ScreenToWorldPoint(new Vector3(GameSetting.WIDTH, GameSetting.HEIGHT)).y){
            Destroy(gameObject);
        }
    }

    public void DecreaseHardLevel(int level){
        this.hardLevel -= level;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }
}
