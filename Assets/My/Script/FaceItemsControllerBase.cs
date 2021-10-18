using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceItemsControllerBase : MonoBehaviour
{
    private FaceItem defaultFaceItem;

    private FaceItem selectFaceItem;

    public void Initialize(string resourcePath, Action<Sprite> onClickFaceItemButton)
    {
        var faceItems = gameObject.GetComponentsInChildren<FaceItem>();
        var count = 0;

        defaultFaceItem = faceItems[count];

        foreach (var faceItem in faceItems)
        {
            setupFaceItemImage(faceItem, resourcePath, count);
            setupFaceItemButton(faceItem, onClickFaceItemButton);
            count++;
        }
    }

    public void ResetUi()
    {
        defaultFaceItem.SelfClickButton();
    }

    private void setupFaceItemButton(FaceItem faceItem, Action<Sprite> onClickFaceItemButton)
    {
        faceItem.SetupButton((sprite) =>
        {
            selectFaceItem = faceItem;
            onClickFaceItemButton?.Invoke(sprite);
        });
    }

    private void setupFaceItemImage(FaceItem faceItem, string resourcePath, int resourceNum)
    {
        var sprite = Resources.Load<Sprite>($"{resourcePath}{resourceNum}");
        faceItem.SetImage(sprite);
    }
}
