using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIButtonAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private float pressedScale = 0.9f;
    [SerializeField] private float animationDuration = 0.1f;
    [SerializeField] private Ease ease = Ease.OutQuad;

    [SerializeField] private bool vibrateOnAndroid = true;

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill(true);
        transform.DOScale(_originalScale * pressedScale, animationDuration).SetEase(ease);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BounceBack();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BounceBack();
    }

    private void BounceBack()
    {
        transform.DOKill(true);
        transform.DOScale(_originalScale, animationDuration).SetEase(ease);
        AudioManager.Instance?.PlayUIClick();
        Vibrate();
    }

    private void Vibrate()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (vibrateOnAndroid)
        {
            Handheld.Vibrate();
        }
#endif
    }
}
