using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Text;

    private void Awake()
    {
        m_Text.text = Score.score_.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {            
            Score.score_++;
            m_Text.text = Score.score_.ToString();
        }
    }

}
