using System;
using UnityEngine;
using System.Collections;
public class DropRate{

    public static float GetDropRate(){
        return (float)UnityEngine.Random.Range(1000,  10000) % 100;
    }

    public static string GetNameItemObjectDropRate(bool isRock){
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.TAG).GetComponent<GameManager>();
        float rate = GetDropRate();
        // DEBUG
        // Debug.Log("RATE: " + rate);
        ArrayList dropItemList = new ArrayList();
        foreach(RateItemObject rio in gameManager.listItemObjects.listItemObject){
            if(rio.name.Contains(Food.NAME)) continue;
            if(rio.rate >= rate) dropItemList.Add(rio);
        }
        // DEBUG
        // Debug.Log(dropItemList.Count);
        if(dropItemList.Count == 0) return "";
        return ((RateItemObject)dropItemList[UnityEngine.Random.Range(1000, 10000)%dropItemList.Count]).name;
    }

    public static string GetNameItemObjectDropRate(){
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.TAG).GetComponent<GameManager>();
        float rate = GetDropRate();
        // DEBUG
        // Debug.Log("RATE: " + rate);
        ArrayList dropItemList = new ArrayList();
        foreach(RateItemObject rio in gameManager.listItemObjects.listItemObject){
            if(rio.rate >= rate) dropItemList.Add(rio);
        }
        // DEBUG
        // Debug.Log(dropItemList.Count);
        if(dropItemList.Count == 0) return "";
        return ((RateItemObject)dropItemList[UnityEngine.Random.Range(1000, 10000)%dropItemList.Count]).name;
    }
}