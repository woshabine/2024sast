using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overclock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>().burstV1 += 50;
        car.GetComponent<CarControl>().burstV2 += 50;
        car.GetComponent<CarControl>().burstV3 += 50;
        if (car.GetComponent<CarControl>().artifact > 0)
        {
            car.GetComponent<CarControl>().artifact--;
        }
        else
        {
            car.GetComponent<CarControl>().burstRate1 = 0.002857f;
            car.GetComponent<CarControl>().burstRate2 = 0.004f;
            car.GetComponent<CarControl>().burstRate3 = 0.006666f;
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        GameObject car = GameObject.FindWithTag("Player");
        yield return new WaitForSeconds(3f);
        if (car.GetComponent<CarControl>().artifact > 0)
        {
            car.GetComponent<CarControl>().artifact--;
        }
        else
        {
            car.GetComponent<CarControl>().burstV1 -= 50;
            car.GetComponent<CarControl>().burstV2 -= 50;
            car.GetComponent<CarControl>().burstV3 -= 50;
        }

    }
}
