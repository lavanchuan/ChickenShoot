using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    int damagePoint = 1;
    private void Update() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.localPosition, transform.localScale.x/2);
        foreach(Collider2D collider in colliders){
            if(collider.name.Contains(Player.NAME)){
                collider.GetComponent<Player>().DecreasePointHealth(damagePoint);
                Destroy(gameObject);
            }
        }
    }
}
