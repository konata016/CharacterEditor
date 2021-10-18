using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField]
    private UiController uiController;

    private void Start()
    {
        initialize();
    }

    private void initialize()
    {
        uiController.Initialize(null, null, null, null, null);
    }
}
