using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class Manager : MonoBehaviour
{
 

    public Podium[] podiums;
    public Color[] ScaleColors;
    public float trustValue;
    float lastValue=-100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int ReturnColors(string color) {

        int index = 0;

        switch (color) {
            case "Red":
                index = 0;
                break;
            case "Green":
                index = 1;
                break;
            case "Blue":
                index = 2;
                break;
            case "Orange":
                index = 3;
                break;
            case "Yellow":
                index = 4;
                break;
            case "Purple":
                index = 5;
                break;
        }








        return index;


    }


    public void setPodiumColor(int id,string color) {
        if (!podiums[id].isLocked) {
            podiums[id].isLocked = true;

            podiums[id].setColor = ScaleColors[ReturnColors(color)];
        }

    }

    public void ResetSystem() {
        foreach (var p in podiums) {
            p.isLocked = false;
        }

    }


    public void setTrust() {






    }

    public void updateTrustValue(float v) {


        if(lastValue != v){
            trustValue = lastValue-v;
lastValue=v;


        }
      //  trustValue = v;



    }



}
