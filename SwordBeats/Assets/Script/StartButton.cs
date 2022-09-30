using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    void Start()
    {
        var startButton = GetComponent<Button>();
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }
}
