using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPressurePlate : MonoBehaviour {

    [SerializeField] private DoorAnimated door;

    private float timer;

    private void Update() {
        if (timer > 0f) {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                door.CloseDoor();
            }
        }
    }
    private void OnTriggerStay(Collider collision) {
        float timeToStayOpen = 2f;
        timer = timeToStayOpen;
    }

    private void OnTriggerEnter(Collider collision) {
        door.OpenDoor();
    }

}
