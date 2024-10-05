using UnityEngine;
using System.Collections;

public class LocationService : MonoBehaviour
{
    public float latitude;
    public float longitude;
    public float altitude;

    // �V���O���g��
    private static LocationService _instance;
    public static LocationService Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = (LocationService)FindObjectOfType(typeof(LocationService));
                if (null == _instance)
                {
                    Debug.Log("LocationService Instance Error");
                }
            }
            return _instance;
        }
    }

    void Start() 
    {
        StartCoroutine(StartLocationService());

    }

    private IEnumerator StartLocationService()
    {
        Debug.Log("aaa");
        // �ŏ��ɁA���[�U�[�����P�[�V�����T�[�r�X��L���ɂ��Ă��邩���m�F����B�����̏ꍇ�͏I������
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("���P�[�V�����������");
            yield break;
        }
        Debug.Log("bbb");
        // �ʒu���擾����O�Ƀ��P�[�V�����T�[�r�X���J�n����
        Input.location.Start();
        Debug.Log("ccc");
        // ���������I������܂ő҂�
        int maxWait = 20; // �^�C���A�E�g��20�b
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1); // 1�b�҂�
            maxWait--;
        }
        Debug.Log("ddd");
        // �T�[�r�X�̊J�n���^�C���A�E�g������i20�b�ȓ��ɋN�����Ȃ�������j�A�I��
        if (maxWait < 1)
        {
            Debug.Log("�T�[�r�X�̊J�n���^�C���A�E�g���܂����B�i20�b�ȓ��ɋN�����Ȃ�������B�j");
            yield break;
        }
        Debug.Log("eee");
        // �T�[�r�X�̊J�n�Ɏ��s������I��
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        /*
        else
        {
            // �A�N�Z�X�̋��ƈʒu���̎擾�ɐ���
            Debug.Log("Location: " + Input.location.lastData.latitude + " "
                               + Input.location.lastData.longitude + " "
                               + Input.location.lastData.altitude + " "
                               + Input.location.lastData.horizontalAccuracy + " "
                               + Input.location.lastData.timestamp);
        }
        */

        // ���[�v�o�[�W����
        int count = 0;
        Debug.Log("fff");
        while (count < 10)
        {
            latitude = Input.location.lastData.latitude; // �ܓx
            longitude = Input.location.lastData.longitude;// �o�x
            altitude = Input.location.lastData.altitude;// ���x
            Debug.Log("�ܓx�F�@" + latitude + "�@�o�x�F�@" + longitude);
            yield return new WaitForSeconds(10);
            count++;
        }

        // �ʒu�̍X�V���p���I�Ɏ擾����K�v���Ȃ��ꍇ�̓T�[�r�X���~����
        Input.location.Stop();
    }
}
