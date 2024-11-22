using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;

public class MapClickHandler : MonoBehaviour
{
    public AbstractMap map; // MapboxのAbstractMapコンポーネント

    void Update()
    {
        // マウスの左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 地面（マップ）をクリックしたかをチェック
            if (Physics.Raycast(ray, out hit))
            {
                // クリックした位置の3D座標を取得
                Vector3 worldPosition = hit.point;

                // 3D座標から緯度経度を取得
                Vector2d latitudeLongitude = map.WorldToGeoPosition(worldPosition);

                // 緯度経度を表示
                Debug.Log($"緯度: {latitudeLongitude.x}, 経度: {latitudeLongitude.y}");
            }
        }
    }
}