using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float movementSpeed = 0.5f;
    public static readonly int MAX_TYPE_ROCK = 2;
    public static readonly float MAX_SCALE = 5;
    public static readonly float MIN_SCALE = 1;
    public static readonly int MAX_LEVEL = 30;

    float deltaTimePlusFallingSpeed = 30f;// 30s
    
    float MaxAngleRota = 45;
    float MinAngleRota = 1;
    float angleRota;

    private void Start() {
        GetComponent<Falling>().SetFallingSpeed(GameObject.FindGameObjectWithTag(Controller.TAG)
        .GetComponent<Timer>().totalTimePlay / deltaTimePlusFallingSpeed * Falling.MIN_FALLING_SPEED);
        if(UnityEngine.Random.Range(1000, 10000) % 10 >= 7){//30%
            angleRota = UnityEngine.Random.Range(MinAngleRota, MaxAngleRota);
            if(transform.localPosition.x > 0) angleRota*=-1;
            transform.rotation = Quaternion.Euler(0,0,angleRota);
        }
    }
}
