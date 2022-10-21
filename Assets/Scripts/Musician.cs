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


    public float DB;
    public float upperDB, lowerDB;
    public float DBamt;

    public bool MusicBegin;


    float Remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
    {
        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }

    public void TrustLevelToRadius(int trustLevel){

        float amt= trustLevel/5;

        if (!MusicBegin)
            Radius = Mathf.Lerp(SmallR, BigR, amt);

        else
        Radius = 4.25f;



    }

    // Start is called before the first frame update
    void Start()
    {
        vfx=GetComponent<VisualEffect>();
        
    }

    // Update is called once per frame
    void Update()
    {

        DBamt= Remap(DB, lowerDB, upperDB, 0f, 1f);

        VFXBind();
    }

    public void hit(float db) {
        DB = db;


    }
  
    void VFXBind(){
      //  amt=GetComponent<BoxCollider>().size.z;

        vfx.SetFloat("PosZ",Mathf.Lerp(Far,Near,DBamt));
        vfx.SetGradient("Color",ColorSet);
        vfx.SetFloat("Radius",Radius);



    }
}
