using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int SceneInt;
    [SerializeField]
    private int SceneSaveInt;

    private int warpSounded;
    public float warpTimer;
    public AudioSource audioWarp;
    public AudioClip warpClip;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log(gameObject.tag + " KenaFinish! " + col.gameObject.tag);

            StartCoroutine(warpNext());
            if(warpSounded == 0)
        {
            audioWarp.PlayOneShot(warpClip);
            warpSounded = 1;
        }

        }
    }
     private IEnumerator warpNext()
     {
        yield return new WaitForSeconds(warpTimer);
        GameManager.Instance.ChangeScene(SceneInt);
        GameManager.Instance.ChangeLevel(SceneSaveInt);



     }

}
