using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int isOverlap = 0;
    private void OnTriggerEnter(Collider obj)
    {
        isOverlap = 1;
        Debug.Log("isOverlap = 1");
    }
     
    private void OnTriggerStay(Collider obj)
    {
        isOverlap = 1;
        Debug.Log("isOverlap = 1");
    }

    private void OnTriggerExit(Collider obj)
    {
        isOverlap = 0;
    }
}
