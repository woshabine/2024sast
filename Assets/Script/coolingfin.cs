using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolingfin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>().burstV1 += 50;
        car.GetComponent<CarControl>().burstV2 += 50;
        car.GetComponent<CarControl>().burstV3 += 50;
    }
}
