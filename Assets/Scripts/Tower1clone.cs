using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower1clone : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform trn;
    bool on_ground = false;
    List<int> check_if_on_tower = new List<int>() {0};
    bool on_tower = false;
    public SpriteRenderer image;
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        trn = GetComponent<Transform>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            on_ground = true;
            UnityEngine.Debug.Log(11);
        }

        if (col.tag == "Tower1")
        {
            on_tower = true;
            UnityEngine.Debug.Log(1);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            on_ground = false;
            UnityEngine.Debug.Log(00);
        }

        if (col.tag == "Tower1")
        {
            on_tower = false;
            UnityEngine.Debug.Log(0);
        }
    }

// Update is called once per frame
void Update()
    {
        GameObject ShopIcon = GameObject.FindWithTag("ShopIcon1");
        GameObject Tower = GameObject.FindWithTag("Tower1");
        GameObject Points = GameObject.FindWithTag("PointsNumber");
        if (ShopIcon.GetComponent<ShopIcon>().CountClones > 0)
        {
            var tempColor = image.color;
            tempColor.a = (ShopIcon.GetComponent<ShopIcon>().CountClones > 0) ? 0.5f : 0f;
            image.color = tempColor;
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);//положение мыши из экранных в мировые координаты
            mousePosition.z = 0;
            if (Input.GetMouseButtonDown(0) && !on_ground && !on_tower)
            {
                ShopIcon.GetComponent<ShopIcon>().CountClones--;
                var clone = Instantiate(Tower, mousePosition, Quaternion.identity) as GameObject;
                ShopIcon.GetComponent<ShopIcon>().is_cloned = false;
                Points.GetComponent<PointsNumber>().points -= ShopIcon.GetComponent<ShopIcon>().price;
                trn.position = new Vector3(0, 0, 0);
            }
            else
            {
                trn.position = mousePosition;
            }
        }

    }
}
