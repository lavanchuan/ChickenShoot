using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.localPosition,
            transform.localScale, 0);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Coin.NAME)){
                GetComponent<Player>().IncreaseCoinPicked(Coin.COIN_VALUE);
                // increase score number
                GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<ScoreNumber>()
                .IncreaseScoreNumber(Coin.COIN_VALUE * 1000);
                // destroy this
                Destroy(collider.gameObject);
            } else if(collider.name.Contains(UpgradeBulletQuantity.NAME)){
                GetComponent<Player>().IncreaseBulletQuantity(UpgradeBulletQuantity.bulletQuantity);
                Destroy(collider.gameObject);
            }
        }
    }
}
