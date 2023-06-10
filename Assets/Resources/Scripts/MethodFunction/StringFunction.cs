using System;
public class StringFunction{
    public static readonly long ONE_BILION = 1000000000l;
    public static readonly long ONE_MILION = 1000000l;

    public static string GetMultiplyString(string str, int quantity){
        string rs = "";
        for(int i = 0; i < quantity; i++)
        rs += str;
        return rs;
    }

    public static string GetScoreNumberFormat(long score){
        if((""+score).Length >= 18) return "$$$.$$$++";
        long total = score;
        string result = "";
        long t = total / ONE_BILION;
        if(t > 999) return t + "T+";
        total -= t * ONE_BILION;
        if(t > 0){
            result += t + "T";
            if(total == 0) return result;
        }
        long m = total / ONE_MILION;
        total -= m * ONE_MILION;
        if(m > 0){
            result += m + "M";
            if(total == 0) return result;
        }
        long k = total / 1000;
        total -= k * 1000;
        if(k > 0){
            result += k + "K";
            if(total == 0) return result;
        }
        return result + total;
    }
}