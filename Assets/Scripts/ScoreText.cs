using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
