using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 定義欄位 (Field 宣告變數)
    // 修飾詞 類型 名稱;
    // public 公開：顯示在屬性面板上
    // GameObject 遊戲物件：儲存階層面板內的物件
    /// <summary>
    /// 燈光群組
    /// </summary>
    [Header("燈光群組")]
    public GameObject groupLight;

    // 定義方法 (Method)：有特定內容的功能
    // 修飾詞 傳回類型 方法名稱 () { 敘述 }
    // void 無傳回：使用此方法不會得到任何資料
    /// <summary>
    /// 燈光閃爍效果
    /// </summary>
    public void LightEffect()
    {
        // 燈光群組.啟動設定(隱藏)
        groupLight.SetActive(false);
    }

    // 事件：開始 - 播放時執行一次，初始化或遊戲開始需要的內容
    private void Start()
    {
        // 呼叫自定義方法
        LightEffect();
    }
}
