using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taptoSaveAndNext : MonoBehaviour
{
    // タップしたら
    public void onClick()
    {
        // 保存パス名の生成
        // var storagePath = Application.dataPath + "/" + dt.textAGName + ".png";
        var storagePath = Application.persistentDataPath + "/../../../../Signature";
        if (!System.IO.Directory.Exists(storagePath)) {
            System.IO.Directory.CreateDirectory(storagePath);
        }

        // テクスチャをpngに変換して保存
        // var png = DrawingDirector.AGTexture.EncodeToPNG();
        // storagePath += "/" + dt.textAGName + ".png";
        // File.WriteAllBytes(storagePath, png);

        // デバッグ
        // Debug.Log(storagePath);

        // 名前をリセット
        dt.textAGName = "";

        // サインをもらう画面をリロード美人
        SceneManager.LoadScene("drawing");
    }
}
