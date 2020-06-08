using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public float pulseSpeed = 20f;
    public float pulseIntensity = 5f;

    [Header("2 - OutlineFire")]
    [Header("1 - OutlineBasic")]
    [Header("0 - OutlineAura")]

    public int shaderInUse = 0;

    public void lightUp()
    {
        //debug
        Debug.Log("Looking at item.");
        //zmienne
        float pulse = Mathf.Sin(Time.time * pulseSpeed) * pulseIntensity; //sinus od -1 do 1
        float pulseClamp = Mathf.Clamp01((Mathf.Sin(Time.time * pulseSpeed) * pulseIntensity)); //sinus od 0 do 1

        //Tutaj w kodzie zadecydujemy z ktorego shadera skorzystac:
        //OutlineAura
        if (shaderInUse == 0)
        {
            Material mat = gameObject.GetComponent<Renderer>().material;
            //Debug.Log(mat.GetFloat("_Value")); //zgubiłem to _ i przez 20 minut szukałem próbowałem debugować, pozdro

            //intensywność
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Value", pulse);
            //przezroczystość
            gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Brightness", 1.5f);
        }

        //OutlineBasic
         else if (shaderInUse == 1)
        {
            //różne rzeczy z shaderem, które można zrobić
        }

        //OutlineFire
        else if (shaderInUse == 2) {

        }
        else if (shaderInUse == 3) {

        }

        else {
            Debug.Log("zły numer shadera przypisany w edytorze");
        }

    }
}
