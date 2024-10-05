using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // ユーザデータ
    public int HeldCoin { get; private set; } = 0;
    public string PlayerName { get; private set; } = "クラフト太郎";
    public string PlayerId { get; private set; }

    // プライベートコンストラクタ
    private UserData()
    {
        // ユーザデータの代入
    }

    // MonoBehaviourを用いない場合のシングルトン
    private static UserData _instance;

    // インスタンスを取得するためのプロパティ  
    public static UserData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserData();
            }
            return _instance;
        }
    }

    public void SetPlayerName(string newName)
    {
        PlayerName = newName;
    }

    public void AddCoin(int delta)
    {
        HeldCoin += delta;
    }
}
