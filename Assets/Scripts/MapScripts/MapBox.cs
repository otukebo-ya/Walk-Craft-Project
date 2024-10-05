//MIT License
//Copyright (c) 2023 DA LAB (https://www.youtube.com/@DA-LAB)
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Map : MonoBehaviour
{
    public string accessToken;
    public enum style { Light, Dark, Streets, Outdoors, Satellite, SatelliteStreets };
    public style mapStyle = style.Streets;
    public enum resolution { low = 1, high = 2 };
    public resolution mapResolution = resolution.low;

    private string[] styleStr = new string[] { "light-v10", "dark-v10", "streets-v11", "outdoors-v11", "satellite-v9", "satellite-streets-v11" };
    [SerializeField] private double latitude = 34.231;
    [SerializeField] private double longitude = 135.170;
    [SerializeField] private int zoom = 16;
    private string url = "";
    private Material mapMaterial;
    private int mapWidthPx = 1000;
    private int mapHeightPx = 1000;
    private double planeWidth;
    private double planeHeight;


    // Start is called before the first frame update
    void Start()
    {
        MatchPlaneToScreenSize();
        if (gameObject.GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<MeshRenderer>();
        }
        mapMaterial = new Material(Shader.Find("Unlit/Texture"));
        gameObject.GetComponent<MeshRenderer>().material = mapMaterial;
        StartCoroutine(GetMapbox());
    }

    // Update is called once per frame void Update(){ }

    public void GenerateMapOnClick()
    {
        StartCoroutine(GetMapbox());
    }

    IEnumerator GetMapbox()
    {
    //styles/otukebo-ya/cm1qebkbl00sg01rbeqf07qs6
    //styles/otukebo-ya/cm1r8vaar00ti01rb5vog1rwb

        //url = "https://api.mapbox.com/styles/v1/mapbox/" + styleStr[(int)mapStyle] + "/static/[" + boundingBox[0] + "," + boundingBox[1] + "," + boundingBox[2] + "," + boundingBox[3] + "]/" + mapWidthPx + "x" + mapHeightPx + "?" + "access_token=" + accessToken;
        url = "https://api.mapbox.com/styles/v1/cclemonade/" + "cm1sfbcuk00kc01r73oys1st0" + "/static/" +
                      longitude + "," + latitude + "," + zoom + "/" +
                     mapWidthPx + "x" + mapHeightPx + "?" +
                     "access_token=" + accessToken; 
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else 
        {
            // ↓これは３Dオブジェクトに用いるものらしい
            //gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", ((DownloadHandlerTexture)www.downloadHandler).texture);

            // ↓これは直接入れ込んでる
            Texture texture = DownloadHandlerTexture.GetContent(www);
            gameObject.GetComponent<RawImage>().texture = texture;
        }
    }


    //Set the scale of plane to match the screen size
    private void MatchPlaneToScreenSize()
    {
        // kokowokaeru
        double planeHeightScale = GetComponent<RectTransform>().rect.height;
        double planeWidthScale = GetComponent<RectTransform>().rect.width;

        //double planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        //double planeHeightScale = (2.0 * Math.Tan(0.5f * Camera.main.fieldOfView * (Math.PI / 180)) * planeToCameraDistance) / 10.0; //Radians = (Math.PI / 180) * degrees. Default plane is 10 units in x and z
        //double planeWidthScale = planeHeightScale * Camera.main.aspect;
        //gameObject.transform.localScale = new Vector3((float)planeWidthScale, 1, (float)planeHeightScale);

        //Set map width and height in pixel based on view aspec ratio
        if ((planeWidthScale < 1280) && (planeHeightScale < 1280))
        {
            Debug.Log("a");
            mapWidthPx = (int)Math.Ceiling(planeWidthScale);
            mapHeightPx += (int)Math.Ceiling(planeHeightScale);
        }
        else if (planeWidthScale > planeHeightScale)
        {
            Debug.Log("b");
            mapWidthPx = 1280; //Mapbox width should be a number between 1 and 1280 pixels.
            mapHeightPx = (int)Math.Round(planeHeightScale * (1280 / planeWidthScale));

        }
        if (planeHeightScale > planeWidthScale)
        {
            Debug.Log("c");
            mapHeightPx = 1280; //Mapbox height should be a number between 1 and 1280 pixels.
            mapWidthPx = (int)Math.Round(planeWidthScale * (1280 / planeHeightScale)); //Width is proportional to to view aspect ratio
        }
        
        Debug.Log("mapw: " + mapWidthPx + " maph: " + mapHeightPx);
        Debug.Log("planew: " + planeWidthScale + " planeh: " + planeHeightScale);
    }


}