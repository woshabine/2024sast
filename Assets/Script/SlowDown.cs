using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<Rigidbody2D>().velocity *= 0.8f;
        car.GetComponent<CarControl>().change_r(0.1f);
    }
}
