using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    int damagePoint = 1;

    Controller controller;

    private void Start() {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();
    }

    private void Update() {
        if(controller.gameState != GameDefine.GameState.PLAY){
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.localPosition, transform.localScale.x/2);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Player.NAME)){
                collider.gameObject.GetComponent<Player>().DecreasePointHealth(damagePoint);
                // Destroy(gameObject);
            }
        }
    }
}
