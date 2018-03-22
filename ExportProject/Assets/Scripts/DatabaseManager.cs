using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour {
	List<int> m_list;

	void Start ()
    {
        m_list = new List<int>() {1,1,1,2,2,2,3,3,3,4,4,4};
        m_list = FisherYatesShuffle(m_list);
	}

    /* GETTERS - SETTERS */
    public List<int> GetTargetOrderList()
    {
        return m_list;
    }

    /* INTERNAL */
    // Fisher-Yates shuffle: https://fr.wikipedia.org/wiki/M%C3%A9lange_de_Fisher-Yates
    private List<int> FisherYatesShuffle(List<int> _L)
    {
        int a, j;
        for (int i = _L.Count - 1; i > 0; i--)
        {
            j = Random.Range(0, i + 1);
            a = _L[i];
            _L[i] = _L[j];
            _L[j] = a;
        }
        return _L;
    }
}