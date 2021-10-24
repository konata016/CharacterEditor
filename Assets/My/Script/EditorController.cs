using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField]
    private ScreenShot screenShot;

    [SerializeField]
    private UiController uiController;

    [SerializeField] 
    private SpriteRenderer hairSprite;
    
    [SerializeField] 
    private SpriteRenderer eyeSprite;
    
    [SerializeField] 
    private SpriteRenderer mouthSprite;
    
    [SerializeField] 
    private Transform otherLayerRoot;
    
    [SerializeField] 
    private SpriteRenderer backgroundSprite;

    private void Start()
    {
        initialize();
    }

    private void initialize()
    {
        uiController.Initialize(
            onChangeHairSprite, 
            onChangeEyeSprite,
            onChangeMouthSprite,
            otherLayerRoot, 
            onChangeBackgroundSprite,
            onClickSaveButton);
    }

    private void onChangeHairSprite(Sprite sprite)
    {
        hairSprite.sprite = sprite;
    }
    
    private void onChangeEyeSprite(Sprite sprite)
    {
        eyeSprite.sprite = sprite;
    }

    private void onChangeMouthSprite(Sprite sprite)
    {
        mouthSprite.sprite = sprite;
    }
    
    private void onChangeBackgroundSprite(Sprite sprite)
    {
        backgroundSprite.sprite = sprite;
    }

    private void onClickSaveButton()
    {
        screenShot.CaptureScreenShot();
    }
}
