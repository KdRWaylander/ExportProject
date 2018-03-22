using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    [SerializeField] bool m_crosshair;

    CrosshairManager m_crosshairManager;
    MeshRenderer m_crosshairRenderer;

	void Start ()
    {
        m_crosshairManager = GetComponentInChildren<CrosshairManager>();
        m_crosshairRenderer = GetComponentInChildren<MeshRenderer>();

        m_crosshairManager.enabled = m_crosshair;
        m_crosshairRenderer.enabled = m_crosshair;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleCrosshair();
        }
    }

    void ToggleCrosshair()
    {
        m_crosshairManager.enabled = !m_crosshairManager.enabled;
        m_crosshairRenderer.enabled = !m_crosshairRenderer.enabled;
    }
}