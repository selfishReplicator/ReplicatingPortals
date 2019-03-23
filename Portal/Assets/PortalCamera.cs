using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	private Transform mainCamera;
	public Transform portal;
	public Transform otherPortal;
	
	
	private void Start() {
		string tagString = "MainCamera";
		mainCamera = GameObject.FindGameObjectWithTag(tagString).transform;
		if (mainCamera == null) {
			Debug.LogError("Could not find object with tag: " + tagString);
		}
	}

	void Update () {
		Vector3 playerOffsetFromPortal = mainCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * mainCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
