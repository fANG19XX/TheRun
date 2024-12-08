using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    public int zPos = 40;
    public bool creatingSection = false;
    public int secNum;
    public float sectionDestroyDistance = 100f; // Distance threshold for removing sections
    private List<GameObject> activeSections = new List<GameObject>(); // Keep track of active sections
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
            StartCoroutine(RemovePassedSections());

        }
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, sections.Length);
        GameObject newSection = Instantiate(sections[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        activeSections.Add(newSection);
        zPos += 35;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
    IEnumerator RemovePassedSections()
    {
        for (int i = 0; i < activeSections.Count; i++)
        {
            GameObject section = activeSections[i];
            float distanceToPlayer = transform.position.z - section.transform.position.z;
            if (distanceToPlayer > sectionDestroyDistance)
            {
                Destroy(section); // Destroy the cloned section
                activeSections.RemoveAt(i);
                yield return new WaitForSeconds(2);
                i--;
            }
        }
    }
}