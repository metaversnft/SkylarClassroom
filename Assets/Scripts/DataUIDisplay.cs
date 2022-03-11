using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataUIDisplay : MonoBehaviour
{
    [SerializeField]
     FishData M_FishData;

    [SerializeField]
    TMP_Text FMText;

[SerializeField]
    TMP_Text FNText;

    const string k_DefaultText = "Fishery Management: "; 
    
    public enum FishName
    {
        White_Hake,
        Mackerel,
        Shark,
        Lobster,
        Blueline_Tilefish
       
    }

    public FishName fishName;

    void Update()
    {
        if (M_FishData.DataCaptured)
        {
            FMText.text = k_DefaultText + fishName.ToString()+ ": " + M_FishData.GetFisheryManagement(fishName).ToString();
        }
    }
    
}
