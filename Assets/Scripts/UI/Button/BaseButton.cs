using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public abstract class BaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected Button button;
    protected float _tmpAlpha;

    private void OnValidate()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }
    }

    protected virtual void Start()
    {
        this.AddOnClickEvent();
        _tmpAlpha = button.GetComponent<Image>().color.a;

    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();

    public void OnPointerEnter(PointerEventData eventData)
    {
        Image image = button.GetComponent<Image>();
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image image = button.GetComponent<Image>();
        Color color = image.color;
        color.a = _tmpAlpha;
        image.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance?.OnPlaySound(SoundType.buttonClick);
    }
}
