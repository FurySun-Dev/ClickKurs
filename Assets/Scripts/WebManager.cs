using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using UnityEditor.PackageManager.Requests;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;


public class WebManager : MonoBehaviour
{

    public Menu.PlayerInfo PlayerInfo;

    public Text login, password;
    [SerializeField] private string targeturl;

    public void Registration(string login, string password)
    {
        StopAllCoroutines();
        StartCoroutine(Registring(login, password));
    }

    public void Logining(string login, string password)
    {
        StopAllCoroutines();
        StartCoroutine(loginer(login, password));
    }


    IEnumerator Registring(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", login);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(targeturl, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form загрузилась");
            }
        }
    }

    IEnumerator loginer(string login, string password)
    {
        string url = "http://127.0.0.1:8000/auth/login/?username=" + login + "&password=" + password;

        Debug.Log(url);
        Debug.Log(login);
        Debug.Log(password);

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Response Code: " + www.responseCode);
                Debug.Log("Response Text: " + www.downloadHandler.text);

                try
                {
                    Menu.PlayerInfo jsonResponse = JsonUtility.FromJson<Menu.PlayerInfo>(www.downloadHandler.text);

                    PlayerPrefs.SetInt("money", jsonResponse.balance);
                    PlayerPrefs.SetInt("incmoney", jsonResponse.incmoney);
                    PlayerPrefs.SetString("id", jsonResponse.id);

                    Debug.Log("Parsed Response: ");
                    Debug.Log("ID: " + jsonResponse.id);
                    Debug.Log("Username: " + jsonResponse.username);
                    Debug.Log("Balance: " + jsonResponse.balance);
                    Debug.Log("Current Tool ID: " + jsonResponse.current_tool_id);
                    Debug.Log("Current Location ID: " + jsonResponse.current_location_id);

                    PlayerInfo.id = jsonResponse.id;
                    PlayerInfo.current_tool_id = jsonResponse.current_tool_id;
                    SceneManager.LoadScene(1);
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to parse response: " + e.Message);
                }
            }
        }
    }
 }




