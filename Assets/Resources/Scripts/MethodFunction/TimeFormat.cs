public class TimeFormat{
    public static string GetFullTime(float seconds){
        int h = (int)seconds / 360;
        int m = (((int)seconds) - h * 360) / 60;
        int s = ((int)seconds) % 60;
        return (h < 10 ? "0"+h : ""+h) + ":"
            + (m < 10 ? "0"+m : ""+m) + ":"
            + (s < 10 ? "0"+s : ""+s);
    }
}