using UnityEngine;
using DG.Tweening;

public class FadingPanel : MonoBehaviour, IVisible
{
    [SerializeField] private CanvasGroup _cellCanvasGroup;
    [SerializeField] private CanvasGroup _taskCanvasGroup;
    [SerializeField] private CanvasGroup _restartCanvasGroup;
  
    private Tween _fadeTween;

    public CanvasGroup CellCanvasGroup  => _cellCanvasGroup;
    public CanvasGroup TaskCanvasGrou=> _taskCanvasGroup;
    public CanvasGroup RestartCanvasGroup => _restartCanvasGroup;

    private void OnEnable()
    {
         SetActiveGameObject(_taskCanvasGroup.gameObject);
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            _cellCanvasGroup.interactable = false;
            _cellCanvasGroup.blocksRaycasts = true;
        });
    }
    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            _cellCanvasGroup.interactable = false;
            _cellCanvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {

        _fadeTween?.Kill(false);
        _fadeTween = _cellCanvasGroup.DOFade(endValue, duration);
        _fadeTween = _taskCanvasGroup.DOFade(endValue, duration);
        _fadeTween.onComplete += onEnd;
    }
   
    public void SetActiveGameObject(GameObject gameObject) => gameObject.SetActive(true);
              
}

