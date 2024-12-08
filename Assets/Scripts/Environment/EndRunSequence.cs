using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class EndRunSequence : MonoBehaviour
{

    //public GameObject endScreen;
    //void Start()
    //{
    //    //StartCoroutine(EndSequence());
    //}
    //IEnumerator EndSequence()
    //{
    //    yield return new WaitForSeconds(1);
    //    endScreen.SetActive(true);

    //}
    //public GameObject orbCounter;

    //void Update()
    //{
    //    //orbCounter.SetActive(true);
    //    orbCounter.GetComponent<UnityEngine.UI.Text>().text = "" + CollectableControl.orbCount;
    //}
    public void Retry()
    {
        SceneManager.LoadScene(1);
        CollectableControl.orbCount = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        CollectableControl.orbCount = 0;
    }
}