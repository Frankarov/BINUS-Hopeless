using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontFade : MonoBehaviour
{
    public Text textPopUp;
    private float fadeTime;
    private bool isFading;

    private void Start()
    {
        textPopUp.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0f;
        isFading = false;
    }
    void Update()
    {
        if(isFading)
        {

        }
    }

    void Fade()
    {
        textPopUp.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if(textPopUp.color.a == 1 && fadeTime > 1.5f)
        {
            isFading = false;
            fadeTime = 0f;
        }
    }

}
