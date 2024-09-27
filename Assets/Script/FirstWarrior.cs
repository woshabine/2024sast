using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWarrior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<Rigidbody2D>().velocity *= 0.7f;
        car.GetComponent<CarControl>().change_r(0.3f);
    }
    
}
