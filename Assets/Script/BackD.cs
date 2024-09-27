using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackD : MonoBehaviour
{
    public GameObject DictionaryPanel;
    
    // Start is called before the first frame update
    public void CloseDictionary()
    {
        DictionaryPanel.SetActive(false);
    }
}
