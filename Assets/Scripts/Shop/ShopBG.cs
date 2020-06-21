using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer image;
    public Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Shop = GameObject.FindWithTag("Shop");
        transform.position = new Vector3(-5.1f, -14.86f, 0);
        var tempColor = image.color;
        tempColor.a = (!Shop.GetComponent<Shop>().is_shop_opened) ? 0f : 1f;
        image.color = tempColor; 
    }
}
