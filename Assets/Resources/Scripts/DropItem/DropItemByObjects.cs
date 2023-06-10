using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemByObjects : MonoBehaviour
{
    
    public void DropItemObject(){
        string nameItemObject = DropRate.GetNameItemObjectDropRate(true);
        if(nameItemObject == "") return;
        GameObject itemObject = (GameObject) Instantiate(Resources.Load("Prefabs/ItemObjects/"+nameItemObject));
        itemObject.transform.localPosition = transform.localPosition;
    }
}
