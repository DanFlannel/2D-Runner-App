﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public AudioClip deathSound;
    private GameMaster gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Obsticle")
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gm.aSource.PlayOneShot(deathSound);
        Time.timeScale = 0;
        gm.GameOverPanel();
    }
}
