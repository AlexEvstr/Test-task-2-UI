using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _sfxSource;

    [Header("SFX Clips")]
    [SerializeField] private AudioClip _uiClickClip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayUIClick()
    {
        if (_uiClickClip != null)
        {
            _sfxSource.PlayOneShot(_uiClickClip);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }
}