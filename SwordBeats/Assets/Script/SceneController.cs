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

        Debug.Log(collider);
        this.sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(this.sceneName);

        // êÌì¨à»äOÇÃÉVÅ[ÉìÇÃèÍçá
        if (this.sceneName != BATTLE_SCENE && collider.CompareTag("BattleModeDetector"))
        {
            SceneManager.LoadScene(BATTLE_SCENE);
        }


    }
    public void changeMainScene()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
