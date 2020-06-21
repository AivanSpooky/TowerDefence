using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject Wave = GameObject.FindWithTag("LevelWaveOptions");
        text.text = "ENEMIES: " + Wave.GetComponent<WaveStart>().enemies.ToString();
    }
}
