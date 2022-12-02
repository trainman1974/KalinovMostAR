using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoosterMovie : MonoBehaviour
{
 public float speed ;
 private Vector3 StartPosition;
 private Vector3 FinishPosition;

   void Start()
   {
        StartPosition = gameObject.transform.position;
        FinishPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z );

        //Debug.Log("StartPosition " + StartPosition);
        //Debug.Log("FinishPosition " + FinishPosition);
     
    }
    
    private void FixedUpdate()
    {    
        MovieFly();
    }    

    void MovieFly()
    {
        if(gameObject.transform.position != FinishPosition)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, FinishPosition, speed * Time.deltaTime);

            //Debug.Log("gameObject.transform.position " + gameObject.transform.position);
            //Debug.Log("FinishPosition " + FinishPosition);
        }
        else if (gameObject.transform.position == FinishPosition)
        {
            //StartPosition = FinishPosition;
            FinishPosition = new Vector3(StartPosition.x + Random.Range(-0.05f, 0.15f), StartPosition.y, StartPosition.z + Random.Range(0.05f, -0.02f) );
            
        }

    }
}
