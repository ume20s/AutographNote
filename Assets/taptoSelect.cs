using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class taptoSelect : MonoBehaviour
{
       // タップしたら
    public void onClick()
    {
        // 最初のステージへ
        SceneManager.LoadScene("select");
    }
}
