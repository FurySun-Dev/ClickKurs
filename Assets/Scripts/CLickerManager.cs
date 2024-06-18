using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLickerManager : MonoBehaviour
{
    [SerializeField] public int money;
    public int total_money;
    public Text money_text;
    public int incmoney = 0;
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        incmoney = PlayerPrefs.GetInt("incmoney");
    }
    public void ButtonCLick()
    {
        money += 1 + incmoney;
        total_money = money;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }

    // Update is called once per frame
    void Update()
    {
        total_money = PlayerPrefs.GetInt("total_money");
        money = PlayerPrefs.GetInt("money");
        incmoney = PlayerPrefs.GetInt("incmoney");
        money_text.text = money.ToString();
    }

    public void BackUp()
    {
        PlayerPrefs.DeleteAll();
    }
}
