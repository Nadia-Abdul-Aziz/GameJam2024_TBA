using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

// DOTween is used for animations
// Find here: https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676?utm_source=google&utm_medium=cpc&utm_campaign=as_as_as_amer_amer-t1_en_pu_dsp-pmax_acq_pr_2024-04_x_cc3022_ev_id%3A71700000118169934&utm_content=_id%3A_SpringSalePMAX2023_&utm_term=&gad_source=1&gclid=Cj0KCQiAhbi8BhDIARIsAJLOludgf44w_xm8xK-l2qMft4sfviaWtLiJtn5KoMrw-IiMaguk35m385EaAjiQEALw_wcB&gclsrc=aw.ds

//This script allows for the basic click mechanics. It also handles the animations of the cauldron
public class GameManager : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] GameObject cauldron;
    bool isRotated = false;
    int countValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayNumber();
    }


    // Funciton that is called on click of the cauldron, increases the counter and executes the animation
    public void increaseAndDisplay()
    {
        increase();

        //initial pop of cauldron
        cauldron.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CauldronScaleBack);
        RotateCauldron();

        displayNumber();
    }

    //Function that pops back the cauldron
    void CauldronScaleBack(){
        cauldron.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    //Rotates the cauldron and back every other click, allowing a back and forth motion
    //Might eventually change it to do a rotation/position at random
    void RotateCauldron(){
        if (isRotated){
            cauldron.transform.DORotate(new Vector3(0, 0, -7), 0.01f);
            isRotated = false;
        } else {
            cauldron.transform.DORotate(new Vector3(0, 0, 7), 0.01f);
            isRotated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //increases count value, called in the increaseAndDisplay() function
    void increase()
    {
        countValue++;
    }

    //Changes the value of the counter in the UI. Called in Start() and increaseAndDisplay()
    void displayNumber()
    {
        counter.text = countValue.ToString();
    }
}
