using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float movementSpeed = 10f;
    int hardLevel = 1;
    public static readonly string NAME = "Bullet";
    private void Update() {
        transform.localPosition = new Vector2(transform.localPosition.x,
            transform.localPosition.y + movementSpeed * Time.deltaTime);

        if(transform.localPosition.y > 
            Camera.main.ScreenToWorldPoint(new Vector3(GameSetting.WIDTH, GameSetting.HEIGHT)).y){
            Destroy(gameObject);
        }
    }

    public void ThroughObject(){
        if(--hardLevel <= 0) Destroy(gameObject);
    }
}
