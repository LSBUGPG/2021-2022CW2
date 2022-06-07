using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] trackedObjects;
    List<GameObject> radarObjects;
    public GameObject radarPrefab;
    List<GameObject> borderObjects;
    public float switchDistance;
    public Transform helpTransform;
    private void Start()
    {
        createRadarObject();

    }

    private void Update()
    {
        for (int i = 0; i < radarObjects.Count; i++) 
        {
            if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
            {
                //switches to borderObejcts
                helpTransform.LookAt(radarObjects[i].transform);
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                //Switches back to radarObjects
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                radarObjects[i].layer = LayerMask.NameToLayer("Radar");
            }
        }
    }

    void createRadarObject()
    {
        //Takes 'trackedObjects' Gameobject (enemy) and instantiates 'radarPrefab' which is viewable on camera
        radarObjects = new List<GameObject>();

        borderObjects = new List<GameObject>();

        foreach (GameObject o in trackedObjects)
        {
            GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity,o.transform) as GameObject;
            radarObjects.Add(k);


            //Creates a second 'redDot' on enemies, above is for tracking in immediate area, below is for when out of range on the border of the radar
            GameObject j = Instantiate(radarPrefab, o.transform.position, Quaternion.identity,o.transform) as GameObject;
            borderObjects.Add(j);

        }
    }
}
