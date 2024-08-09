using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchDirector : MonoBehaviour
{
    // �V���O���g��
    private static TouchDirector _instance;
    public static TouchDirector Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (TouchDirector)FindObjectOfType(typeof(TouchDirector));
                if (null == _instance)
                {
                    Debug.Log("TouchDirector Instance Error");
                }
            }
            return _instance;
        }
    }

    private Vector3 _scrollStartPos = new Vector3(); // �X�N���[���̋N�_�ƂȂ�^�b�`�|�W�V����
    private Vector3 _sceenPosition = new Vector3();
    private static float SCROLL_DISTANCE_CORRECTION = 0.8f; // �X�N���[�������̒���

    private List<string> _cantScrollTag = new List<string>();
    private bool _scrollable = true;
    private bool _scrolled = true;

    // Update is called once per frame
    void Update()
    {
        // ���g�̏�����
        _cantScrollTag.Clear();
        _scrollable = true;

        if (Input.GetMouseButton(0))
        {
            // �^�b�`����̃|�W�V�������擾
            var touchPosition = Input.mousePosition;
            _sceenPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            // ���C�L���X�g���A�^�b�`�����ꏊ�ɂ���I�u�W�F�N�g�������ɂ�
            var rayCastResults = RayCast(touchPosition);

            ChangeScrollable(IsScrollable(rayCastResults));

            TileDirector.Instance.EmphasizeCrickedTile(_sceenPosition);

            // �X�N���[���\�Ȃ�X�N���[���������s���B
            if (_scrollable) Scroll();
        }
        else
        {
            // �^�b�`�𗣂�����X�N���[���J�n�ʒu������������ 
            _scrollStartPos = new Vector3();
        }
    }

    // ���C�L���X�g�𓊂��āA���ʂ�Ԃ�
    public List<RaycastResult> RayCast(Vector3 position)
    {
        PointerEventData pointData = new PointerEventData(EventSystem.current);
        pointData.position = position;
        List<RaycastResult> rayResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointData, rayResults);

        return rayResults;
    }

    // ���C�L���X�g���ʂ̃^�O���m�F���A�X�N���[���\����Ԃ�
    private bool IsScrollable(List<RaycastResult> rayResults)
    {
        bool isScrollable;
        foreach (RaycastResult result in rayResults)
        {
            // ���g�̊m�F����
            var tag = result.gameObject.tag;

            if (tag == "CantScroll")
            {
                _cantScrollTag.Add(tag);
            }
        }

        if (_cantScrollTag.Count != 0)
        {
            isScrollable = false;
        }
        else
        {
            isScrollable = true;
        }

        return isScrollable;
    }

    // �X�N���[�������擾���ACamera�̈ʒu���ړ�������
    private void Scroll()
    {
        if (_scrollStartPos.x == 0.0f)
        {
            _scrolled = false;
            // �X�N���[���J�n�ʒu���擾
            _scrollStartPos = _sceenPosition;
        }
        else
        {
            Vector3 touchMovePos = _sceenPosition;
            if (_scrollStartPos != touchMovePos)
            {
                _scrolled = true;
                // ���O�̃^�b�`�ʒu�Ƃ̍����擾����
                Vector3 diffPos = SCROLL_DISTANCE_CORRECTION * (touchMovePos - _scrollStartPos);
                CameraController.Instance.CamPosMove(diffPos);
                _scrollStartPos = touchMovePos;
            }
        }
    }

    public void ChangeScrollable(bool change)
    {
        _scrollable = change;
    }

    public bool CheckScrolled()
    {
        return _scrolled;
    }
}
