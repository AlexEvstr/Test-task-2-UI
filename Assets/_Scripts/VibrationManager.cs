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
        DontDestroyOnLoad(gameObject);
    }

    public void Vibrate()
    {
        if (!vibrationEnabled) return;

#if UNITY_ANDROID || UNITY_IOS
        Vibration.Vibrate(50); // лёгкая вибрация, 50ms
#endif
    }

    public void VibrateHeavy()
    {
#if UNITY_ANDROID || UNITY_IOS
        Vibration.Vibrate(100);
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
