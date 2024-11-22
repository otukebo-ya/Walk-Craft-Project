using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject pinPrefab; // ピンのPrefab
    public AbstractMap map; // MapboxのAbstractMapコンポーネント

    public void PlacePin(Vector2d latitudeLongitude)
    {
        // 緯度経度からマップ上の位置を取得
        Vector3 position = map.GeoToWorldPosition(latitudeLongitude);

        // ピンを生成
        Instantiate(pinPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
