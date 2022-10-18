using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class Manager : MonoBehaviour
{
 

    public Podium[] podiums;

    public Musician musician;
    public Color[] ScaleColors;
    public float trustValue;
    double lastValue=-100f;



    public Gradient Musiciangradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;



    public int TrustIndex=0;

    // Start is called before the first frame update
    void Start()
    {

        Musiciangradient=new Gradient();
        colorKey = new GradientColorKey[6];
        alphaKey = new GradientAlphaKey[2];

    }

    // Update is called once per frame
    void Update()
    {


musicianUpdate();


        
    }

    void musicianUpdate(){
        musician.TrustLevelToRadius(TrustIndex);
        float keytime=1/6;
        
        
        colorKey[0].color=podiums[0].setColor;
        colorKey[0].time= 0;
       
        colorKey[1].color=podiums[1].setColor;
        colorKey[1].time= 1.0f/6.0f;
       
        colorKey[2].color=podiums[2].setColor;
        colorKey[2].time= 2.0f/6.0f;

        colorKey[3].color=podiums[3].setColor;
        colorKey[3].time= 3.0f/6.0f;

        colorKey[4].color=podiums[4].setColor;
        colorKey[4].time= 4.0f/6.0f;

        colorKey[5].color=podiums[5].setColor;
        colorKey[5].time= 5.0f/6.0f;
        
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        Musiciangradient.SetKeys(colorKey,alphaKey);
        musician.ColorSet=Musiciangradient;

    }



  public  void TurnONthePodium(){
        for(int i=0 ; i<podiums.Length; i++){
            
            if(i<=TrustIndex){
                podiums[i].setOnoff(true);
            }else{

                podiums[i].setOnoff(false);
            }
            
        }


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

    public void updateTrustValue(double v) {



        //  trustValue = lastValue-v;

        if (v != lastValue) {

       

            if (v < lastValue) {

                TrustIndex--;
               
            }

            if (v > lastValue) {



                TrustIndex++;

            }

            lastValue = v;


        }
     



        

    if(TrustIndex>6){

        TrustIndex=6;
    }
    if(TrustIndex<0){
        TrustIndex=0;

    }



      //  trustValue = v;



    }



}
