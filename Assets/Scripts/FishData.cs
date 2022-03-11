using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Object = System.Object;
using Random = UnityEngine.Random;

public class FishData : MonoBehaviour
{

    string url = "https://skylar3.s3.eu-west-2.amazonaws.com/Earth-school/Fish+species.json";
    TheData[] m_Fishes;
     bool m_DataCaptured;

    public bool DataCaptured
    {
        get => m_DataCaptured;
    }

    void OnEnable()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error occured with web request");
            }
            else
            {
                m_Fishes = JsonConvert.DeserializeObject<TheData[]>(webRequest.downloadHandler.text);

                m_DataCaptured = true;
            }
        }
    }

    public string GetScientificeName(DataUIDisplay.FishName fishName)
    {
        if (m_DataCaptured)
        {
            return m_Fishes[GetFishName(fishName)].ScientificName;
        }
        else
        {
            return "Nothing";
        }
    }

public string GetFisheryManagement(DataUIDisplay.FishName fishName)
    {
        if (m_DataCaptured)
        {
            return m_Fishes[GetFishName(fishName)].FisheryManagement;
        }
        else
        {
            return "Nothing";
        }
    }

	
     public int? GetFishProtein(DataUIDisplay.FishName fishName)
    {
        if (m_DataCaptured)
        {
            return m_Fishes[GetFishName(fishName)].Protein;
        }
        else
        {
            return 0;
        }
    }


    public int GetFishName(DataUIDisplay.FishName fishName)
    {
        return (int) fishName;
    }
}



public class TheData
{
    
    public string ScientificName;
public string FisheryManagement;
    public int? Protein;
     
}
