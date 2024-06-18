using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [System.Serializable]
    public class PlayerInfo
    {
        public string id; // UUID as string
        public string username;
        public int balance;
        public int incmoney;
        public string current_tool_id; // UUID as string
        public string current_location_id; // UUID as string
    }

    [System.Serializable]
    public class MenuLogin
    {
        public Text login, password;
    }
    [System.Serializable]
    public class MenuRegistration
    {
        public Text login, password;
    }

    public MenuLogin loginWindow;
    public MenuRegistration registrationWindow;

    [SerializeField] private WebManager webManager;

    public void Login()
    {
        
        webManager.Logining(loginWindow.login.text, loginWindow.password.text);
        
    }

    public void Register()
    {
        webManager.Registration(registrationWindow.login.text, registrationWindow.password.text);
    }
}

