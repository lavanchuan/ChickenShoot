using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Controller controller;
    Animator animator;

    float speedAnimatorDefault;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(Controller.TAG).GetComponent<Controller>();

        animator = GetComponent<Animator>();
        speedAnimatorDefault = animator.speed;
    }

    void Update()
    {
        if(controller.gameState != GameDefine.GameState.PLAY){
            animator.speed = 0;
            return;
        }

        animator.speed = speedAnimatorDefault;
    }
}
