using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {
    private Transform playerTransform;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    private void Start() {
        string tagString = "Player";
        playerTransform = GameObject.FindGameObjectWithTag(tagString).transform;
        if (playerTransform == null) {
            Debug.LogError("Could not find object with tag: " + tagString);
        }
    }

    public float rotationDiff;
    void Update() {
        if (playerIsOverlapping) {
            Vector3 portalToPlayer = playerTransform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f) {
                // Teleport him!
                rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                playerTransform.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                playerTransform.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerIsOverlapping = false;
        }
    }
}