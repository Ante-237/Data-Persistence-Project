using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{
    

    public void changing(){
        MenuManager.Instance.playerName = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>().text;
        Debug.Log(MenuManager.Instance.playerName);
    }
    


    public void StartMain(){
        MenuManager.Instance.StoreData();
        SceneManager.LoadScene(1);
    }
}
