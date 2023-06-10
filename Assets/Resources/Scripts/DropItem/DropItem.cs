using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    int quantityItemObject;

    private void Start() {
        if(name.Contains("Boss")){
            quantityItemObject = 10;
        }
    }

    public void DropItemObject(){
        string nameItemObject = DropRate.GetNameItemObjectDropRate();
        if(nameItemObject == "") return;
        GameObject itemObject = (GameObject) Instantiate(Resources.Load("Prefabs/ItemObjects/"+nameItemObject));
        itemObject.transform.localPosition = Position.GetRandomRelativePosition();
    }

    public void DropItemObjects(){
        for(int i = 0; i < quantityItemObject; i++){
            DropItemObject();
        }
    }
}
