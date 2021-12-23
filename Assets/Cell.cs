using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    private Particle _particle;
    private string _indentifier;
    private ContentView _contentView;

    public event Action OnNextLevelAction = delegate { };
    public string Indentifier
    {
        get => _indentifier;
        set => _indentifier = value;
    }

    private void Awake()
    {
        _particle = FindObjectOfType<Particle>();
        _contentView = FindObjectOfType<ContentView>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (_indentifier.Contains(_contentView.TaskValue.text))
        {
            _particle.PlayParticle();

            transform.DOShakePosition(3f, strength: new Vector3(0f, 20f, 0f),
                vibrato: 5, randomness: 90, snapping: false, fadeOut: true);

            OnNextLevelAction?.Invoke();
        }
        else
            transform.DOShakePosition(3f, strength: new Vector3(0f, 20f, 0f),
                vibrato: 5, randomness: 90, snapping: false, fadeOut: true);

    }


}
