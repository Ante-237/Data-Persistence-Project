using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text NameText;
    public Text highScoreText;
    public GameObject GameOverText;
 
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        addScoreAndName();
        
       
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }else if(Input.GetKeyDown(KeyCode.Q)){
                MenuManager.Instance.StoreData();
                SceneManager.LoadScene(0);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        int presentHigh = MenuManager.Instance.highScore;
        if(m_Points > presentHigh){
            highScoreText.text =  $"Score : {MenuManager.Instance.highScore}";
            NameText.text = "Name: "+ MenuManager.Instance.highPlayer;
        }
    }

    public void GameOver()
    { 
     checkHighScore();
      // AddPlayerToboard();
      
       // MenuManager.Instance.saveData();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    void addScoreAndName(){
        MenuManager.Instance.LoadData();
        if(MenuManager.Instance.highScore < 1){
            NameText.text = "Name:" + MenuManager.Instance.playerName;
        }else{
            NameText.text = "Name:" + MenuManager.Instance.highPlayer;
        }
        
        highScoreText.text =  $"Score : {MenuManager.Instance.highScore}";
    }

    void checkHighScore(){
        int highscore = MenuManager.Instance.highScore;
        if(m_Points > highscore){
            MenuManager.Instance.highScore = m_Points;
            MenuManager.Instance.highPlayer = MenuManager.Instance.playerName;
            //store the name of player with high score
        }
        MenuManager.Instance.StoreData();
    }
/*
    void AddPlayerToboard(){
        MenuManager.Instance.scores.Add(m_Points);
        MenuManager.Instance.Names.Add(MenuManager.Instance.playerName);
    }
    */
}
