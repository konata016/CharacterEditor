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
    private Toggle toggle;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void ChangeToggle(bool isEnable = true)
    {
        toggle.isOn = isEnable;
        toggle.onValueChanged.Invoke(isEnable);
    }
    

    public void SetupToggle(Action<bool, Sprite> onClickButton, ToggleGroup toggleGroup = null)
    {
        toggle.group = toggleGroup;

        toggle.onValueChanged.RemoveAllListeners();
        toggle.onValueChanged.AddListener((isEnabled) => onClickButton?.Invoke(isEnabled, image.sprite));
    }
}
