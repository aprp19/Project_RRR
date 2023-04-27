using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject deathUI;
    public GameObject c1, c2, c3, c4;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);
        }

        if (col.gameObject.CompareTag("Chatbox1"))
        {
            GameObject.FindWithTag("Chatbox1").SetActive(false);
            c1.SetActive(true);
        }
        
        if (col.gameObject.CompareTag("Chatbox2"))
        {
            GameObject.FindWithTag("Chatbox2").SetActive(false);
            c1.SetActive(false);
            c2.SetActive(true);
        }
        
        if (col.gameObject.CompareTag("Chatbox3"))
        {
            GameObject.FindWithTag("Chatbox3").SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
        }

        if (col.gameObject.CompareTag("Chatbox4"))
        {
            GameObject.FindWithTag("Chatbox4").SetActive(false);
            c4.SetActive(true);
        }

        if (col.gameObject.CompareTag("CloseChat"))
        {
            GameObject.FindWithTag("CloseChat").SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
        }

        if (col.gameObject.CompareTag("NextScene"))
        {
            SceneManager.LoadScene("Gameplay - Stage 2");
        }
    }
}
