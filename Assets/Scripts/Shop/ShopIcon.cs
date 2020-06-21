using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShopIcon : MonoBehaviour
{
    // Start is called before the first frame update
    private Image img;
    public bool is_cloned = false;
    public int price = 100;
    public static bool FirstInstance = true;
    public int CountClones = 0;
    public int SomeValue = 100;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Shop = GameObject.FindWithTag("Shop");
        var tempColor = img.color;
        tempColor.a = (!Shop.GetComponent<Shop>().is_shop_opened) ? 0f : 1f;
        img.color = tempColor;
    }
    public void TowerSelected()
    {
        GameObject Points = GameObject.FindWithTag("PointsNumber");
        if (!is_cloned && Points.GetComponent<PointsNumber>().points >= price)
        {
            GameObject Shop = GameObject.FindWithTag("Shop");
            GameObject Tower = GameObject.FindWithTag("Tower1");
            Shop.GetComponent<Shop>().is_shop_opened = false;
            CountClones++;
            is_cloned = true;
        }
        
    }
            
}
