using UnityEngine;
using DG.Tweening;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _charactersWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _exitWindow;

    [SerializeField] private Ease popupEase = Ease.OutBack;
    private float popupDuration = 0.5f;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenCharactersWindow() => AnimateSwitch(_menuWindow, _charactersWindow);
    public void CloseCharactersWindow() => AnimateSwitch(_charactersWindow, _menuWindow);

    public void OpenSettingsWindow() => AnimateSwitch(_menuWindow, _settingsWindow);
    public void CloseSettingsWindow() => AnimateSwitch(_settingsWindow, _menuWindow);

    public void OpenExitWindow() => AnimateSwitch(_menuWindow, _exitWindow);
    public void CloseExitWindow() => AnimateSwitch(_exitWindow, _menuWindow);

    private void AnimateSwitch(GameObject from, GameObject to)
    {
        if (from != null)
        {
            from.transform.DOKill();
            from.transform.DOScale(Vector3.zero, popupDuration)
                .SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    from.SetActive(false);

                    if (to != null)
                    {
                        to.SetActive(true);
                        to.transform.localScale = Vector3.zero;
                        to.transform.DOKill();
                        to.transform.DOScale(Vector3.one, popupDuration)
                            .SetEase(popupEase);
                    }
                });
        }
        else if (to != null)
        {
            to.SetActive(true);
            to.transform.localScale = Vector3.zero;
            to.transform.DOKill();
            to.transform.DOScale(Vector3.one, popupDuration)
                .SetEase(popupEase);
        }
    }


    public void QuitGame()
    {
        AppExitHandler.QuitGame();
    }
}