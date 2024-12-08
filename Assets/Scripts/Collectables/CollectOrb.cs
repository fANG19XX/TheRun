using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectableControl.orbCount += 1;
        this.gameObject.SetActive(false);   
    }
}