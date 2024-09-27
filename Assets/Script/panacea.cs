using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panacea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>().artifact++;
    }
}
