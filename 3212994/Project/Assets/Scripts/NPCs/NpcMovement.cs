using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    // list of waypoints
    public GameObject[] waypointz;
    // used to reset the loop
    private int offset;

    // te initial set speed of the NPC movement
    public float speeed = 0;

    // used for randomising stop time
    public float minPause, maxPause;
    // float for amount of time each npc pauses in their loop cycle
    public float pauseTime;

    // Start is called before the first frame update
    void Start()
    {
        // begins each coroutine
        StartCoroutine("Move");
        StartCoroutine("Interupt");
    }

    public void StartCoroutines()
    {
        // coroutine to move the NPCs
        StartCoroutine("Move");
        // coroutine to stop the NPC's from moving at random intervals
        StartCoroutine("Interupt");
    }

    public void StopCoroutines()
    {
        //
        StopAllCoroutines();
    }

    IEnumerator Move()
    {
        // offset used to reset the loop
        if (offset >= waypointz.Length)
        {
            offset = 0;
        }

        // moves the npc while it is not on the same position as the waypoints
        while (transform.position != waypointz[0 + offset].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypointz[0 + offset].transform.position, speeed);
            yield return null;
        }

        yield return null;
        // increases the offset by one after movement cycle is complete
        offset = offset + 1;

        // restarts the movement loop
        StartCoroutine("Move");
    }

    IEnumerator Interupt()
    {
        // radomising between the minimum and maximum time the npc is paused
        yield return new WaitForSecondsRealtime(Random.Range(minPause, maxPause));
        // pauses the npc
        StopCoroutine("Move");
        // the set amount of time the npc is paused for
        yield return new WaitForSecondsRealtime(pauseTime);
        //restarts movement after the pause
        StartCoroutine("Move");
        // restarts pausing loop
        StartCoroutine("Interupt");
    }
}
