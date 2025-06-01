using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, ICard, IPointerClickHandler
{
    public int PairID => _pairID;
    public event Action<ICard> OnCardSelected;
    
    [SerializeField] private Image _frontImage;
    [SerializeField] private Image _backImage;
    [SerializeField] private float flipDuration = 0.5f;

    private bool isFlipped = false;
    private int _pairID;


    public void SetData(int pairID, Sprite frontSprite)
    {
        _pairID = pairID;
        _frontImage.sprite = frontSprite;
    }

    public void ShowFront()
    {
        if (isFlipped == false) return;

        isFlipped = false;

        transform.DOScaleX(0, flipDuration / 2)
            .OnComplete(() =>
            {
                _frontImage.enabled = true;
                _backImage.enabled = false;

                transform.DOScaleX(1, flipDuration / 2);
            });
    }

    public void ShowBack()
    {
        if (isFlipped) return;

        isFlipped = true;

        transform.DOScaleX(0, flipDuration / 2)
            .OnComplete(() =>
            {
                _frontImage.enabled = false;
                _backImage.enabled = true;

                transform.DOScaleX(1, flipDuration / 2);
            });
    }

    public void Lock() => OnCardSelected = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        ShowFront();
        OnCardSelected?.Invoke(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}