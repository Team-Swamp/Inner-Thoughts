using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public static void SetTimeScale(int targetTime) => Time.timeScale = targetTime;
}
