using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elapidaes : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<Rigidbody2D>().velocity *= 0.88f;
        if (car.GetComponent<CarControl>().artifact > 0)
        {
            car.GetComponent<CarControl>().artifact--;
        }
        else
        {
            car.GetComponent<CarControl>().isDisturbed = -1;
            StartCoroutine(Disturbing());
        }
        
    }
    IEnumerator Disturbing()
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>().change_r(0.3f);
        yield return new WaitForSeconds(2f);
        car.GetComponent<CarControl>().isDisturbed  = 1;
    }
}
