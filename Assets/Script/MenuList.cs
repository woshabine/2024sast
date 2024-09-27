using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    public GameObject menuList;

    [SerializeField] private bool menuListOpen = true;
    [SerializeField] private AudioSource bgmSource;
    void Update()
    {
        if (menuListOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuListOpen = false;
                Time.timeScale = 0;
                bgmSource.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(false);
            menuListOpen = true;
            Time.timeScale = 1;
            bgmSource.UnPause();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
