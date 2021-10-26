using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFaceItemsController : MonoBehaviour
{
    private static readonly float layerRange = 0.1f;

    [SerializeField]
    private SpriteRenderer otherFaceItemsLayerPrefab;

    private FaceItem[] faceItems;

    public void Initialize(string resourcePath, Transform otherLayerRoot)
    {
        faceItems = gameObject.GetComponentsInChildren<FaceItem>();

        var count = 0;
        foreach (var faceItem in faceItems)
        {
            var otherLayerSpriteRenderer = CreateOtherLayerSpriteRenderer(otherLayerRoot, count);

            setupFaceItemImage(faceItem, otherLayerSpriteRenderer, resourcePath, count);
            setupFaceItemButton(faceItem, otherLayerSpriteRenderer);
            count++;
        }
    }

    public void ResetUi()
    {
        for (int i = 0; i < faceItems.Length; i++)
        {
            faceItems[i].ChangeToggle(false);
        }
    }

    private void setupFaceItemButton(FaceItem faceItem, SpriteRenderer spriteRenderer)
    {
        faceItem.SetupToggle((isEnabled, sprite) =>
        {
            spriteRenderer.enabled = isEnabled;
        });
    }

    private void setupFaceItemImage(
        FaceItem faceItem,
        SpriteRenderer spriteRenderer,
        string resourcePath,
        int resourceNum)
    {
        var sprite = Resources.Load<Sprite>($"{resourcePath}{resourceNum}");
        faceItem.SetupImage(sprite);
        spriteRenderer.sprite = sprite;
    }

    private SpriteRenderer CreateOtherLayerSpriteRenderer(Transform otherLayerRoot, int count)
    {
        var spriteRenderer = Instantiate(otherFaceItemsLayerPrefab, otherLayerRoot);
        var pos = spriteRenderer.transform.localPosition = Vector3.forward * (layerRange * count);
        return spriteRenderer;
    }
}
