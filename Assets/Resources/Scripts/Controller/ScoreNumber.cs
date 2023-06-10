using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNumber : MonoBehaviour
{
    long scoreNumber;

    private void Update() {
    }

    public long GetScoreNumber(){return this.scoreNumber;}
    public void IncreaseScoreNumber(long score){this.scoreNumber += score;}
}
