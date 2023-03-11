using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public LevelManager levelManager;
    public Player player;
    public void LevelUp(int level)
    {
        Debug.Log(level);
        levelManager.SetUpgrades(level);
    }

    public void Death()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
