using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    public Text text;
    [SerializeField]
    [Range(0f, 1f)] float lerpTime;

    [SerializeField]
    Color[] colorUp;

    int colorIndex = 0;
    int lenColor;
    float timeColor = 0f;

    private Color textColor;

    void Start()
    {
        textColor = text.color;
        lenColor = colorUp.Length;
    }

    void Update()
    {   
        text.color = Color.Lerp(text.color, colorUp[colorIndex], lerpTime*Time.deltaTime);

        timeColor = Mathf.Lerp(timeColor,1f,lerpTime * Time.deltaTime);
        if(timeColor>.9f){
            timeColor = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= lenColor) ? 0 : colorIndex;
        }

    }
}
