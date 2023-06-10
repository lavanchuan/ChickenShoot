using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ListItemObjects listItemObjects;
    public static readonly string TAG = "GameManager";
    void Start()
    {
        listItemObjects = new ListItemObjects();
    }
}
