using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Podium : MonoBehaviour
{
    public VisualEffect Vfx;

    public bool isLocked;
    public bool ison;


    public float First, Second;
    public float amt;


    public Animator animator;

    public Color setColor;
    // Start is called before the first frame update
    void Start()
    {
       /* string s;

        string s1 = "1.6";
        string s2 = "1.6";
        s = s1 + "," + s2;
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setOnoff(bool on) {

        if (on) {
            ison = true;


        } else {
            ison = false;

        }


    }


    









}
