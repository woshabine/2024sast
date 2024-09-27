using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<Rigidbody2D>().velocity *= 0.8f;
        car.GetComponent<CarControl>().change_r(0.15f);
        if (car.GetComponent<CarControl>().artifact>0)
        {
            car.GetComponent<CarControl>().artifact--;
        }
        else
        {
            car.GetComponent<CarControl>().setrAngleV(0.1f);
            StartCoroutine(LostControl());
        }
        
    }

    IEnumerator LostControl()
    {
        GameObject car = GameObject.FindWithTag("Player");
        yield return new WaitForSeconds(1f);
        car.GetComponent<CarControl>().setrAngleV(1f);
    }
}
