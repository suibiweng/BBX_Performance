using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Podium : MonoBehaviour
{


    public UDPBroacast SendBackUdp;

    public VisualEffect Vfx;

    public bool isLocked;
    public bool ison;


    public float Far, Near;

    public float DB;
    public float upperDB, lowerDB;
    public float amt;

    public int ID;


    public Animator animator;

    public Color setColor;
    // Start is called before the first frame update
    void Start()
    {
        Vfx=GetComponentInChildren<VisualEffect>();

        SendBackUdp=FindObjectOfType<UDPBroacast>();

    }


    float Remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
    {
        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }

    // Update is called once per frame
    void Update()
    {
            VFXBind();


        amt = Remap(DB, lowerDB, upperDB, 0f, 1f);
            
        if(Input.GetKeyDown(KeyCode.Space)){

 //SendBackUdp.broadcastTo("Podium:"+ID+",on");



        }
            
    }

    public void setOnoff(bool on) {

        if (on) {
            ison = true;
            //SendBackUdp.broadcastTo("Podium:"+ID+",on");
            Vfx.Play();

        } else {
            ison = false;
            //      SendBackUdp.broadcastTo("Podium:"+ID+",off");
            Vfx.Stop();
        }


    }

    public void hit(float db){
        DB = db;


    }

    void VFXBind(){
       // amt=GetComponent<BoxCollider>().size.z;

        Vfx.SetFloat("PosZ",Mathf.Lerp(Far,Near,amt));
        Vfx.SetVector4("PodColor",setColor);



    }


    









}
