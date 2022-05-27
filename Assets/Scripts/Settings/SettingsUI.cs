using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    
    void Start(){
        MenuManager.Instance.LoadData();
        GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>().value = MenuManager.Instance.playerSpeed;

    }


    public void fixChange(){
        MenuManager.Instance.playerSpeed = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>().value;
    }

  

    public void exit(){
        MenuManager.Instance.StoreData();
        SceneManager.LoadScene(0);
    }
}
