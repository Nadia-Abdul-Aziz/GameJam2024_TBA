using System.Collections;
using System.Collections.Generic;
using TMPro;
//using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

// DOTween is used for animations
// Find here: https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676?utm_source=google&utm_medium=cpc&utm_campaign=as_as_as_amer_amer-t1_en_pu_dsp-pmax_acq_pr_2024-04_x_cc3022_ev_id%3A71700000118169934&utm_content=_id%3A_SpringSalePMAX2023_&utm_term=&gad_source=1&gclid=Cj0KCQiAhbi8BhDIARIsAJLOludgf44w_xm8xK-l2qMft4sfviaWtLiJtn5KoMrw-IiMaguk35m385EaAjiQEALw_wcB&gclsrc=aw.ds
public class GameManager : MonoBehaviour
{
    [SerializeField] Text counter;
    int countValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayNumber();

    }

    public void increaseAndDisplay()
    {

        increase();
        displayNumber();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void increase()
    {
        countValue++;
    }

    void displayNumber()
    {
        counter.text = countValue.ToString();
    }
}
