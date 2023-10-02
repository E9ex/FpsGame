using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    public Image fill;

    public void sethealth(int health)
    {
        Slider.value = health;
        fill.color=gradient.Evaluate(Slider.normalizedValue);

    }
    //fill.color=gradient.evaluate(1f);
    
}
