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
    [SerializeField] Text income;
    [SerializeField] GameObject cauldron;
    [SerializeField] StoreUpgrade[] storeUpgrades;
    [SerializeField] MultiplierManagement[] multipliers;
    [SerializeField] int updatesPerSecond = 5;
    bool isRotated = false;
    public float countValue = 0;
    float nextTimeCheck = 1;
    float incomePerSecond = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        IncreaseAndDisplay();
    }

    void Update(){
        if (nextTimeCheck < Time.time) {
            IdleIncome();
            nextTimeCheck = Time.time + (1f/updatesPerSecond);
        }
    }

    void IdleIncome(){
        float income = 0;
        for (int i = 0; i < storeUpgrades.Length; i++){
            //income += (storeUpgrades[i].IncomePerSecond())*(multipliers[i].CummulativeMultiplier());
            //storeUpgrades.UpdateUI();
        }
        countValue += (income/updatesPerSecond);
        incomePerSecond = income;
    }

    // Funciton that is called on click of the cauldron, increases the counter and executes the animation
    public void IncreaseAndDisplay() {
        Increase();

        //initial pop of cauldron
        cauldron.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CauldronScaleBack);
        RotateCauldron();

        displayNumber();
    }

    //Function that verifies if you can pay the upgrade
    public bool PurchasePossible(int cost) {
        if (countValue >= cost) {
            countValue -= cost;
            displayNumber();
            return true;
        }
        return false;
    }

    
    //Function that pops back the cauldron
    void CauldronScaleBack() {
        cauldron.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    //Rotates the cauldron and back every other click, allowing a back and forth motion
    //Might eventually change it to do a rotation/position at random
    void RotateCauldron() {
        if (isRotated){
            cauldron.transform.DORotate(new Vector3(0, 0, -7), 0.01f);
            isRotated = false;
        } else {
            cauldron.transform.DORotate(new Vector3(0, 0, 7), 0.01f);
            isRotated = true;
        }
    }

    //increases count value according to current multiplier, called in the increaseAndDisplay() function
    void Increase() {
        //countValue += multipliers[0].CummulativeMultiplier();
    }

    //Changes the value of the counter in the UI. Called in Start() and increaseAndDisplay()
    void displayNumber() {
        //counter.text = Mathf.RoundToInt(countValue).ToString();
        //income.text = incomePerSecond.ToString() + "/s";
    }
}
