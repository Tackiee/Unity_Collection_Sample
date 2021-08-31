using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    /***********************************SaveScriptに関して***********************************
     * 本スクリプトはゲームオブジェクトの保存機能を実装している．                           *
     * PlayerPrefsではゲームオブジェクトを保存できない．                                    *
     * その解決手段として本スクリプトを配布する．                                           *
     *                                                                                      *
     *                                                                                      *
     * 1．Characters配列には3種類のキャラクターを格納している．                             *
     * 保存に際して今回はリスト（動的配列）を用いた．                                       *
     * リストは普通の配列と異なり，格納出来る要素数を自由に変えられる．                     *
     * 配列は[3]のように指定した場合，要素数をそれ以上増やせない．                          *
     * コレクションが徐々に増える事を考慮し，リストを使用した．                             *
     * またstaticで宣言しているので，シーンを移動してもデータが消えない．                   *
     *                                                                                      *
     * 2．int型の代わりにint?型を使用した．これは本サンプルが成り立つように，               *
     * 実装する際に使用しただけなので，自分の開発環境で使用する事は無いはず．               *
     * int?型はnull値を許容できる型である．（覚えておくとどっかで役に立つかも）             *
     *                                                                                      *
     * 3．ChooseRed, Green, Blueはボタンで保存するキャラクターを選択する関数である．        *
     * ただし，あくまで仮の関数なので，実装する際は適宜自分の環境に合わせて読み換える事．   *
     *                                                                                      *
     * 4．SaveButton()関数はゲームオブジェクトの保存をボタンを押した時に行う関数である．    *
     * CollectionList.Add(Characters[(int)i])がリストに追加するコードである．               *
     * ここで，Characters配列の要素番号指定が(int)iとなっているが，                         *
     * これは型変換（キャスト）というものである．                                           *
     * 本来は使用しない予定だったが，null値を許容する関係で                                 *
     * int?型からint型にキャストする必要があった．                                          *
     ****************************************************************************************/

    public GameObject[] Characters = new GameObject[3]; //3種類のキャラクター
    static public List<GameObject> CollectionList = new List<GameObject>(); //リスト（動的配列）をコレクション結果に利用する
    int? i = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseRed() //保存するゲームオブジェクトを選択する関数（Red）
    {
        i = 0;
        Debug.Log("赤を選択");
    }

    public void ChooseGreen() //保存するゲームオブジェクトを選択する関数（Green）
    {
        i = 1;
        Debug.Log("緑を選択");
    }

    public void ChooseBlue() //保存するゲームオブジェクトを選択する関数（Blue）
    {
        i = 2;
        Debug.Log("青を選択");
    }

    public void SaveButton() //ゲームオブジェクトを保存する関数
    {
        if (i != null)
        {
            CollectionList.Add(Characters[(int)i]);
            SceneManager.LoadScene("CollectionScene");
            i = null;
        }
        else
            Debug.Log("コレクションするオブジェクトを選択してください");
    }
}
