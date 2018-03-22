using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    bool m_isRecording;
    bool m_isRunning;

    private float m_timer;

    void Start () {
        m_timer = 0;
        m_isRunning = false;
        m_isRecording = false;
	}

    void Update()
    {
        if (m_isRunning)
        {
            m_timer += Time.deltaTime;
        }
    }

    /* METHODS */
    public float Lap() {
        return m_timer;
    }

    public void Reset() {
        m_timer = 0;
    }

    public void Begin() {
        m_isRunning = true;
    }

    public void Stop() {
        m_isRunning = false;
    }

    /* GETTERS - SETTERS */
    public bool GetIsRecording()
    {
        return m_isRecording;
    }
    
    public bool GetIsRunning()
    {
        return m_isRunning;
    }

    public void SetIsRecording(bool _isRecording)
    {
        m_isRecording = _isRecording;
    }

    public void SetIsRunning(bool _isRunning)
    {
        m_isRunning = _isRunning;
    }
}