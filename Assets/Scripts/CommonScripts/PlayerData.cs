using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    // ユーザデータ
    public int HeldCoin { get; private set; } = 0;
    public string Name { get; private set; } = "クラフト太郎";
    private string _userID;

    // プライベートコンストラクタ
    private PlayerData()
    {
        // ユーザデータの代入
    }

    // MonoBehaviourを用いない場合のシングルトン
    private static PlayerData _instance;

    // インスタンスを取得するためのプロパティ  
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
            return _instance;
        }
    }

    public void AddCoin(int delta)
    {
        HeldCoin += delta;
    }

    public void setPlayerName(string newName)
    {
        Name = newName;
    }
}
