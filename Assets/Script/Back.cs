using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject HelpPanel;
    
    // Start is called before the first frame update
    public void CloseHelp()
    {
        HelpPanel.SetActive(false);
    }
}

