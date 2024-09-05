using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class JsonLoader: MonoBehaviour
{
    public TextAsset TextAsset;

    private GeoJsonFeatureCollection GeoJson;
    private JsonData jsonData;
    private string WAKAYAMA_GEOJSON_PATH = "Assets/GeoJsonFiles/testdata.json";

    private IEnumerator LoadGeoJson(string path)
    {
        if (File.Exists(path))
        {
            /*
            string json = File.ReadAllText(path);
            jsonData = JsonMapper.ToObject(json);
            */
            string json = File.ReadAllText(path);
            GeoJson = JsonUtility.FromJson<GeoJsonFeatureCollection>(json);
            Debug.Log(GeoJson.Type);
            
        }
        else
        {
            Debug.LogError("GeoJSONファイルが見つかりません: " + path);
        }
        yield return null;
    }

    void Start()
    {
        string path = WAKAYAMA_GEOJSON_PATH;
        double latitude = 135.2;
        double longitude = 34.1;

        StartCoroutine(LoadGeoJson(path));

        // 現在地情報を取得する処理

        GetLandUse(latitude, longitude);
    }

    public int? GetLandUse(double latitude, double longitude)
    {
        int? landUse = null;
        bool flg = true;
        foreach (JsonData feature in jsonData["Features"]) {
            JsonData polygon = feature["Geometry"]["Coordinates"][0];

            if (flg)
            {
                Debug.Log("polygon: " + polygon[0][0]);
                flg = false;

            }
            double minLatitude = (double)polygon[0][0];
            double maxLatitude = (double)polygon[2][0];
            double minLongitude = (double)polygon[0][1];
            double maxLongitude = (double)polygon[2][1];
            // 範囲外なら無視
            if (minLatitude > latitude || latitude > maxLatitude) continue;
            if (minLongitude > longitude || longitude > maxLongitude) continue;

            landUse = (int)(double)feature["Properties"]["LandUseType"];
            return landUse;
        }

        Debug.Log("Can't Find ");
        return landUse;
    }
}

// 将来的にかき治して使うのでおいといて。公式のjson読むやつの方が速いらしい
// geojson側を書き換えて使えるようにする予定（公式のものは二次限以上の配列が使えないことに注意！！）

[System.Serializable]
public class GeoJsonFeatureCollection
{
    public string Type;
    public GeoJsonCrs Crs;
    public List<GeoJsonFeature> Features;
}

[System.Serializable]
public class GeoJsonCrs
{
    public string Type;
    public GeoJsonCrsProperties Properties;
}

[System.Serializable]
public class GeoJsonCrsProperties
{
    public string Name;
}

[System.Serializable]
public class GeoJsonFeature
{
    public string Type;
    public GeoJsonProperties Properties;
    public GeoJsonGeometry Geometry;
}

[System.Serializable]
public class GeoJsonProperties
{
    public string MeshCord;
    public string LandUseType;
    public string SatellitePhotoDate;
}

[System.Serializable]
public class GeoJsonGeometry
{
    public string Type;
    public List<List<double>> Coordinates;
}
