using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider healthSlider;
    public Text healthText;
    
    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }
}
