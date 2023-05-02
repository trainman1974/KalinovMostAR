using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoosterMovieBase : MonoBehaviour
{
 public GameObject Rooster;
 public float speed ;
private Vector3 _StartPosition;
 public Transform FinishPosition;
 private Vector3 _FinishPosition;  
 private int Count = 0;
 private Vector3 _FinalPosition; 
 private Vector3 StartPosition;
 private Vector3 StartScale ;
 private Vector3 NormalScale;

   void Start()
   {
        float ScaleOfsset = 0.8f;

        StartPosition = gameObject.transform.position;
        NormalScale = new Vector3(ScaleOfsset, ScaleOfsset, ScaleOfsset);


        float ScaleStartOfsset = 0.01f;
        StartScale = new Vector3(ScaleStartOfsset, ScaleStartOfsset, ScaleStartOfsset);

        gameObject.transform.localScale = StartScale;
        

        Instantiate(Rooster, gameObject.transform);
        //this.transform.Find("RoosterSkeletonAnimation(Clone)").gameObject.tag = "Roostyer";
        
        _FinishPosition = new Vector3 (FinishPosition.position.x, FinishPosition.transform.position.y, FinishPosition.transform.position.z );

        //Debug.Log("StartPosition " + StartPosition);
        //Debug.Log("FinishPosition " + FinishPosition);
     
    }
    
    
    private void FixedUpdate()
    {    
        MovieStart();
    }


    void MovieStart()
    {
        if(gameObject.transform.position != _FinishPosition && Count < 20)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _FinishPosition, speed * Time.deltaTime);

            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, NormalScale, speed * Time.deltaTime);

            //Debug.Log("gameObject.transform.position " + gameObject.transform.position);
            //Debug.Log("FinishPosition " + FinishPosition);
            
        }
        
        else if (gameObject.transform.position == _FinishPosition && Count < 20)
        {
            //StartPosition = FinishPosition;
            _FinishPosition = new Vector3(FinishPosition.position.x + Random.Range(-0.05f, 0.15f), FinishPosition.position.y, FinishPosition.position.z + Random.Range(0.05f, -0.02f) );
            //Debug.Log(" TEST!!!!!!!!!!!!!!!!!!!!!! ");
            Count = Count + 1; 
            Debug.Log("Count "+ Count);
        }
        else if (Count >= 20)
        {
            float offset = 0.8f;

            _FinalPosition = new Vector3 (FinishPosition.position.x - offset, FinishPosition.transform.position.y, FinishPosition.transform.position.z );
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _FinalPosition, (speed*2) * Time.deltaTime);

            if (gameObject.transform.position.x <= _FinalPosition.x)
            {
                Debug.Log("Destroy!!!!!!!!!!!!!!!!!!!!! ");
                var _Rooster = this.transform.Find("RoosterSkeletonAnimation(Clone)").gameObject;

                Destroy(_Rooster);
                gameObject.transform.position = StartPosition;
                gameObject.transform.localScale = StartScale;
                Instantiate(Rooster, gameObject.transform);
                //this.transform.Find("RoosterSkeletonAnimation(Clone)").gameObject.tag = "Roostyer";
                Count = 0;
            }            
        }

    }    
}
