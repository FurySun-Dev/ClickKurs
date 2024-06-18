using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System.Runtime.Serialization;

public class AchvMenu : MonoBehaviour
{
    [Header("Для теста")]
    public int total_money;
    [SerializeField] bool isFirst = false;
    [SerializeField] Button firstAch;
    // false для теста
    [Header("Остальное")]
    [SerializeField] Button twoAch, threeAch, fourAch;
    void Update()
    {
        total_money = PlayerPrefs.GetInt("total_money");
        isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if (total_money >= 10 && !isFirst)
        {
            firstAch.interactable= true;
            
        }
        else
        {
            firstAch.interactable= false;
        }
        twoAch.interactable = false;
        threeAch.interactable = false;
        fourAch.interactable = false;
    }
    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 10;
        total_money = money;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        isFirst = true;
        PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);
    }

}
