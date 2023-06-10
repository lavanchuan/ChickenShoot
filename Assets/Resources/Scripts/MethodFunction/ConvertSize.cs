using UnityEngine;

public class ConvertSize{

    public static float GetRelativeSize(float pixelSize){
        Vector2 p1 = new Vector2(0,0);
        Vector2 p2 = new Vector2(pixelSize, 0);
        return Mathf.Abs(Camera.main.ScreenToWorldPoint(p2 - p1).x);
    }

    public static float GetPixelSize(float relativeSize){
        Vector2 p1 = new Vector2(0,0);
        Vector2 p2 = new Vector2(relativeSize, 0);
        return Mathf.Abs(Camera.main.WorldToScreenPoint(p2 - p1).x);
    }
}