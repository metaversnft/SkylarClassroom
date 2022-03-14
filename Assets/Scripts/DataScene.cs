using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataScene : MonoBehaviour
{
   public Button DataScience;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = DataScience.GetComponent<Button>();
        btn.onClick.AddListener(DataScene1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DataScene1()
    {
        SceneManager.LoadScene("DataViz");
    }

}
