using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Dis : MonoBehaviour
{
    public List<GameObject> myList;
    public float FightDistance;

    private bool FightAnimation;
    private Animator animator;

    // Start is called before the first frame update
    void Start() 
    {
        for (int i = 0; i < myList.Count; i++)
        {
            myList[i].SetActive(false);
        }
    }
        

    void Update()
    {
        DistanceVerification(FightDistance);
        //Debug.Log(myList[0].activeInHierarchy);
    }

    private void DistanceVerification(float FightDistance)
    {
        for (int i = 0; i < myList.Count; i++)
        {
            FightAnimation = false;
            for (int j = 0; j < myList.Count; j++)
            {
                if (i != j)
                {
                    if (myList[i].activeInHierarchy && myList[j].activeInHierarchy)
                    {
                        if (Vector3.Distance(PositionTrackingMarker(myList[i].name), PositionTrackingMarker(myList[j].name)) < FightDistance)
                        {
                            FightAnimation = true;
                        }
                    }
                }
            }
            if(FightAnimation)
            {
                SetAnimation(myList[i], "Fight", true);
            }
            else
            {
                SetAnimation(myList[i], "Fight", false);
            }
        }
            
    }

    private Vector3 PositionTrackingMarker(string imageTargetName)
    {
        var imageTarget = GameObject.Find(imageTargetName);
       // Debug.Log(imageTarget.transform.position + imageTargetName);
        return imageTarget.transform.position;
    }

    private void SetAnimation(GameObject objectx, string name, bool ct)
    {
        //Debug.Log(objectx.name+' '+ct);
        animator = objectx.GetComponent<Animator>();
        animator.SetBool(name, ct);
    }
}