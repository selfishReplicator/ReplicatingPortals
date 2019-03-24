using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {
    public Camera cameraA;
    public Camera cameraB;
    public Shader cutoutShader;

    private Material cameraMatA;
    private Material cameraMatB;

    public GameObject renderPlaneA;
    public GameObject renderPlaneB;

    void Start() {
        cameraMatA = new Material(cutoutShader);
        cameraMatB = new Material(cutoutShader);

        if (cameraA.targetTexture != null) {
            cameraA.targetTexture.Release();
        }

        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null) {
            cameraB.targetTexture.Release();
        }

        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;

        renderPlaneA.AddComponent<MeshRenderer>().material = cameraMatB;
        renderPlaneB.AddComponent<MeshRenderer>().material = cameraMatA;

    }
}