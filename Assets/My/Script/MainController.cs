using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    // [SerializeField]
    // private Image bodyImage;
    //
    // [SerializeField]
    // private Image mouseImage;
    //
    // [SerializeField]
    // private Image eyeImage;
    
    [SerializeField]
    private SpriteRenderer bodyImage;

    [SerializeField]
    private SpriteRenderer mouseImage;

    [SerializeField]
    private SpriteRenderer eyeImage;

    [SerializeField]
    private FaceItemScrollController bodyScrollController;

    [SerializeField]
    private FaceItemScrollController mouseScrollController;

    [SerializeField]
    private FaceItemScrollController eyeScrollController;

    [SerializeField]
    private Button bodyButton;

    [SerializeField]
    private Button mouseButton;

    [SerializeField]
    private Button eyeButton;

    private GameObject afterObj;

    private void Start()
    {
        setupBodyButton();
        setupMouseButton();
        setupEyeButton();

        setupBodyScrollController();
        setupMouseScrollController();
        setupEyeScrollController();

        afterObj = bodyScrollController.gameObject;
    }

    private void setupBodyScrollController()
    {
        // bodyScrollController.Initialize("Body/", (sprite) => bodyImage.sprite = sprite);
        bodyScrollController.Initialize("Body/", (sprite) => bodyImage.sprite = sprite);
    }

    private void setupMouseScrollController()
    {
        mouseScrollController.Initialize("Mouse/", (sprite) => mouseImage.sprite = sprite);
    }

    private void setupEyeScrollController()
    {
        eyeScrollController.Initialize("Eye/", (sprite) => eyeImage.sprite = sprite);
    }

    private void setupBodyButton()
    {
        bodyButton.onClick.RemoveAllListeners();
        bodyButton.onClick.AddListener(() => switchScrollView(bodyScrollController.gameObject));
    }

    private void setupMouseButton()
    {
        mouseButton.onClick.RemoveAllListeners();
        mouseButton.onClick.AddListener(() => switchScrollView(mouseScrollController.gameObject));
    }

    private void setupEyeButton()
    {
        eyeButton.onClick.RemoveAllListeners();
        eyeButton.onClick.AddListener(() => switchScrollView(eyeScrollController.gameObject));
    }

    private void switchScrollView(GameObject obj)
    {
        afterObj.SetActive(false);
        afterObj = obj;
        afterObj.SetActive(true);
    }
}
