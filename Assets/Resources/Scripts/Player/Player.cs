using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    int pointHealthCurrent = 3;
    bool beingTreated;
    float beingTreatedTimer;
    public static readonly float TIME_BEING_TREATED = 5f;
    public static readonly string NAME = "Player";

    private void Start() {
        Vector2 relativePos =
            (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(GameSetting.WIDTH/2, 
            0));
        transform.localPosition = new Vector3(relativePos.x, 
            relativePos.y + transform.localScale.y, 0);
        
    }

    private void Update() {
        
        updatePosition();

        if(beingTreated){
            beingTreatedTimer += Time.deltaTime;
            if(beingTreatedTimer >= TIME_BEING_TREATED){
                beingTreatedTimer = 0;
                beingTreated = false;
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<SpriteRenderer>().color = Color.red;
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
            if(pointHealthCurrent < 0){
                Destroy(gameObject);
            }
        }
    }
}
