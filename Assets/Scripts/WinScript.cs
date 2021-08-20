using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject WNPanel;

    void Start()
    {
        WNPanel.SetActive(false);
    }
     void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Win") {
            WNPanel.SetActive(true);
        }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
