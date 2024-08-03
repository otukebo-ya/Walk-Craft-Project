using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    private Vector3 scrollStartPos  =   new Vector3(); // �X�N���[���̋N�_�ƂȂ�^�b�`�|�W�V����
    private static float SCROLL_DISTANCE_CORRECTION = 0.8f; // �X�N���[�������̒���

    private Vector3 touchPosition   =   new Vector3(); // �^�b�`�|�W�V����������
    private List<string> cantScrollTag = new List<string>();
    private bool scrollable = true;

    // Update is called once per frame
    void Update () {
        cantScrollTag.Clear();
        scrollable = true;
        if (Input.GetMouseButton(0)) {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            isOnUIElement();

            if (scrollable) {
                if(scrollStartPos.x == 0.0f){
�@�@�@�@�@�@�@�@       // �X�N���[���J�n�ʒu���擾
                    scrollStartPos   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }else{
                    Vector3 touchMovePos = touchPosition;
                    if(scrollStartPos != touchMovePos){
                        // ���O�̃^�b�`�ʒu�Ƃ̍����擾����
                        Vector3 diffPos   =   SCROLL_DISTANCE_CORRECTION * (touchMovePos - scrollStartPos);

                        Vector3 pos = this.transform.position;
                        pos -= diffPos;
                        
                        this.transform.position = pos;
                        scrollStartPos = touchMovePos;
                    }
                }
            }
        }else{
            // �^�b�`�𗣂�����t���O�𗎂Ƃ��A�X�N���[���J�n�ʒu������������ 
            scrollStartPos  =   new Vector2();
        }

    }

    private void isOnUIElement()
    {
        
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.position = Input.mousePosition;
        List<RaycastResult> RayResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointData, RayResult);
        foreach (RaycastResult result in RayResult)
        {
            // ���g�̊m�F����
            var tag = result.gameObject.tag;

            if (tag == "CantScroll")
            {
                cantScrollTag.Add(tag);
            }
        }

        if (cantScrollTag.Count != 0)
        {
            scrollable = false;
        }
    }

    public void changeScrollable(bool change)
    {
        scrollable = change;
    }
}
