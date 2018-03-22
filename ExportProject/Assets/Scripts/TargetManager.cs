using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {
    [SerializeField] GameObject m_targetUp, m_targetRight, m_targetDown, m_targetLeft;

    void Start()
    {
        LockTargets();
    }

    /* METHODS */
    public void SetTargetInteractible(int _t)
    {
        switch (_t)
        {
            case 1: m_targetUp.GetComponentInChildren<Collider>().enabled       = true;     break;
            case 2: m_targetRight.GetComponentInChildren<Collider>().enabled    = true;     break;
            case 3: m_targetDown.GetComponentInChildren<Collider>().enabled     = true;     break;
            case 4: m_targetLeft.GetComponentInChildren<Collider>().enabled     = true;     break;
            default:                                                                        break;
        }
    }

    public void LockTargets()
    {
        m_targetUp.GetComponentInChildren<Collider>().enabled       = false;
        m_targetRight.GetComponentInChildren<Collider>().enabled    = false;
        m_targetDown.GetComponentInChildren<Collider>().enabled     = false;
        m_targetLeft.GetComponentInChildren<Collider>().enabled     = false;
    }
}