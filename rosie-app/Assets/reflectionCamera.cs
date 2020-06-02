using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectionCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        transform.eulerAngles=new Vector3(0,0,180);
        Vector3 pos=transform.parent.transform.position;
        pos.y=0.7f-(pos.y-0.7f);
        transform.position=pos;
        //Vector3 localPos=transform.localPosition;
        //localPos.y=-pos.y;
        //transform.localPosition=localPos;
    }
}
