﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    // Start is called before the first frame update
    private void Update()
    {
        //if the r key is pressed
        //resart scene
        if (Input.GetKeyDown(KeyCode.R)&& _isGameOver == true)
        {
            SceneManager.LoadScene(1); //1 is "Game"
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
    
}
