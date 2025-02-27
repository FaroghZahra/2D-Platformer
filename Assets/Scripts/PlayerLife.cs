using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;
    private Rigidbody2D _rb;
    [SerializeField] private AudioSource _deathSound;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hurdle"))
        {
            Die();
        }
    }

    private void Die()
    {
        _deathSound.Play();
        _rb.bodyType = RigidbodyType2D.Static;
        _anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}
