using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float newPosX;

    [SerializeField]
    private float posXTrigger;

    [SerializeField]
    private Transform Continue;

    bool isStuck = false;

    private void FixedUpdate()
    {
        positionUpdate();
        checkPos();
    }

    private void checkPos()
    {
        if(transform.position.x >= posXTrigger && !isStuck)
        {
            isStuck = true;
            newPos();
            isStuck = false;
        }
    }

    public void newPos()
    {
        transform.position = new Vector3 (Continue.position.x+newPosX,transform.position.y,transform.position.z);

    }

    void positionUpdate()
    {
        var movement = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
    }


}
