using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMaterial : MonoBehaviour
{
    int material=0;
    Renderer rend;

    // Update is called once per frame

    void Start() 
    {
        rend = GetComponent<Renderer>();
        rend.material.SetInt("_useColour",0);
        rend.material.SetInt("_useNormals",0);
    }

    void Update()
    {
        if (Input.touchCount==3)
        {
            if (Input.GetTouch(2).phase==TouchPhase.Began)
            {
                material++;
                if (material>3)
                {
                    material=0;
                }

                
                switch(material)
                {
                    case 0:
                        rend.material.SetInt("_useColour",0);
                        rend.material.SetInt("_useNormals",0);
                        break;

                    case 1:
                        rend.material.SetInt("_useColour",0);
                        rend.material.SetInt("_useNormals",1);
                        break;

                    case 2:
                        rend.material.SetInt("_useColour",1);
                        rend.material.SetInt("_useNormals",0);
                        break;
                    case 3:
                        rend.material.SetInt("_useColour",1);
                        rend.material.SetInt("_useNormals",1);
                        break;
                }
            }    
        }
    }
}
