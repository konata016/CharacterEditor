using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private FaceItemsControllerBase hairUiController;

    [SerializeField]
    private FaceItemsControllerBase eyeUiController;

    [SerializeField]
    private FaceItemsControllerBase mouthUiController;

    [SerializeField]
    private FaceItemsControllerBase otherUiController;

    [SerializeField]
    private FaceItemsControllerBase backgroundUiController;

    [SerializeField]
    private Button resetButton;

    [SerializeField]
    private Button saveButton;


    public void Initialize(
        Action<Sprite> onClickHairUiButton,
        Action<Sprite> onClickEyeUiButton,
        Action<Sprite> onClickMouthUiButton,
        Action<Sprite> onClickOtherUiButton,
        Action<Sprite> onClickBackgroundUiButton)
    {
        setupHairUiController(onClickHairUiButton);
        setupEyeUiController(onClickEyeUiButton);
        setupMouthUiController(onClickMouthUiButton);
        setupOtherUiController(onClickOtherUiButton);
        setupBackgroundUiController(onClickBackgroundUiButton);
        // setupSaveButton();
        setupResetButton();
    }

    private void setupHairUiController(Action<Sprite> onClickButton)
    {
        hairUiController.Initialize("Body/", onClickButton);
    }

    private void setupEyeUiController(Action<Sprite> onClickButton)
    {
        eyeUiController.Initialize("Eye/", onClickButton);
    }

    private void setupMouthUiController(Action<Sprite> onClickButton)
    {
        mouthUiController.Initialize("Mouth/", onClickButton);
    }

    private void setupOtherUiController(Action<Sprite> onClickButton)
    {
        otherUiController.Initialize("", onClickButton);
    }

    private void setupBackgroundUiController(Action<Sprite> onClickButton)
    {
        backgroundUiController.Initialize("", onClickButton);
    }

    private void setupSaveButton()
    {
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(() =>
        {
            //todo: 保存処理の追加
        });
    }

    private void setupResetButton()
    {
        resetButton.onClick.RemoveAllListeners();
        resetButton.onClick.AddListener(() => resetUi());
    }

    private void resetUi()
    {
        hairUiController.ResetUi();
        eyeUiController.ResetUi();
        mouthUiController.ResetUi();
        otherUiController.ResetUi();
        backgroundUiController.ResetUi();
    }
}
