using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptext;
    
    void Start()
    {
        
    }

    public void updatetext(string promptmessage)
    {
        promptext.text = promptmessage;
    }
}
