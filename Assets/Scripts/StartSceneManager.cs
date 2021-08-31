using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    static public SaveScript SaveScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainButton()
    {
        if (SaveScript.CollectionList.Count != 10) //コレクションが10個になっていなければMainSceneに移動して保存できる
            SceneManager.LoadScene("MainScene");
        else
            Debug.Log("セーブデータがいっぱいです。コレクションをリセットしてください。");
    }

    public void ResetButton()   //コレクションデータを一括で削除する関数
    {
        SaveScript.CollectionList.Clear();
    }
}
