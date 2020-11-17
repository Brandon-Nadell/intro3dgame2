using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waypoint : MonoBehaviour
{

    int waypoints;
    float timer;
    public TextMeshProUGUI time;
    public TextMeshProUGUI waypoint;
    bool finished;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint").Length;
        waypoint.text = "Waypoints: " + waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished) {
            timer += Time.deltaTime*2;
            string seconds = "" + (int)(timer%60);
            seconds = (seconds.Length == 1 ? "0" : "") + seconds;
            string subseconds = "" + (int)((timer*100)%100);
            subseconds = (subseconds.Length == 1 ? "0" : "") + subseconds;
            time.text = "Time: " + (int)((timer/60)) + ":" + seconds + ":" + subseconds;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("waypoint")) {
            Destroy(other.gameObject);
            waypoints--;
            waypoint.text = "Waypoints: " + waypoints;
            if (waypoints == 0) {
                finished = true;
            }
        }
    }
}
