using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public GameObject[] targets;

    private void Start() {
        
    }

    private void Update() {
        foreach(GameObject target in targets){
            float doi = Mathf.Abs(transform.localPosition.x - target.transform.localPosition.x);
            float ke = Mathf.Abs(transform.localPosition.y - target.transform.localPosition.y);
            target.GetComponent<TargetTest>().angle = 
            (transform.localPosition.x > target.transform.localPosition.x ? 1 : -1) * 
            Mathf.Atan(doi / ke) * 180 / Mathf.PI;

        }
    }
}
