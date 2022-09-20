using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    const string BATTLE_SCENE = "BattleScene";
    const string MAIN_SCENE = "MainScene";

    Vector3 targetPos;
    GameObject player;
    GameObject mainCamera;
    CinemachineBrain _cinemachineBrain;
    const float ROTATE_SPEED = 2.0f;
    bool isBattle = false;


    // プレイヤーとカメラの距離
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
        // 敵と衝突し、戦闘になった場合
        if (SceneManager.GetActiveScene().name == BATTLE_SCENE)
        {
            // カメラを戦闘モード用に固定させる
            

        }
        else
        {
            // プレイヤーの動きに合わせて追尾させる
            mainCamera.transform.position = player.transform.position + offset;
            rotateCamera();
        }
    }

    /*
     * マウスの動きに合わせて、カメラを回転させる
     */
    void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * ROTATE_SPEED, Input.GetAxis("Mouse Y") * ROTATE_SPEED, 0);
        mainCamera.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(player.transform.position, transform.right, angle.y);
    }

    /*
     * 戦闘始まる前に呼ばれる
     */
    public void BattleMode()
    {
        isBattle = true;
    }

    /*
     * 戦闘が終わった後に呼ばれる
     */
    void MainMode()
    {
        // 追尾機能をONにする
        _cinemachineBrain.enabled = true;
    }
}
