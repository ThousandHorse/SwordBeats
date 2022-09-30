using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject[] PlayerLife;
    [SerializeField] GameObject[] EnemyLife;
    [SerializeField] TextMeshProUGUI BattleModeText;
    
    void Start()
    {
    }

    void Update()
    {

    }

    public void decreaseLife(int life)
    {
        if (gameObject.CompareTag("Player"))
        {
            PlayerLife[life].GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnemyLife[life].GetComponent<Image>().color = Color.black;
        }
        
        
    }

    public void IndicateClearText()
    {
        BattleModeText.text = "Clear!";
    }

    
}
