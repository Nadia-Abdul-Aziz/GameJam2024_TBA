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
    [SerializeField] BubbleAnimation[] bubbles;
    [SerializeField] int updatesPerSecond = 10;
    bool isRotated = false;
    public float countValue = 0;
    float nextTimeCheck = 1;
    // commented for now
    // float mermanTimeCheck = 2;
    public float incomePerSecond = 0;
    //int previousBubblePop = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayNumber();
    }

    void Update()
    {
        if (nextTimeCheck < Time.time)
        {
            IdleIncome();
            nextTimeCheck = Time.time + (1f / updatesPerSecond);
            for (int i = 0; i < 6; i++)
            {
                storeUpgrades[i].UpdateIngredientUI();
            }
            for (int i = 0; i < 4; i++)
            {
                multipliers[i].UpdateMultiplierUI();
            }
        }
    }

    void IdleIncome()
    {
        float income = 0;
        for (int i = 0; i < 6; i++)
        {
            income += (storeUpgrades[i].IncomePerSecond()) * (multipliers[i].CummulativeMultiplier());
        }
        income += storeUpgrades[6].IncomePerSecond();
        income += storeUpgrades[7].IncomePerSecond();
        countValue += (income / updatesPerSecond);
        incomePerSecond = income;
        displayNumber();
    }

    // Funciton that is called on click of the cauldron, increases the counter and executes the animation
    public void IncreaseAndDisplay()
    {
        Increase();

        //initial pop of cauldron
        cauldron.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CauldronScaleBack);
        RotateCauldron();

        //Bubble pop
        //randomBubblePop(previousBubblePop);
        //bubbles[previousBubblePop].AnimationPlay();

        displayNumber();
    }

    //Function that pops back the cauldron
    void CauldronScaleBack()
    {
        cauldron.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    //Function that verifies if you can pay the upgrade
    public bool PurchasePossible(int cost)
    {
        if (countValue >= cost)
        {
            countValue -= cost;
            displayNumber();
            return true;
        }
        return false;
    }

    //Rotates the cauldron and back every other click, allowing a back and forth motion
    //Might eventually change it to do a rotation/position at random
    void RotateCauldron()
    {
        if (isRotated)
        {
            cauldron.transform.DORotate(new Vector3(0, 0, -7), 0.01f);
            isRotated = false;
        }
        else
        {
            cauldron.transform.DORotate(new Vector3(0, 0, 7), 0.01f);
            isRotated = true;
        }
    }

    //increases count value according to current multiplier, called in the increaseAndDisplay() function
    void Increase()
    {
        countValue += multipliers[0].CummulativeMultiplier();
    }

    //Changes the value of the counter in the UI. Called in Start() and increaseAndDisplay()
    void displayNumber()
    {
        counter.text = Mathf.RoundToInt(countValue).ToString();
        income.text = incomePerSecond.ToString() + "/s";
    }

    //function to randomly decide which bubble pops
    /*
    void randomBubblePop(int previous){
        Random bubbleNumber = new Random();
        float newFloat = bubbleNumber.Range(0,bubbles.Length);
        int newInt = Mathf.RoundToInt(newFloat);
        while (newInt == previousBubblePop){
            newInt = bubbleNumber.Range(0,bubbles.Length);
        }

        previousBubblePop = newInt;
    }
    */
}
