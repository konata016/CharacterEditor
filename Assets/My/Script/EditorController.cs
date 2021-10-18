using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField]
    private UiController uiController;

    [SerializeField] 
    private Sprite hairSprite;
    
    [SerializeField] 
    private Sprite eyeSprite;
    
    [SerializeField] 
    private Sprite mouthSprite;
    
    [SerializeField] 
    private Sprite otherSprite;
    
    [SerializeField] 
    private Sprite backgroundSprite;

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
            onChangeOtherSprite, 
            onChangeBackgroundSprite,
            onClickSaveButton);
    }

    private void onChangeHairSprite(Sprite sprite)
    {
        hairSprite = sprite;
    }
    
    private void onChangeEyeSprite(Sprite sprite)
    {
        eyeSprite = sprite;
    }

    private void onChangeMouthSprite(Sprite sprite)
    {
        mouthSprite = sprite;
    }
    
    private void onChangeOtherSprite(Sprite sprite)
    {
        otherSprite = sprite;
    }
    
    private void onChangeBackgroundSprite(Sprite sprite)
    {
        backgroundSprite = sprite;
    }

    private void onClickSaveButton()
    {
        
    }
}
