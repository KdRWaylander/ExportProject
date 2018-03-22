using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {
    [Header("General")]
    [SerializeField] Material m_noArrow;
    [SerializeField] Material m_thumbsUp;

    [Header("Arrows")]
    [SerializeField] Material m_upArrow;
    [SerializeField] Material m_rightArrow;
    [SerializeField] Material m_downArrow;
    [SerializeField] Material m_leftArrow;

    [Header("Digits")]
    [SerializeField] Material m_one;
    [SerializeField] Material m_two;
    [SerializeField] Material m_three;

    /* INITIALIZATION */
    void Start()
    {
        GetComponent<Renderer>().material = m_noArrow;
    }

    /* PUBLIC METHODS */
    public IEnumerator DisplayStartSequence ()
    {
        DisplayThree(); yield return new WaitForSeconds(0.6f); DisplayNoArrow(); yield return new WaitForSeconds(0.4f);
        DisplayTwo();   yield return new WaitForSeconds(0.6f); DisplayNoArrow(); yield return new WaitForSeconds(0.4f);
        DisplayOne();   yield return new WaitForSeconds(0.6f); DisplayNoArrow(); yield return new WaitForSeconds(0.4f);
        DisplayNoArrow(); StopCoroutine("DisplayStartSequence");
    }

    public void DisplayTexture(int _t) {
        switch (_t)
        {
            case 0: DisplayNoArrow();       break;
            case 1: DisplayUpArrow();       break;
            case 2: DisplayRightArrow();    break;
            case 3: DisplayDownArrow();     break;
            case 4: DisplayLeftArrow();     break;
            case 5: StartCoroutine(DisplayThumbsUp());      break;
            default:                        break;
        }
    }

    /* PRIVATE METHODS */
    void DisplayNoArrow()
    {
        GetComponent<Renderer>().material = m_noArrow;
    }

    IEnumerator DisplayThumbsUp()
    {
        GetComponent<Renderer>().material = m_thumbsUp;
        yield return new WaitForSeconds(2);
        DisplayNoArrow();
        StopCoroutine("DisplayThumbsUp");
    }

    void DisplayUpArrow()
    {
        GetComponent<Renderer>().material = m_upArrow;
    }

    void DisplayRightArrow()
    {
        GetComponent<Renderer>().material = m_rightArrow;
    }

    void DisplayDownArrow()
    {
        GetComponent<Renderer>().material = m_downArrow;
    }

    void DisplayLeftArrow()
    {
        GetComponent<Renderer>().material = m_leftArrow;
    }

    void DisplayOne()
    {
        GetComponent<Renderer>().material = m_one;
    }

    void DisplayTwo()
    {
        GetComponent<Renderer>().material = m_two;
    }

    void DisplayThree()
    {
        GetComponent<Renderer>().material = m_three;
    }
}