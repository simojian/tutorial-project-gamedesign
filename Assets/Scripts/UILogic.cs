using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public MovementScript playerScript;
    void Start()
    {
        
    }
    
    void Update()
    {
        tmp.text = playerScript.currentVelocity.ToString();
    }
}
