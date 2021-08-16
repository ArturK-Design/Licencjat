using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material material;
    public Camera Camera;
    public LayerMask Mask;

    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
            material.SetFloat(SizeID, 1);
        else
            material.SetFloat(SizeID, 0);
        var view = Camera.WorldToViewportPoint(transform.position);
        material.SetVector(PosID, view);
    }
}
