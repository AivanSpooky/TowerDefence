﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 20;
    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "LIVES: " + lives.ToString();
    }
}
