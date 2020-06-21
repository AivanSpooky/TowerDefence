using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveStart : MonoBehaviour
{
    public int enemies = 0;
    //white_en = 0; blue_en = 1; red_en = 2
    public List<int> all_enemies = new List<int>() {0, 0, 0, 0};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Wave = GameObject.FindWithTag("WaveNumber");
        GameObject NWave = GameObject.FindWithTag("NextWave");
        if (Wave.GetComponent<WaveNumber>().wave == 1 && enemies == 0)
        {
            all_enemies[0] += 2;
            all_enemies[1] += 1;
            UnityEngine.Debug.Log(all_enemies[0]);
            enemies = all_enemies.Sum();
            UnityEngine.Debug.Log(enemies);
        }

        if (NWave.GetComponent<NextWave>().is_wave_started == true && enemies == 0)
        {
            NWave.GetComponent<NextWave>().is_wave_started = false;
        }
    }
}
