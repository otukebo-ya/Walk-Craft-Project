using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // ユーザデータ
    private int _coin;
    private string _userName;
    private string _userID;

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

    // 
}
