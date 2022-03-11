using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public Button resume;
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
        FindObjectOfType<GameManager>().Paused();
    }
}
