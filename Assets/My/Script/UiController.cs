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
    private OtherFaceItemsController otherUiController;

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
        Transform otherLayerRoot,
        Action<Sprite> onClickBackgroundUiButton,
        Action onClickSaveButton)
    {
        setupHairUiController(onClickHairUiButton);
        setupEyeUiController(onClickEyeUiButton);
        setupMouthUiController(onClickMouthUiButton);
        setupOtherUiController(otherLayerRoot);
        setupBackgroundUiController(onClickBackgroundUiButton);
        setupSaveButton(onClickSaveButton);
        setupResetButton();
        resetUi();
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

    private void setupOtherUiController(Transform otherLayerRoot)
    {
        otherUiController.Initialize("Others/", otherLayerRoot);
    }

    private void setupBackgroundUiController(Action<Sprite> onClickButton)
    {
        backgroundUiController.Initialize("Background/", onClickButton);
    }

    private void setupSaveButton(Action onClickSaveButton)
    {
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(() => onClickSaveButton());
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
