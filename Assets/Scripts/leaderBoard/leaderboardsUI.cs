using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leaderboardsUI : MonoBehaviour
{

    private Text nameText;
    
    void Start(){
        findText();
        DisplayAll();
    }

    void DisplayAll(){
      //  List<string> tempName = MenuManager.Instance.Names;
       // List<int> tempScore = MenuManager.Instance.scores;
        //int listCount = tempName.Count;
        //incomplete 

        nameText.text = ""+MenuManager.Instance.highPlayer+ "\t\t\t" + MenuManager.Instance.highScore;
        

    }

    public void closeB(){
        SceneManager.LoadScene(0);
    }

    private void findText(){
        nameText = GameObject.FindGameObjectWithTag("boardtext").GetComponent<Text>();
    }
}
