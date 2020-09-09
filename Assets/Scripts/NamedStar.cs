using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NamedStar : MonoBehaviour
{
    public TMP_Text starName;
    [SerializeField] GameObject starGraphics;

    Transform playerViewpoint;

     public void Init(float size, Color color, string name)
    {
        starGraphics.GetComponent<Renderer>().material.SetColor("_Color", color);
        //transform.localScale = Vector3.one * size * 2f;
        starName.text = name;


        playerViewpoint = Camera.main.transform;
    }

    void Update()
    {
        FaceCamera();
        DynamicScale();
    }

    private void DynamicScale()
    {
        float scaleFactor;

        float distance = Vector3.Distance(transform.position, playerViewpoint.position);

        scaleFactor = Mathf.Clamp01(distance);

        transform.localScale = transform.localScale = Vector3.one * 0.5f * scaleFactor;
    }

    void FaceCamera()
    {
        Vector3 direction = -(playerViewpoint.position - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = rotation;
    }
}
