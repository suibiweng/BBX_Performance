using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Musician : MonoBehaviour
{
    public VisualEffect vfx;
    public Gradient ColorSet;

    public float Near,Far;
   
   
   public float BigR,SmallR;
    public float Radius;
    public float amt;



    public void TrustLevelToRadius(int trustLevel){
        float amt= trustLevel/5;

        Radius=Mathf.Lerp(BigR,SmallR,amt);




    }

    // Start is called before the first frame update
    void Start()
    {
        vfx=GetComponent<VisualEffect>();
        
    }

    // Update is called once per frame
    void Update()
    {
        VFXBind();
    }
  
    void VFXBind(){
      //  amt=GetComponent<BoxCollider>().size.z;

        vfx.SetFloat("PosZ",Mathf.Lerp(Far,Near,amt));
        vfx.SetGradient("Color",ColorSet);
        //vfx.SetFloat("Radius",Radius);



    }
}
