﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public int wave = 0;
    public Text text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "WAVE: " + wave.ToString();
    }
}