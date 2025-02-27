using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private int _apples = 0;
    [SerializeField] private Text _applesText;
    [SerializeField] private AudioSource _collectSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            _collectSound.Play();
            Destroy(other.gameObject);
            _apples++;
            _applesText.text = "Apples:" + _apples;
        }
    }
}
