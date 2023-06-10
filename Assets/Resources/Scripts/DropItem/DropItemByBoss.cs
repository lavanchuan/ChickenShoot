using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemByBoss : MonoBehaviour
{
    public void DropItemObject(){
        string nameItemObject = DropRate.GetNameItemObjectDropRate();
        if(nameItemObject == "") return;
        GameObject itemObject = (GameObject) Instantiate(Resources.Load("Prefabs/ItemObjects/"+nameItemObject));
        itemObject.transform.localPosition = transform.localPosition;
    }
}
