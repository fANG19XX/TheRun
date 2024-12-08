using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectableControl : MonoBehaviour
{
    public static int orbCount;
    public GameObject orbCountDisplay;
    //public GameObject orbEndDisplay;
    void Update()
    {
        orbCountDisplay.SetActive(true);
        orbCountDisplay.GetComponent<Text>().text = ""+ orbCount;
        //orbEndDisplay.GetComponent<Text>().text = "" + orbCount;
    }
} 