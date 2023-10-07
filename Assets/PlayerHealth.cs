using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    private float lerpTimer;
    private float health;
    public float maxhealth = 100f;
    public float chipSpeed = 2f;
    public Image fronthealthbar;
    public Image backhealthBar;
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxhealth);
        updatehealthUI();
    }

    public void updatehealthUI()
    {
        Debug.Log(health);
        float fillf = fronthealthbar.fillAmount;
        float fillb = backhealthBar.fillAmount;
        float fraction = health / maxhealth;
        if (fillb> fraction)
        {
            fronthealthbar.fillAmount = fraction;
            backhealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;//anims wiill be better.
            backhealthBar.fillAmount = Mathf.Lerp(fillb, fraction, percentComplete);
        }

        if (fillf<fraction)
        {
            backhealthBar.color = Color.green;
            backhealthBar.fillAmount = fraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            fronthealthbar.fillAmount = Mathf.Lerp(fillf, backhealthBar.fillAmount, percentComplete);
        }
    }

    public void takedamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;

    }

    public void restoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

}
