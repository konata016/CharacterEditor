using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScreenShot : MonoBehaviour
{
    
    [DllImport("__Internal")]
    private static extern void FileDownLoad(byte[] bytes, int size, string filename);
    
    public string Folder = "Assets/Resources";

    [SerializeField] private Camera camera;

    [SerializeField] private Button saveButton;
    
    public int depth = 0;


    void Awake()
    {
        saveButton.onClick.AddListener(() =>
        {
            CaptureScreenShot();
        });
    }
    
    
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.X))
    //     {
    //         CaptureScreenShot();
    //     }
    // }

//     IEnumerator CaptureWithAlpha()
//     {
//         Debug.Log($"x, y : {camera.pixelWidth} {camera.pixelHeight}");
//         yield return new WaitForEndOfFrame();
//
//         var rtex = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Default);
//         // var rtex = new RenderTexture(camera.rect.width, camera.rect.height, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Default);
//         // var rtex = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 0);
//         //var tex = ScreenCapture.CaptureScreenshotAsTexture();
//         // var prev = camera.targetTexture; 
//         // camera.targetTexture = rtex;
//         // camera.Render();
//         // camera.targetTexture = prev;
//         // RenderTexture.active = rtex;
//         
//         ScreenCapture.CaptureScreenshotIntoRenderTexture(rtex);
//
//         var width = rtex.width;
//         var height = rtex.height;
//
//         var texNoAlpha = new Texture2D(width, height, TextureFormat.RGB24, false);
//         var texAlpha = new Texture2D(width, height, TextureFormat.ARGB32, false);
//
//         if (Alpha)
//         {
//             // Read screen contents into the texture
//             texAlpha.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//             texAlpha.Apply();
//         }
//         else
//         {
//             // Read screen contents into the texture
//             texNoAlpha.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//             texNoAlpha.Apply();
//         }
//
// #if UNITY_EDITOR
//         SafeCreateDirectory(Folder);
// #endif
//         // Encode texture into PNG
//         var bytes = texAlpha.EncodeToPNG();
//         if (!Alpha)
//         {
//             bytes = texNoAlpha.EncodeToPNG();
//         }
//         DestroyImmediate(rtex);
//         File.WriteAllBytes(Folder + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png", bytes);
//         AssetDatabase.Refresh();
//     }

    public static DirectoryInfo SafeCreateDirectory(string path)
    {
        return Directory.Exists(path) ? null : Directory.CreateDirectory(path);
    }
    
    // カメラのスクリーンショットを保存する
    private void CaptureScreenShot()
    {
        var rt = new RenderTexture(camera.pixelWidth, camera.pixelHeight, depth);
        var prev = camera.targetTexture;
        camera.targetTexture = rt;
        camera.Render();
        camera.targetTexture = prev;
        RenderTexture.active = rt;
        
        var screenShot = new Texture2D(
            camera.pixelWidth,
            camera.pixelHeight,
            TextureFormat.ARGB32,
            false);
        

        screenShot.ReadPixels(new Rect(0,0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        var bytes = screenShot.EncodeToPNG();
        Destroy(screenShot);

//         File.WriteAllBytes(Folder + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png", bytes);
        FileDownLoad(bytes, bytes.Length, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
    }
}