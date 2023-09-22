using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;
    //Vector2 newCheckpointPosition = new Vector2(-19f, 0f);
    public TransformData playerPositionData;
    private TriggerEvent playerTriggerEvent;



    //audio
    public AudioSource audioDeath;
    public AudioClip deathClip;

    private int health;
    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
        healthFunc();
    }

    public void healthFunc()
    {
        health = 0;
    }

    //Untuk regis player di chckpoint
    public void OnCheckpoint(GameObject col)
    {
        Debug.Log("OnCheckpointKerja");
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
        CheckpointWallActive(col);

    }
    //On Cahaya
    public void CheckpointWallActive(GameObject wall)
    {
        //Debug.Log("name="+ wall.gameObject.transform.GetChild(0).gameObject.name);
        wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    //ketika player collide checkpoint
    public void OnTrap(GameObject col)
    {
        Debug.Log("OnTrapKerja");
        ChangePlayerPosition(currentCheckpointPosition);
    }

    //player di finish
    public void OnFinish()
    {
        Debug.Log("OnFinishDone");
        playerPositionData.ResetData();

    }
    //change position
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        audioDeath.PlayOneShot(deathClip);
        transform.position = newPosition;
        //if (health < 3)
        //{

        //    health++;
        //}
        //else if(health >= 1)
        //{
        //    SceneManager.LoadScene(0);
        //}

    }
    //load position dri scriptable object
    private void LoadPosition()
    {
        playerCurrentPosition = playerPositionData.position;
    }
    //save position di checkpoint (scriptabe object)
    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
}
