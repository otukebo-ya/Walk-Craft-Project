using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update () {
        
    }

    // �J�����̈ʒu��ύX����
    public void CamPosMove(Vector3 diffPos)
    {
        Vector3 pos = this.transform.position;
        pos -= diffPos;

        this.transform.position = pos;
    }
}
