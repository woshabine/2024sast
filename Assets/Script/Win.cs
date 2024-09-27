using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject win;
    private void OnTriggerEnter2D(Collider2D other)
    {
        win.SetActive(true);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
