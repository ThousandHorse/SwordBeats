using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string sceneName;
    const string BATTLE_SCENE = "BattleScene";
    const string MAIN_SCENE = "MainScene";


    void Start()
    {

    }
    void Update()
    {

    }

    public void changeBattleScene(Collider collider)
    {

        Debug.Log("changeBattleScene");
        this.sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(this.sceneName);

        // �퓬�ȊO�̃V�[���̏ꍇ
        if (this.sceneName != BATTLE_SCENE && collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(BATTLE_SCENE);
        }


    }
    public void changeMainScene()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
