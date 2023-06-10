using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private void Start() {
        if(SystemInfo.deviceType == DeviceType.Handheld){
            transform.localScale = new Vector2(1.2f, 1.2f);
        }
    }
}
