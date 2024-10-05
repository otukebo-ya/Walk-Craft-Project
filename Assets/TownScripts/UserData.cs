using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    // ���[�U�f�[�^
    private int _coin;
    private string _userName;
    private string _userID;

    // �v���C�x�[�g�R���X�g���N�^
    private UserData()
    {
        // ���[�U�f�[�^�̑��
    }

    // MonoBehaviour��p���Ȃ��ꍇ�̃V���O���g��
    private static UserData _instance;

    // �C���X�^���X���擾���邽�߂̃v���p�e�B  
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
