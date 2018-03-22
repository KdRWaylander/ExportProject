using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManager : MonoBehaviour {
    float m_farClipPlane = 1000f;

    void Update()
    {
        Ray ray = new Ray(transform.parent.position, transform.parent.transform.forward);
        RaycastHit hit;

        transform.LookAt(transform.parent.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);

        if (Physics.Raycast(ray, out hit))
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, hit.distance);
            transform.localScale = new Vector3(0.025f * hit.distance, 0.025f * hit.distance, 0.0f);
        }
        else
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.95f * m_farClipPlane);
            transform.localScale = new Vector3(0.025f * 0.95f * m_farClipPlane, 0.025f * 0.95f * m_farClipPlane, 0.0f);
        }
    }
}
