using UnityEngine;
public class Position{
    public static Vector2 GetRandomRelativePosition(float y){
        float distance, x;
        // distance = UnityEngine.Random.Range(0, GameSetting.WIDTH);
        // x = Camera.main.ScreenToWorldPoint(new Vector2(distance, 0)).x;
        // if(x < 0) x += 1;
        // else if(x > 0) x -= 1;

        distance = UnityEngine.Random.Range(0, GameSetting.WIDTH/2);
        x = (UnityEngine.Random.Range(0, 1000) % 2 == 0 ? -1 : 1)
            * Camera.main.ScreenToWorldPoint(new Vector2(distance, 0)).x;
        return new Vector2(x, y);
    }
}