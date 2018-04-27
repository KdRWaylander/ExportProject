using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protractor : MonoBehaviour {
    Transform m_HUD, m_PointOfView, m_FixationPoint, m_LeftMirror, m_CentralMirror, m_CentralDisplay, m_RightMirror;

	void Start ()
    {
        m_HUD = GameObject.Find("HUD").transform;
        m_PointOfView = GameObject.Find("LagCameraPivotTracker").transform;
        m_CentralMirror = GameObject.Find("CentralMirror").transform;
        m_RightMirror = GameObject.Find("RightMirror").transform;
        m_CentralDisplay = GameObject.Find("TactileScreen").transform;
        m_LeftMirror = GameObject.Find("LeftMirror").transform;
        m_FixationPoint = GameObject.Find("FixationPoint").transform;

        Vector3 reference = m_PointOfView.position - m_HUD.position;
        Vector3 reference2 = m_PointOfView.position - m_FixationPoint.position;

        Debug.Log("== HUD ==");
        Debug.Log("Left mirror: " + Vector3.Angle(reference, m_PointOfView.position - m_LeftMirror.position).ToString());
        Debug.Log("Central mirror: " + Vector3.Angle(reference, m_PointOfView.position - m_CentralMirror.position).ToString());
        Debug.Log("Central display: " + Vector3.Angle(reference, m_PointOfView.position - m_CentralDisplay.position).ToString());
        Debug.Log("Right mirror: " + Vector3.Angle(reference, m_PointOfView.position - m_RightMirror.position).ToString());
        Debug.Log("");
        Debug.Log("== FIXATION ==");
        Debug.Log("Left mirror: " + Vector3.Angle(reference2, m_PointOfView.position - m_LeftMirror.position).ToString());
        Debug.Log("Central mirror: " + Vector3.Angle(reference2, m_PointOfView.position - m_CentralMirror.position).ToString());
        Debug.Log("Central display: " + Vector3.Angle(reference2, m_PointOfView.position - m_CentralDisplay.position).ToString());
        Debug.Log("Right mirror: " + Vector3.Angle(reference2, m_PointOfView.position - m_RightMirror.position).ToString());
    }
}