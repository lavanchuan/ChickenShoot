using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float totalTimePlay;

    Controller controller;

    void Start()
    {
        controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.gameState == GameDefine.GameState.PLAY){
            totalTimePlay += Time.deltaTime;
        }
    }
}
