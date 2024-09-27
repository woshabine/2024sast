using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_healing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>()._isBackUp = true;
    }
}
