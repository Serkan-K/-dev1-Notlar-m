using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    private Scene scene_;

    private void Awake()
    {
        scene_ = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Next_();
        }
    }


    public void Next_()
    {
        SceneManager.LoadScene(scene_.buildIndex + 1);
    }

    public void Previous_()
    {
        SceneManager.LoadScene(scene_.buildIndex - 1);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
