using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string sceneName;
    const string BEAR_BATTLE_SCENE = "BearBattleScene";
    const string SLIME_BATTLE_SCENE = "SlimeBattleScene";
    const string TURTLESHELL_BATTLE_SCENE = "TurtleShellBattleScene";
    const string BOSS_BATTLE_SCENE = "BossBattleScene";

    const string MAIN_SCENE = "MainScene";

    string enemyName;

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

        if (collider.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Bear"))
                SceneManager.LoadScene(BEAR_BATTLE_SCENE);
            if (gameObject.CompareTag("Slime"))
                SceneManager.LoadScene(SLIME_BATTLE_SCENE);
            if (gameObject.CompareTag("TurtleShell"))
                SceneManager.LoadScene(TURTLESHELL_BATTLE_SCENE);
            if (gameObject.CompareTag("Boss"))
                SceneManager.LoadScene(BOSS_BATTLE_SCENE);

        }


    }
    public void changeMainScene()
    {
        SceneManager.LoadScene(MAIN_SCENE);

        // TODO: “|‚µ‚½“G‚ÌƒIƒuƒWƒFƒNƒg‚ð”jŠü‚·‚é
    }
}
