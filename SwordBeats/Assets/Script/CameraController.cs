using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    Vector3 targetPos;
    GameObject player;
    GameObject mainCamera;
    CinemachineBrain _cinemachineBrain;
    const float ROTATE_SPEED = 2.0f;
    bool isBattle = false;

    // �v���C���[�ƃJ�����̋���
    Vector3 offset;


    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindWithTag("Player");
        _cinemachineBrain = GetComponent<CinemachineBrain>();

        offset = mainCamera.transform.position - player.transform.position;


    }

    void Update()
    {
        // BattleMode�̏ꍇ(�G�ƏՓ˂����ꍇ)
        if (isBattle)
        {
            // �J�������Œ肳����
            

        }
        else
        {
            // MainMode�̏ꍇ
            // �v���C���[�̓����ɍ��킹�Ēǔ�������
            mainCamera.transform.position = player.transform.position + offset;
            rotateCamera();
        }
    }

    /*
     * �}�E�X�̓����ɍ��킹�āA�J��������]������
     */
    void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * ROTATE_SPEED, Input.GetAxis("Mouse Y") * ROTATE_SPEED, 0);
        mainCamera.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(player.transform.position, transform.right, angle.y);
    }

    /*
     * �퓬�n�܂�O�ɌĂ΂��
     */
    public void BattleMode()
    {
        isBattle = true;
    }

    /*
     * �퓬���I�������ɌĂ΂��
     */
    void MainMode()
    {
        // �ǔ��@�\��ON�ɂ���
        _cinemachineBrain.enabled = true;
    }
}
