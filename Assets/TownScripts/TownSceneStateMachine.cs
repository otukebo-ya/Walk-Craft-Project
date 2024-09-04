using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneStateMachine
{
    public ITownSceneState CurrentState { get; private set; }
    public ViewState ViewState { get; private set; }
    public ItemWindowState ItemWindowState { get; private set; }
    public ItemPlaceState ItemPlaceState { get; private set; }

    // �v���C�x�[�g�R���X�g���N�^  
    private TownSceneStateMachine() 
    {  
        this.ViewState = new ViewState();
        this.ItemWindowState = new ItemWindowState();
        this.ItemPlaceState = new ItemPlaceState();
    }

    // MonoBehaviour��p���Ȃ��ꍇ�̃V���O���g��
    private static TownSceneStateMachine _instance;
    // �C���X�^���X���擾���邽�߂̃v���p�e�B  
    public static TownSceneStateMachine Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TownSceneStateMachine();
            }
            return _instance;
        }
    }

    // �X�e�[�g�}�V�[���̏������BView�ŏ��������邱�ƂɂȂ�͂�
    public void Initialize(ITownSceneState state)
    {
        CurrentState = state;
        state.Enter();
    }

    // ���݂̃X�e�[�g�𔲂��Ď��̃X�e�[�g�ֈڂ鏈��
    public void TransitionTo(ITownSceneState nextState)
    {
        Debug.Log(CurrentState.StateName + " => " + nextState.StateName);
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    // ���݂̃X�e�[�g�Ȃ��Update����
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
    
    public string CheckCurrentState()
    {
        return CurrentState.StateName;
    }
}
