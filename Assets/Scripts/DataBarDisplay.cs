using System;
using TMPro;
using UnityEngine;

public class DataBarDisplay : MonoBehaviour
{
    [SerializeField]
    FishData m_FishData;

    [SerializeField]
    TMP_Text m_Fish1;

    [SerializeField]
    TMP_Text m_Value1;

    [SerializeField]
    Transform m_Bar1;

    [SerializeField]
    TMP_Text m_Fish2;

    [SerializeField]
    TMP_Text m_Value2;

    [SerializeField]
    Transform m_Bar2;

    [SerializeField]
    TMP_Text m_Fish3;

    [SerializeField]
    TMP_Text m_Value3;

    [SerializeField]
    Transform m_Bar3;

    [SerializeField]
    TMP_Text m_Fish4;

    [SerializeField]
    TMP_Text m_Value4;

    [SerializeField]
    Transform m_Bar4;

    [SerializeField]
    TMP_Text m_Fish5;

    [SerializeField]
    TMP_Text m_Value5;

    [SerializeField]
    Transform m_Bar5;

    [SerializeField]
    DataUIDisplay.FishName m_fishname1;

    public DataUIDisplay.FishName fishname1
    {
        get => m_fishname1;
        set => m_fishname1 = value;
    }

    [SerializeField]
    DataUIDisplay.FishName m_fishname2;

    public DataUIDisplay.FishName fishname2
    {
        get => m_fishname2;
        set => m_fishname2 = value;
    }

    [SerializeField]
    DataUIDisplay.FishName m_fishname3;

    public DataUIDisplay.FishName fishname3
    {
        get => m_fishname3;
        set => m_fishname3 = value;
    }

    [SerializeField]
    DataUIDisplay.FishName m_fishname4;

    public DataUIDisplay.FishName fishname4
    {
        get => m_fishname4;
        set => m_fishname4 = value;
    }

    [SerializeField]
    DataUIDisplay.FishName m_fishname5;

    public DataUIDisplay.FishName fishname5
    {
        get => m_fishname5;
        set => m_fishname5 = value;
    }

    int? m_PositiveValues1;
    int? m_PositiveValues2;
    int? m_PositiveValues3;
    int? m_PositiveValues4;
    int? m_PositiveValues5;
    int?[] m_CurrentValue;

    bool m_DataChanged;
    bool m_DataSet;
    const int k_ValueMod = 5;

    DataUIDisplay.FishName m_SetFishname1;
    DataUIDisplay.FishName m_SetFishname2;
    DataUIDisplay.FishName m_SetFishname3;
    DataUIDisplay.FishName m_SetFishname4;
    DataUIDisplay.FishName m_SetFishname5;

    void Start()
    {
       
        m_PositiveValues1 = m_FishData.GetFishProtein(m_fishname1);
        m_PositiveValues2 = (m_FishData.GetFishProtein(m_fishname2));
        m_PositiveValues3 = (m_FishData.GetFishProtein(m_fishname3));
        m_PositiveValues4 = (m_FishData.GetFishProtein(m_fishname4));
        m_PositiveValues5 = (m_FishData.GetFishProtein(m_fishname5));

        m_SetFishname1 = m_fishname1;
        m_SetFishname2 = m_fishname2;
        m_SetFishname3 = m_fishname3;
        m_SetFishname4 = m_fishname4;
        m_SetFishname5 = m_fishname5;

        m_CurrentValue = new[] { m_PositiveValues1, m_PositiveValues2, m_PositiveValues3, m_PositiveValues4, m_PositiveValues5 };
    }

    void Update()
    {
        if (m_FishData.DataCaptured && !m_DataSet)
        {
            m_PositiveValues1 = m_FishData.GetFishProtein(m_fishname1);
            m_PositiveValues2 = (m_FishData.GetFishProtein(m_fishname2));
            m_PositiveValues3 = (m_FishData.GetFishProtein(m_fishname3));
            m_PositiveValues4 = (m_FishData.GetFishProtein(m_fishname4));
            m_PositiveValues5 = (m_FishData.GetFishProtein(m_fishname5));

            m_CurrentValue = new[] { m_PositiveValues1, m_PositiveValues2, m_PositiveValues3, m_PositiveValues4, m_PositiveValues5 };
            m_DataSet = true;
        }

        m_Fish1.text = m_fishname1.ToString();
        m_Fish2.text = m_fishname2.ToString();
        m_Fish3.text = m_fishname3.ToString();
        m_Fish4.text = m_fishname4.ToString();
        m_Fish5.text = m_fishname5.ToString();

        m_Value1.text = m_CurrentValue[0].ToString();
        m_Value2.text = m_CurrentValue[1].ToString();
        m_Value3.text = m_CurrentValue[2].ToString();
        m_Value4.text = m_CurrentValue[3].ToString();
        m_Value5.text = m_CurrentValue[4].ToString();

        if (m_DataSet)
        {
            m_Bar1.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[0]), 1);
            m_Bar2.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[1]), 1);
            m_Bar3.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[2]), 1);
            m_Bar4.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[3]), 1);
            m_Bar5.transform.localScale = new Vector3(1, GetNormalizedValue(m_CurrentValue[4]), 1);
        }

        if (m_fishname1 != m_SetFishname1 ||
            m_fishname2 != m_SetFishname2 ||
            m_fishname3 != m_SetFishname3 ||
            m_fishname4 != m_SetFishname4 ||
            m_fishname5 != m_SetFishname5)
        {
            m_SetFishname1 = m_fishname1;
            m_SetFishname2 = m_fishname2;
            m_SetFishname3 = m_fishname3;
            m_SetFishname4 = m_fishname4;
            m_SetFishname5 = m_fishname5;
            m_DataSet = false;
        }

    }

    float GetNormalizedValue(int? value)
    {
        float retVal = ((float)value - (float)GetLowestValue()) / ((float)GetHighestValue() - (float)GetLowestValue());
        return (retVal + 0.25f) * k_ValueMod;
    }

    int? GetHighestValue()
    {
        int? highestValue = -1;

        for (int i = 0; i < m_CurrentValue.Length; i++)
        {
            if (m_CurrentValue[i] > highestValue)
            {
                highestValue = m_CurrentValue[i];
            }
        }

        return highestValue;
    }

    int? GetLowestValue()
    {
        int? lowestValue = Int32.MaxValue;

        for (int i = 0; i < m_CurrentValue.Length; i++)
        {
            if (m_CurrentValue[i] < lowestValue)
            {
                lowestValue = m_CurrentValue[i];
            }
        }

        return lowestValue;
    }
}
