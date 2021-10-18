using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    /// <summary>
    /// リソース生成（GameObject）
    /// </summary>
    public static GameObject InstantiateResource(
        string resourceName,
        Transform parent = null)
    {
        var obj = Resources.Load(resourceName) as GameObject;
        return Instantiate(obj, parent);
    }
}
