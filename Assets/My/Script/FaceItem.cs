using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceItem : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Button button;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetPos(Vector3 pos)
    {
        var rect = gameObject.transform as RectTransform;
        rect.anchoredPosition = pos;
    }

    public void SetupButton(Action<Sprite> onClickButton)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClickButton?.Invoke(image.sprite));
    }
}
