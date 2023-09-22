using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColorFade : MonoBehaviour
{
    public Text text;
    [SerializeField]
    [Range(0f, 5f)] float lerpTime;

    [SerializeField]
    Color[] colorUp;

    int colorIndex = 0;
    float barColor = 0f;

    public CircleCollider2D circleCollider2D;

    //Untuk batasin whilenya
    int ColorFadeManage;


    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }


    private void Update()
    {
        //FontFading();
    }


    void FontFading()
    {
        StartCoroutine(FontFadingCoroutine());
    }

    private IEnumerator FontFadingCoroutine()
    {    

        while (ColorFadeManage<2)
         {

            //Debug.Log("FontFadingCalled");
            //ubah warna sesuai Indeksnya, berdasarkan waktu deltatime
            text.color = Color.Lerp(text.color, colorUp[colorIndex], lerpTime * Time.deltaTime);

            barColor = Mathf.Lerp(barColor, 1f, lerpTime * Time.deltaTime);

            //function bekerja kalo barcolor capai indeks 9.99% (dari colornya)
            if (barColor > .999f)
                {
                    barColor = 0f;
                    colorIndex++;

                    //Untuk looping (gk dipake di script ini)
                    //colorIndex = (colorIndex >= lenColor) ? 0 : colorIndex; 

                    ColorFadeManage++;

                //bisa pake function ini juga, kalo bar color set ke 0.9f doang
                if(ColorFadeManage == 2)
                    {
                        gameObject.SetActive(false);
                
                    }

                }
            yield return null;
            

        }


    }

    public void FontFadePop()
    {

        if (circleCollider2D == null)
        {
        FontFading();
        }



        //nutup circlecollidernya biar gk muncul lagi text.
        if (circleCollider2D != null)
        {
            Debug.Log("CircleColliderOff");
            circleCollider2D.enabled = false;

        }

        
    }


}
