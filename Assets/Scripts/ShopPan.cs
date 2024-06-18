using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPan : MonoBehaviour
{
    public int total_money;
    public int incmoney = 0;
    [SerializeField] Button firstUp1;

    public void Up1()
    {
        int money = PlayerPrefs.GetInt("money");
        money -= 15;
        total_money = money;
        incmoney += 2; 
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        PlayerPrefs.SetInt("incmoney", incmoney);
    }
    void Update()
    {
        total_money = PlayerPrefs.GetInt("total_money");
        //isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;  || Для теста
        if (total_money >= 15)
        {
            firstUp1.interactable = true;

        }
        else
        {
            firstUp1.interactable = false;
        }
    }
}
