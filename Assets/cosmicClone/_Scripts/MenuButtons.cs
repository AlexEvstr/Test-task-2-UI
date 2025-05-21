using System.Collections;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _charactersWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _ExitWindow;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void CloseCharactersWindow()
    {
        StartCoroutine(SwitchWindows(_charactersWindow, false, _menuWindow, true));
    }

    public void OpenCharactersWindow()
    {
        StartCoroutine(SwitchWindows(_menuWindow, false, _charactersWindow, true));
    }

    public void OpenSettingsWindow()
    {
        StartCoroutine(SwitchWindows(_menuWindow, false, _settingsWindow, true));
    }

    public void CloseSettingsWindow()
    {
        StartCoroutine(SwitchWindows(_settingsWindow, false, _menuWindow, true));
    }

    public void OpenExitWindow()
    {
        StartCoroutine(SwitchWindows(_menuWindow, false, _ExitWindow, true));
    }

    public void CloseExitWindow()
    {
        StartCoroutine(SwitchWindows(_ExitWindow, false, _menuWindow, true));
    }

    private IEnumerator SwitchWindows(GameObject toDisable, bool disableState, GameObject toEnable, bool enableState)
    {
        yield return new WaitForSeconds(0.2f);
        if (toDisable != null) toDisable.SetActive(disableState);
        if (toEnable != null) toEnable.SetActive(enableState);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
        Application.Quit();
#else
        Application.Quit();
#endif
    }
}