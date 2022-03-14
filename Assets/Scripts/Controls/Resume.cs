using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public Button resume;
    public Transform pausedMenu;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = resume.GetComponent<Button>();
        btn.onClick.AddListener(Clicked);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked()
    { 
        pausedMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
    }
}
