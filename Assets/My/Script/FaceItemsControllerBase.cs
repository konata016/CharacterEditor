using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceItemsControllerBase : MonoBehaviour
{
    [SerializeField]
    private ToggleGroup toggleGroup;

    private FaceItem defaultFaceItem;

    private FaceItem selectFaceItem;
    
    protected virtual void onFinishedEachFaceItemSetup(FaceItem faceItem)
    {
        
    }

    public void Initialize(string resourcePath, Action<Sprite> onClickFaceItemButton)
    {
        var faceItems = gameObject.GetComponentsInChildren<FaceItem>();
        var count = 0;

        defaultFaceItem = faceItems[count];

        foreach (var faceItem in faceItems)
        {
            setupFaceItemImage(faceItem, resourcePath, count);
            setupFaceItemButton(faceItem, onClickFaceItemButton);
            onFinishedEachFaceItemSetup(faceItem);
            count++;
        }
    }

    public void ResetUi()
    {
        toggleGroup.SetAllTogglesOff();
        defaultFaceItem.ChangeToggle();
    }

    private void setupFaceItemButton(FaceItem faceItem, Action<Sprite> onClickFaceItemButton)
    {
        faceItem.SetupToggle((isEnabled, sprite) =>
        {
            // 無効状態で呼び出しをされた場合イベント実行しない
            if (!isEnabled)
            {
                return;
            }

            selectFaceItem = faceItem;
            onClickFaceItemButton?.Invoke(sprite);
        },
        toggleGroup);
    }

    private void setupFaceItemImage(FaceItem faceItem, string resourcePath, int resourceNum)
    {
        var sprite = Resources.Load<Sprite>($"{resourcePath}{resourceNum}");
        faceItem.SetupImage(sprite);
    }
}
