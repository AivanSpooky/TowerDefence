using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool is_shop_opened = false;
    void Update()
    {
        GameObject Wave = GameObject.FindWithTag("NextWave");
        if (Wave.GetComponent<NextWave>().is_wave_started)
        {
            is_shop_opened = false;
        }
    }
    public void OpenShop()
    {
        GameObject Wave = GameObject.FindWithTag("NextWave");
        if (!Wave.GetComponent<NextWave>().is_wave_started)
        {
            if (!is_shop_opened)
            {
                is_shop_opened = true;
            }
            else
            {
                is_shop_opened = false;
            }
        } 
    }
}