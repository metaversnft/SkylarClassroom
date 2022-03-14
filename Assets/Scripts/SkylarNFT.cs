using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SkylarNFT : MonoBehaviour
{
    void Start()
    {
        
    }

    IEnumerator GetNFT()
    {
        UnityWebRequest nft = UnityWebRequestTexture.GetTexture("ipfs://https://bafkreiflj6cgvjh2i37atnrw62zwsxscecublvgsvzzbqljamkaymkpkuq");
        yield return nft.SendWebRequest();
        this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)nft.downloadHandler).texture;


    }
    
}

