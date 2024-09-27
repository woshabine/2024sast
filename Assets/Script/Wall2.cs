using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject car = GameObject.FindWithTag("Player");
        car.GetComponent<CarControl>().change_r(-0.5f);
    }
}
