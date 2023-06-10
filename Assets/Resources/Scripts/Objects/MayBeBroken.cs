using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayBeBroken : MonoBehaviour
{
    int levelHard;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        float k = (Rock.MAX_SCALE - Rock.MIN_SCALE) / (Rock.MAX_LEVEL - 1);
        levelHard = 1 + (int)((transform.localScale.x % 1) / k);
        // DEBUG
        // Debug.Log(levelHard);
    }
    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.localPosition, transform.localScale.x/2);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Bullet.NAME)){
                try{
                    Bullet bullet = collider.gameObject.GetComponent<Bullet>();

                    this.levelHard -= bullet.hardLevel;
                    bullet.DecreaseHardLevel(levelHard);

                    if(bullet.hardLevel <= 0){
                        bullet.DestroyBullet();
                    }

                    if(this.levelHard <= 0){
                        GetComponent<DropItemByObjects>().DropItemObject();
                        Destroy(gameObject);
                    }
                } catch (Exception){}
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition, transform.localScale.x/2);
    }
}
