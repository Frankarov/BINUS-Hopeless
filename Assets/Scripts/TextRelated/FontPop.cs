using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FontPop : MonoBehaviour
{

    public CircleCollider2D circleCollider2D;
    public MeshRenderer meshRenderer;

    //public LerpColorFade fadeScript;


    [SerializeField]
    private float waitFontPop;

    private void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        meshRenderer = GetComponent<MeshRenderer>();
        
    }
    public void FontPopOut()
    {



        gameObject.SetActive(true);
        StartCoroutine(FontGone());
        //StartCoroutine(FontFadingIE());


        if(circleCollider2D != null)
        {
            Debug.Log("CircleColliderOff");
            circleCollider2D.enabled = false;

        }
    }

    private IEnumerator FontGone()
    {
        yield return new WaitForSeconds(waitFontPop);
        //gameObject.SetActive(false);
        meshRenderer.enabled = false;
    }


}
