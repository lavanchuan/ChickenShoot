using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugSizeDevice : MonoBehaviour
{
    public Text debugText;
    public GameObject player;
    string msg = "";

    private void Update() {
        
        getSizeDevice();
        getPosPixelPlayer();
        getDeviceName();

        debugText.text = msg; 
    }

    void getSizeDevice(){
        this.msg = GameSetting.WIDTH + " - " + GameSetting.HEIGHT;
    }

    void getPosPixelPlayer(){
        this.msg += "\nPlayer: " + Camera.main.WorldToScreenPoint(transform.position).ToString();
    }

    void getDeviceName(){
        this.msg += "\nDeviceType: " + SystemInfo.deviceType;
        this.msg += "\nDeviceName: " + SystemInfo.deviceName;
        this.msg += "\nDeviceModel: " + SystemInfo.deviceModel;
        this.msg += "\nDeviceUD: " + SystemInfo.deviceUniqueIdentifier;
    }
}
