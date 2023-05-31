using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayBeBroken : MonoBehaviour
{
    private void Update() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.localPosition, transform.localScale.x/2);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Bullet.NAME)){
                collider.GetComponent<Bullet>().ThroughObject();
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition, transform.localScale.x/2);
    }
}
