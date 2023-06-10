using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingAttackByBullet : MonoBehaviour
{
    Space space;
    Boss boss;
    Player player;
    BoxCollider2D boxCollider2D;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();
        
        player = GameObject.FindGameObjectWithTag(Player.TAG).GetComponent<Player>();

        boss = GetComponent<Boss>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        space = GameObject.FindGameObjectWithTag(Space.TAG).GetComponent<Space>();
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.localPosition, boxCollider2D.size, 0);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Bullet.NAME)){
                try{
                    Bullet bullet = collider.gameObject.GetComponent<Bullet>();
                    boss.health -= bullet.damage;
                    
                    bullet.hardLevel -= space.bossLevel;
                    if(bullet.hardLevel <= 0){
                        bullet.DestroyBullet();
                    }

                    if(boss.health <= 0){
                        boss.BossDie();
                    }
                } catch(Exception){}
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(transform.position, new Vector3(boxCollider2D.size.x,
            boxCollider2D.size.y, 3));
    }
}
