using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LeaveRoom : MonoBehaviour
{
    public Button leaveClass;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = leaveClass.GetComponent<Button>();
        btn.onClick.AddListener(Leave);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Leave()
        {
            PhotonNetwork.LeaveRoom();
		OnLeftRoom();
        }

        public void OnLeftRoom()
        {
            SceneManager.LoadScene("Login");
        }


}
