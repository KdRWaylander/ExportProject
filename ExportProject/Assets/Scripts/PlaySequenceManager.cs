using UnityEngine;
using System.Collections;

public class PlaySequenceManager : MonoBehaviour {
    DatabaseManager m_DBM;
    TimeManager     m_timer;
    HUDManager      m_HUD;
    TargetManager   m_targetManager;

    [SerializeField] float m_temporisationTime;

    bool    m_isRunning, m_lastIteration;
    int     m_i;
    
    /* INITIALIZATION */
	void Start () {
        m_DBM            = GameObject.Find("GeneralManager").GetComponent<DatabaseManager>();
        m_timer          = GameObject.Find("GeneralManager").GetComponent<TimeManager>();
        m_HUD            = GameObject.Find("HUD").GetComponent<HUDManager>();
        m_targetManager  = GameObject.Find("TARGETS").GetComponent<TargetManager>();

        m_isRunning     = false;
        m_lastIteration = false;
        m_i             = 0;
    }
	
    /* PUBLIC METHODS */
	public IEnumerator FirstStep(){
        m_isRunning = true;                                                         // Prevent 2nd sequence to be launched in parallel
        m_lastIteration = false;                                                    // Reset last iteration bool just in case
        StartCoroutine(m_HUD.DisplayStartSequence());                               // 3-2-1 sequence
        yield return new WaitForSeconds(3);                                         // Wait for start sequence end

        m_timer.Begin();                                                            // Start timer
        yield return new WaitForSeconds(m_temporisationTime);                       // Temporisation
        m_HUD.DisplayTexture(m_DBM.GetTargetOrderList()[m_i]);                      // Display first arrow
        m_targetManager.SetTargetInteractible(m_DBM.GetTargetOrderList()[m_i]);     // Make first target shootable

        m_i++;                                                                      // Prepare for next iteration
        StopCoroutine("FirstStep");                                                 // Clean up
	}

    public IEnumerator NextStep()
    {
        yield return new WaitForSeconds(m_temporisationTime);                       // Temporisation
        m_HUD.DisplayTexture(m_DBM.GetTargetOrderList()[m_i]);                      // Display i-th arrow
        m_targetManager.SetTargetInteractible(m_DBM.GetTargetOrderList()[m_i]);     // Make i-th target shootable

        if (m_i < m_DBM.GetTargetOrderList().Count - 1)
        {
            m_i++;
        }
        else
        {
            m_i = 0;
            m_lastIteration = true;
        }

        StopCoroutine("NextStep");
    }

    #region GETTERS - SETTERS
    public bool GetIsRunning()
    {
        return m_isRunning;
    }

    public bool GetLastIteration()
    {
        return m_lastIteration;
    }

    public float GetTemporisationTime()
    {
        return m_temporisationTime;
    }

    public void SetIsRunning(bool _isRunning)
    {
        m_isRunning = _isRunning;
    }
    #endregion
}