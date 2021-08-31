using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollentionShowScript : MonoBehaviour
{
    /*********************************CollectionShowScriptに関して*********************************
     * 本スクリプトは保存したデータを一覧で表示する為の機能を実装している．                       *
     * ややこしくなったので軽く解説を載せておく．                                                 *
     *                                                                                            *
     * 1．保存したデータを実際に表示させる為にゲームオブジェクト配列を宣言した．                  *
     * 本来はリストで実装したかったが，エラーが出たので断念(原因は不明…分かったら教えて)         *
     *                                                                                            *
     * 2．x, yは単純に一番最初に出現するコレクションオブジェクトの位置を指定する為の変数．        *
     *                                                                                            *
     * 3．表示する機能部分はstart関数に記述した．                                                 *
     * オブジェクトを表示する為にfor文を用いた．                                                  *
     * Instantiateでゲームオブジェクトを生成し，TableList配列に格納．                             *
     * transform.positionで位置を指定．                                                           *
     * 今回は10個格納する事を想定しているので，5個目まで表示したら，                              *
     * 6個目からは2段目に表示する方が自然だと思ったので，x座標とy座標の値を指定した．             *
     * もしリストのカウントがTable配列の数と同じになったら，コレクションがいっぱいである事を伝達．*
     **********************************************************************************************/

    static public SaveScript SaveScript; //外部のスクリプトからの変数を取得する際は“public 「スクリプト名」 変数名”で宣言する
    public Button BackMenuButton;
    public Button ResetButton;
    GameObject[] TableList = new GameObject[10]; //リストから取ってきたゲームオブジェクトを配列に格納
                                                 //本当はリストを扱いたいけど，なぜかエラーが出たので配列で代用（今回は10個コレクションする事を想定）
    int x = -4; //一番最初のコレクションオブジェクトのx座標
    int y = 4;  //一番最初のコレクションオブジェクトのy座標

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SaveScript.CollectionList.Count; i++)
        {
            TableList[i] = Instantiate(SaveScript.CollectionList[i]);
            TableList[i].transform.position = new Vector3(x, y, 0);
            x += 2;
            if(i == 4)
            {
                x = -4;
                y -= 2;
            }
            if (SaveScript.CollectionList.Count == TableList.Length)
            {
                BackMenuButton.gameObject.SetActive(false);
                Debug.Log("コレクションはいっぱいです");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMainButton()
    {

        SceneManager.LoadScene("MainScene");
    }

    public void LoadStartButton()
    {

        SceneManager.LoadScene("StartScene");
    }
}
