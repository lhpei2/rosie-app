using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlRosie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetSphere;
    public GameObject imageTarget;
    public GameObject rosie;
    public GameObject ground;
    
    Collider coll;

    void Start()
    {
        coll=ground.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var ray=Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (coll.Raycast(ray,out hit,100f))
                {
                    var inst=Instantiate(targetSphere, hit.point, Quaternion.identity);
                    inst.transform.parent=imageTarget.transform;
                    rosie.GetComponent<movementRosie>().targetPosition=inst.transform.localPosition;
                    Destroy(inst);
                }
            }
        }*/
    }
}
