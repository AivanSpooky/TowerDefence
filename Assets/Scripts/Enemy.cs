using System.Security.Cryptography;
using UnityEngine;
using System;
using System.Linq;
using System.Diagnostics;

public class Enemy : MonoBehaviour {

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private GameObject[] waypoints;
    private GameObject[] waypointssorted;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    public bool is_clone = false;
    private bool is_cloned = false;
    private int points_cost = 10;
    private int life_cost = -1;
    private float waiting_time = 0f;
    private int clonesNumber = 0;
    // Index of current waypoint from which Enemy walks
    // to the next one

    private int waypointIndex = 0;
    void FindWayPoints()
    {
        
    }

    // Use this for initialization
    void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
        UnityEngine.Debug.Log(GameObject.FindGameObjectsWithTag("Waypoint"));
        transform.position = waypoints[waypointIndex].GetComponent<Transform>().transform.position;
        waypointIndex += 1;
    }
	
	// Update is called once per frame
	void Update () {
        // Move Enemy
        GameObject NWave = GameObject.FindWithTag("NextWave");
        GameObject Enemy = GameObject.FindWithTag("Enemy1");
        if (NWave.GetComponent<NextWave>().is_wave_started && gameObject.tag != "EnemyClone" && is_clone)
        {
            Move();
        }
        if (NWave.GetComponent<NextWave>().is_wave_started && gameObject.tag == "EnemyClone" && clonesNumber <= NWave.GetComponent<NextWave>().all_enemies[0])
        {
            UnityEngine.Debug.Log(waiting_time);
            waiting_time += Time.deltaTime;
            if (waiting_time > 2)
            {
                waiting_time = 0;
                UnityEngine.Debug.Log(NWave.GetComponent<NextWave>().enemies);
                var clone = Instantiate(Enemy, transform.position, Quaternion.identity) as GameObject;
                clone.GetComponent<Enemy>().is_clone = true;
                clonesNumber++;
            }
        }

    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
            UnityEngine.Debug.Log(waiting_time);
            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (System.Math.Pow(transform.position.x - waypoints[waypointIndex].transform.position.x, 2) + 
                System.Math.Pow(transform.position.y - waypoints[waypointIndex].transform.position.y, 2) <= 0.1f)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            GameObject NWave = GameObject.FindWithTag("NextWave");
            GameObject Lives = GameObject.FindWithTag("LivesNumber");
            NWave.GetComponent<NextWave>().enemies -= 1;
            Lives.GetComponent<LivesNumber>().lives += life_cost;
            UnityEngine.Debug.Log(gameObject);
            Destroy(gameObject);
        }
    }
}
