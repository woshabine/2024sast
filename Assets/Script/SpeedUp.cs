using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<Rigidbody2D>().velocity *= 1.2f;
    }
}
