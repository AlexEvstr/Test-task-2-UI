using UnityEngine;

public static class AppExitHandler
{
    public static void QuitGame()
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