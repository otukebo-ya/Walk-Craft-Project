using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    // シングルトン
    private static CameraController _instance;
    public static CameraController Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = (CameraController)FindObjectOfType(typeof(CameraController));
                if(null == _instance )
                {
                    Debug.Log("CameraController Instance Error");
                }
            }
            return _instance;
        }
    }
    // Update is called once per frame
    void Update () {
        
    }

    // カメラの位置を変更する
    public void CamPosMove(Vector3 difference)
    {
        Vector3 pos = this.transform.position;
        pos -= difference;

        this.transform.position = pos;
    }
}
