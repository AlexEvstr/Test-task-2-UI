using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager Instance { get; private set; }

    [SerializeField] private bool vibrationEnabled = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Vibration.Init();
    }

    public void Vibrate()
    {
        if (!vibrationEnabled) return;

#if UNITY_ANDROID
        Vibration.VibratePop();
#endif
    }

    public void VibrateHeavy()
    {
#if UNITY_ANDROID
        Vibration.VibratePeek();
#endif
    }

    public void SetVibrationEnabled(bool enabled)
    {
        vibrationEnabled = enabled;
    }

    public bool IsVibrationEnabled()
    {
        return vibrationEnabled;
    }
}
