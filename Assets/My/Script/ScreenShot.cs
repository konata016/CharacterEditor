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
    
    public int depth = 0;
    public bool Alpha = true;

    public static DirectoryInfo SafeCreateDirectory(string path)
    {
        return Directory.Exists(path) ? null : Directory.CreateDirectory(path);
    }

    // カメラのスクリーンショットを保存する
    public void CaptureScreenShot()
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


        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        var bytes = screenShot.EncodeToPNG();
        Destroy(screenShot);

#if !UNITY_EDITOR
        FileDownLoad(bytes, bytes.Length, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
#else

        File.WriteAllBytes(Folder + "/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png", bytes);
#endif
    }
}