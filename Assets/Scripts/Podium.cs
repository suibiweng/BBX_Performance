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
    public float amt;

    public int ID;


    public Animator animator;

    public Color setColor;
    // Start is called before the first frame update
    void Start()
    {
        Vfx=GetComponentInChildren<VisualEffect>();

    }

    // Update is called once per frame
    void Update()
    {
            VFXBind();
    }

    public void setOnoff(bool on) {

        if (on) {
            ison = true;
            SendBackUdp.broadcastTo("Podium:"+ID+",on");


        } else {
            ison = false;
             SendBackUdp.broadcastTo("Podium:"+ID+",off");

        }


    }

    public void hit(){



    }

    void VFXBind(){
        amt=GetComponent<BoxCollider>().size.z;

        Vfx.SetFloat("PosZ",Mathf.Lerp(Far,Near,amt));
        Vfx.SetVector4("PodColor",setColor);



    }


    









}
