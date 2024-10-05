using UnityEngine;
using System.Collections;

public class LocationService : MonoBehaviour
{
    public float latitude;
    public float longitude;
    public float altitude;

    // シングルトン
    private static LocationService _instance;
    public static LocationService Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (LocationService)FindObjectOfType(typeof(LocationService));
                if (null == _instance)
                {
                    Debug.Log("LocationService Instance Error");
                }
            }
            return _instance;
        }
    }

    void Start() 
    {
        StartCoroutine(StartLocationService());

    }

    private IEnumerator StartLocationService()
    {
        Debug.Log("aaa");
        // 最初に、ユーザーがロケーションサービスを有効にしているかを確認する。無効の場合は終了する
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("ロケーション無効やわ");
            yield break;
        }
        Debug.Log("bbb");
        // 位置を取得する前にロケーションサービスを開始する
        Input.location.Start();
        Debug.Log("ccc");
        // 初期化が終了するまで待つ
        int maxWait = 20; // タイムアウトは20秒
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1); // 1秒待つ
            maxWait--;
        }
        Debug.Log("ddd");
        // サービスの開始がタイムアウトしたら（20秒以内に起動しなかったら）、終了
        if (maxWait < 1)
        {
            Debug.Log("サービスの開始がタイムアウトしました。（20秒以内に起動しなかったよ。）");
            yield break;
        }
        Debug.Log("eee");
        // サービスの開始に失敗したら終了
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        /*
        else
        {
            // アクセスの許可と位置情報の取得に成功
            Debug.Log("Location: " + Input.location.lastData.latitude + " "
                               + Input.location.lastData.longitude + " "
                               + Input.location.lastData.altitude + " "
                               + Input.location.lastData.horizontalAccuracy + " "
                               + Input.location.lastData.timestamp);
        }
        */

        // ループバージョン
        int count = 0;
        Debug.Log("fff");
        while (count < 10)
        {
            latitude = Input.location.lastData.latitude; // 緯度
            longitude = Input.location.lastData.longitude;// 経度
            altitude = Input.location.lastData.altitude;// 高度
            Debug.Log("緯度：　" + latitude + "　経度：　" + longitude);
            yield return new WaitForSeconds(10);
            count++;
        }

        // 位置の更新を継続的に取得する必要がない場合はサービスを停止する
        Input.location.Stop();
    }
}
