using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour {
    [SerializeField] int m_maxFrameRate;
    int m_fps;

	void Awake () {
        LockFrameRate();
	}

    void Update(){
        m_fps = (int)(1 / Time.deltaTime);
    }

    void LockFrameRate()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = m_maxFrameRate;
    }

    public int GetFPS()
    {
        return m_fps;
    }
}