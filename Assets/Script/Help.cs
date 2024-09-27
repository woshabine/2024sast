using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject HelpPanel;
    
    // Start is called before the first frame update
    public void ShowHelp()
    {
        HelpPanel.SetActive(true);
    }
}
