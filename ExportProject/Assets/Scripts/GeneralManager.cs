using System.Collections;
using UnityEngine;

public class GeneralManager : MonoBehaviour {
    PlaySequenceManager     m_PSM;

    /* INITIALIZATION */
    void Start ()
    {
        m_PSM = GetComponent<PlaySequenceManager>();
    }

    void Update()
    {
        // Start sequence: Y_manette ou A_clavier
        if ((Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.A)) && !m_PSM.GetIsRunning())
        {
            StartCoroutine(m_PSM.FirstStep());
        }

        // Toggle menu: LeftAlt_clavier ou Start_manette
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            //panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }

        // Quitter: Back_manette ou Echap_clavier
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Application.Quit();
        }
    }
}