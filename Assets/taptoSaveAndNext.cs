using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class taptoSaveAndNext : MonoBehaviour
{
    // タップしたら
    public void onClick()
    {
        // テクスチャをpngに変換して保存
        var storagePath = Application.persistentDataPath + "/../../../../DCIM/Camera/" + dt.textAGName + ".png";
        var png = DrawingDirector.AGTexture.EncodeToPNG();
        File.WriteAllBytes(storagePath, png);

        // ファイル保存が終わるまで1フレーム待つ
        WaitOneFrame();
        
        // メディアスキャン
        ScanMedia(dt.textAGName + ".png");

        // デバッグ
        // Debug.Log(storagePath);

        // 名前をリセット
        dt.textAGName = "";

        // サインをもらう画面をリロード美人
        SceneManager.LoadScene("drawing");
    }

    // ワンフレーム待つ
    static private IEnumerable WaitOneFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    // 保存されたpngファイルをギャラリーに反映させる
    static void ScanMedia (string fileName)
    {
        if (Application.platform != RuntimePlatform.Android)
            return;
#if UNITY_ANDROID
        using (AndroidJavaClass jcUnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject joActivity = jcUnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity"))
        using (AndroidJavaObject joContext = joActivity.Call<AndroidJavaObject> ("getApplicationContext"))
        using (AndroidJavaClass jcMediaScannerConnection = new AndroidJavaClass ("android.media.MediaScannerConnection"))
        using (AndroidJavaClass jcEnvironment = new AndroidJavaClass ("android.os.Environment"))
        using (AndroidJavaObject joExDir = jcEnvironment.CallStatic<AndroidJavaObject> ("getExternalStorageDirectory")) {
            string path = joExDir.Call<string> ("toString") + "/DCIM/Camera/" + fileName;
            Debug.Log ("search path : " + path);
            jcMediaScannerConnection.CallStatic ("scanFile", joContext, new string[] { path }, new string[] { "image/png" }, null);
        }
#endif
    }
}
