using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;

public class Tower : MonoBehaviour
{
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(go => go.name).ToArray();
        GameObject NWave = GameObject.FindWithTag("NextWave");
        if (NWave.GetComponent<NextWave>().is_wave_started)
        {
           // UnityEngine.Debug.Log("готов");
            GetReady();
        }
    }

    private void GetReady()
    {
        foreach (GameObject enemy in enemies)
        {
            
            //UnityEngine.Debug.Log(enemies);
            if (System.Math.Pow(enemy.GetComponent<Transform>().position.x - transform.position.x, 2) +
                System.Math.Pow(enemy.GetComponent<Transform>().position.y - transform.position.y, 2) <= 25f)
            {
                //Vector3 newDir = Vector3.RotateTowards(transform.forward, (enemy.transform.position - transform.position), 0.01f, 0.0F);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDir), 1f);
                //UnityEngine.Debug.Log(enemy.transform.position);
                Vector2 direction = enemy.GetComponent<Transform>().position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 999f * Time.deltaTime);
                continue;
            }
        }
    }
}
