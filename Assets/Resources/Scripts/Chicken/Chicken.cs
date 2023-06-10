using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public static readonly int MAX_LEVEL = 19;
    public long health;
    public bool attacked;
    int level;
    public static readonly int HEALTH_BASIC = 5;
    Space space;
    ScoreNumber scoreNumber;

    Controller controller;

    Player player;

    // Score
    public long score;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        player = GameObject.FindGameObjectWithTag(Player.TAG).GetComponent<Player>();

        space = GameObject.FindGameObjectWithTag(Space.TAG).GetComponent<Space>();
        scoreNumber = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<ScoreNumber>();

        level = GameObject.FindGameObjectWithTag(Space.TAG).GetComponent<Space>()
            .GetChickenLevelCurrent();
        // health = HEALTH_BASIC * level * (long)Math.Pow(10, (int)level/HEALTH_BASIC);

        // score = health;
    }

    void Update()
    {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.localPosition, transform.localScale, 0);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Bullet.NAME)){
                try{
                    Bullet bullet = collider.gameObject.GetComponent<Bullet>();
                    if(!attacked){
                        StartCoroutine(EffectAttacked());
                        bullet.hardLevel -= level;
                        DecreaseHealth(bullet.damage);

                        if(bullet.hardLevel <= 0)
                            bullet.DestroyBullet();
                    }
                } catch (Exception){}
            }
        }
    }

    void DecreaseHealth(long damage){
        this.health -= damage;
        if(health <= 0){
            GetComponent<BoxCollider2D>().isTrigger = true;
            this.health = 0;
            GetComponent<DropItemByChicken>().DropItemObject();
            // decrease sum chicken invader
            space.DecreaseSumChickenInvader();
            // increase score number
            scoreNumber.IncreaseScoreNumber(score);
            // destroy this
            Destroy(gameObject);
        }
    }

    IEnumerator EffectAttacked(){
        attacked = true;
        yield return new WaitForSeconds(0.2f);
        attacked = false;
    }
}
