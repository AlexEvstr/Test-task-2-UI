using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private float scaleMultiplier = 0.9f;
    [SerializeField] private float animationDuration = 0.1f;
    [SerializeField] private Ease ease = Ease.OutQuad;

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill(true);
        transform.DOScale(_originalScale * scaleMultiplier, animationDuration).SetEase(ease);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetScale();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetScale();
    }

    private void ResetScale()
    {
        transform.DOKill(true);
        transform.DOScale(_originalScale, animationDuration).SetEase(ease);
    }
}
