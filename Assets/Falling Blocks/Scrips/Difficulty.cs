using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    static float maxDifficultyTime = 60;

    public static float GetDifficultyPercent()
    {
        //return 1;
        return Mathf.Clamp01(Time.timeSinceLevelLoad/maxDifficultyTime);
    }
}
