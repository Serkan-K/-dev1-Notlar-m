using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    private AudioSource SFx_source_;

    private void Awake()
    {
        SFx_source_ = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sfx();
            Destroy(gameObject, .1f);
        }
    }


    public void Sfx()
    {
        SFx_source_.Play();
    }
}
