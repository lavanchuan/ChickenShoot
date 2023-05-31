using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float movementSpeed = 2f;
    
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x,
            transform.localPosition.y - movementSpeed * Time.deltaTime);

        if(transform.localPosition.y < Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y){
            Destroy(gameObject);
        }
    }
}
