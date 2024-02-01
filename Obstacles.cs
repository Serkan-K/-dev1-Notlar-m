using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
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
            Score.Hearts--;
            SceneManager.LoadScene(scene_.buildIndex);
        }
    }
}
