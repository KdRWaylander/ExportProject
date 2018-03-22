using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class OutputWriter : MonoBehaviour {
    [SerializeField] bool m_record;

    string m_filePath;
    List<string> m_months;

    /* INITIALIZATION */
    void Start()
    {
        m_months = new List<string>() { "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre" };

        SetFilePath("Outputs/Sujet_"
            + DateTime.Now.Day.ToString() + "_"
            + GetMonth() + "_"
            + DateTime.Now.Hour.ToString() + "h"
            + GetFormatedMinutes() + ".txt");

        CreateFile();
    }

    /* PUBLIC METHODS */
    public void AddTrialResults(string _targetName, Vector3 _targetWorldPosition, Quaternion _targetWorldRotation, Vector3 _targetWorldSize, Vector3 _targetWorldScale, Vector3 _hitPoint, float _completionTime)
    {
		File.AppendAllText (m_filePath,
                            _targetName + ";" 
		                    + _targetWorldPosition.x.ToString() + ";" + _targetWorldPosition.y.ToString() + ";" + _targetWorldPosition.z.ToString() + ";"
                            + _targetWorldRotation.eulerAngles.x.ToString() + ";" + _targetWorldRotation.eulerAngles.y.ToString() + ";" + _targetWorldRotation.eulerAngles.z.ToString() + ";"
                            + _targetWorldRotation.w.ToString() + ";" + _targetWorldRotation.x.ToString() + ";" + _targetWorldRotation.y.ToString() + ";" + _targetWorldRotation.z.ToString() + ";"
                            + _targetWorldSize.x.ToString() + ";" + _targetWorldSize.y.ToString() + ";" + _targetWorldSize.z.ToString() + ";"
                            + _targetWorldScale.x.ToString() + ";" + _targetWorldScale.y.ToString() + ";" + _targetWorldScale.z.ToString() + ";"
                            + _hitPoint.x.ToString() + ";" + _hitPoint.y.ToString() + ";" + _hitPoint.z.ToString() + ";"
                            + _completionTime.ToString() + System.Environment.NewLine);
	}

    public void AddRelativeResults(string _targetName, Vector3 _relativeError, float _completionTime)
    {
        File.AppendAllText(m_filePath,
                            _targetName + ";"
                            + _relativeError.x.ToString() + ";" + _relativeError.z.ToString() + ";"
                            + _completionTime.ToString() + System.Environment.NewLine);
    }

    public void StandardExit()
    {
        File.AppendAllText(m_filePath, "Process ended correctly");
    }

    public void ClearOutputFile ()
    {
		File.WriteAllText (m_filePath, "");
	}

	public void CreateFile ()
    {
		if (!File.Exists (m_filePath)) {
			File.Create (m_filePath).Close ();
		} else {
			ClearOutputFile();
		}
	}

    /* PRIVATE METHODS */
    private string GetMonth()
    {
        int mo = Int32.Parse(DateTime.Now.Month.ToString());
        return m_months[mo - 1];
    }

    private string GetFormatedMinutes()
    {
        string mi = DateTime.Now.Minute.ToString();
        return (mi.Length < 2) ? "0" + mi : mi;
    }

    /* GETTERS - SETTERS */
    public void SetFilePath(string _filePath) {
        m_filePath = _filePath;
    }

    public bool GetRecord()
    {
        return m_record;
    }

    public void SetRecord(bool _record)
    {
        m_record = _record;
    }
}