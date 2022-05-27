using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIControl : MonoBehaviour
{
    

    public void changing(){
        MenuManager.Instance.playerName = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>().text;
        Debug.Log(MenuManager.Instance.playerName);
    }
    
    public void startLeaderBoard()
    {
        MenuManager.Instance.StoreData();
        SceneManager.LoadScene(3);
    }


    public void StartMain(){
        MenuManager.Instance.StoreData();
        SceneManager.LoadScene(1);
    }

    public void startSettings(){
        MenuManager.Instance.StoreData();
    
        SceneManager.LoadScene(2);
    }

    public void Quit(){
        MenuManager.Instance.StoreData();
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
    
}
