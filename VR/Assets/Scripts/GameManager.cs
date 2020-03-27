﻿using UnityEngine;
using System.Collections;   // 引用 系統.集合 API：延遲 - 微軟 API

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
    [Header("會動的寶箱")]
    public Transform chest;
    [Header("會動的燭燈")]
    public Transform candle;

    // 定義方法 (Method)：有特定內容的功能
    // 修飾詞 傳回類型 方法名稱 () { 敘述 }
    // void 無傳回：使用此方法不會得到任何資料
    // IEnumerator 延遲傳回
    // 協同程序：多線程程式處理方式
    /// <summary>
    /// 燈光閃爍效果
    /// </summary>
    public IEnumerator LightEffect()
    {
        // 燈光群組.啟動設定(隱藏)
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        groupLight.SetActive(true);
    }
    
    /// <summary>
    /// 開始移動寶箱
    /// </summary>
    public void StartMoveChest()
    {
        StartCoroutine(MoveChest());
    }

    // 注視點或按鈕無法呼叫協程
    /// <summary>
    /// 移動寶箱
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveChest()
    {
        // 前：forward
        // 右：right
        // 上：up
        // for 迴圈(初始值，條件，跌代器 - 每次回圈結束要執行的敘述)
        for (int i = 0; i < 20; i++)
        {
            chest.position += chest.forward * 0.3f;            // 寶箱.座標 遞減 寶箱.前方
            yield return new WaitForSeconds(0.001f);
        }
        // GetComponent<泛型>() 取得元件：可以取得物件在屬性面板上的所有元件
        // enable 元件啟動或停止：true 啟動 false 停止
        chest.GetComponent<CapsuleCollider>().enabled = false;
    }

    /// <summary>
    /// 開始移動燭燈
    /// </summary>
    public void StartMoveCandle()
    {
        StartCoroutine(MoveCandle());
    }

    /// <summary>
    /// 移動燭燈
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveCandle()
    {
        for (int i = 0; i < 20; i++)
        {
            candle.position += candle.forward * 0.3f;
            yield return new WaitForSeconds(0.001f);
        }
    }

    // 事件：開始 - 播放時執行一次，初始化或遊戲開始需要的內容
    private void Start()
    {
        //LightEffect();                        // 呼叫自定義方法：一般呼叫方式
        StartCoroutine(LightEffect());          // 呼叫協程方式
    }
}
