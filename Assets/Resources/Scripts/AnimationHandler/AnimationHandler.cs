using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public bool isStop = false;

    // Animation animation;
    Animator animator;
    float speedDefault;
    private void Start() {
        // animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        speedDefault = animator.speed;
    }

    private void Update() {
        if(isStop){
            animator.speed = 0;
        } else {
            animator.speed = speedDefault;
        }
    }
}
