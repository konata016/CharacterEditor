using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スクロール管理
/// </summary>
public class FaceItemScrollController : MonoBehaviour
{
    private static readonly int horizontalsDisplayCount = 5;

    private static readonly int faceItemSiz = 100;

    /// <summary>スクロールビュー</summary>
    [SerializeField]
    private ScrollRect scrollRect;

    /// <summary>アイテム</summary>
    [SerializeField]
    private FaceItem faceItem;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize(string path, Action<Sprite> onClickButton)
    {
        setupScrollItem(path, onClickButton);
    }

    private void setupScrollItem(string path, Action<Sprite> onClickButton)
    {
        int count = 0;
        for (; ; )
        {
            var sprite = Resources.Load<Sprite>($"{path}{count}");
            if (sprite == null)
            {
                break;
            }

            instantiateItem(sprite, getItemPos(count), onClickButton);
            count++;
        }

        setupScrollRectContent(count);
    }

    private void instantiateItem(Sprite sprite, Vector3 pos, Action<Sprite> onClickButton)
    {
        var obj = Instantiate(faceItem, scrollRect.content);

        obj.SetPos(pos);
        obj.SetImage(sprite);
        obj.SetupButton(onClickButton);
    }

    int x = 0, y = 0;
    private Vector3 getItemPos(int count)
    {
        if (count == 0)
        {
            return new Vector3(x, y, 0);
        }

        x += faceItemSiz;
        if (count % horizontalsDisplayCount == 0)
        {
            x = 0;
            y -= faceItemSiz;
        }

        return new Vector3(x, y, 0);
    }

    private void setupScrollRectContent(int count)
    {
        var y = (getItemPos(count).y / 2);
        scrollRect.content.offsetMin = new Vector2(0, y);
    }

}
