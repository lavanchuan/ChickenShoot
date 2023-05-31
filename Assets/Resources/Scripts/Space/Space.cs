using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    float deltaTimeDrop = 1f;
    void Start()
    {
        transform.localPosition = (Vector2)Camera.main.ScreenToWorldPoint(
            new Vector2(GameSetting.WIDTH/2, GameSetting.HEIGHT));
        StartCoroutine(EffectDropObject(deltaTimeDrop));
    }

    IEnumerator EffectDropObject(float effectTime){
        while(true){
            yield return new WaitForSeconds(effectTime);
            CreateRock();
        }
    }

    void CreateRock(){
        GameObject rock = (GameObject)Instantiate(Resources.Load("Prefabs/Objects/Rock"));
        rock.transform.localPosition = Position.GetRandomRelativePosition(transform.localPosition.y);
    }
}
