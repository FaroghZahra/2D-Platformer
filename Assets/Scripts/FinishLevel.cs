using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource _finishSound;

    private void Awake()
    {
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            _finishSound.Play();
            LevelFinished();
        }
    }

    private void LevelFinished()
    {
        SceneManager.LoadScene("Level 2");
    }
}
