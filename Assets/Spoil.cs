using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoil : MonoBehaviour
{

    int spoilAmount;

    // Start is called before the first frame update
    void Start()
    {
        spoilAmount = 0;
        InvokeRepeating("AddSpoil", 0f, 1f);
    }

    void AddSpoil() {
        spoilAmount++;
    }

    public int Health(int max) {
        return (int)Mathf.Round(max*Mathf.Max(100 - spoilAmount, 0)/100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spoilAmount > 75) {
            Destroy(gameObject);
        }
    }
}
