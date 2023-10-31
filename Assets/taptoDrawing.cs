using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taptoDrawing : MonoBehaviour
{
    // タップしたら
    public void onClick()
    {
        // サインをもらう画面へ
        SceneManager.LoadScene("drawing");
    }
}
