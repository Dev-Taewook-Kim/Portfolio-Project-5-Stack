using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : BaseSceneManager<TitleSceneManager>
{
    [Header("[Shared Variables]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelGridWidthD1;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelGridWidthD2;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelGridHeightD1;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelGridHeightD2;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelStackCountD1;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt constantLevelStackCountD2;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantGridWidth;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantGridHeight;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt levelConstantStackCount;

    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private SharedVariableInt playerHeartsRemain;

    [Header("[Properties]")]
    [SerializeField] private Button[] buttonMenus;

    [SerializeField] private int menuIndex = 0;

    public void OnButtonNext()
    {
        buttonMenus[menuIndex].gameObject.SetActive(false);

        menuIndex = (int)Mathf.Repeat(++menuIndex, buttonMenus.Length);

        buttonMenus[menuIndex].gameObject.SetActive(true);

        Debug.Log("Next");

    }

    public void OnButtonPrev()
    {
        buttonMenus[menuIndex].gameObject.SetActive(false);

        menuIndex = (int)Mathf.Repeat(--menuIndex, buttonMenus.Length);

        buttonMenus[menuIndex].gameObject.SetActive(true);
    }

    public void OnButtonContinue() 
    {
        //To Do :: Feature :: Save/Load
    }
    
    public void OnButtonPlayerHearts() 
    {
        //To Do :: Feature :: Google Ads
        //Recharge through Watching Ads
    }

    public void OnButtonLevel3X3()
    {
        levelConstantGridWidth.Value = constantLevelGridWidthD1.Value;
        levelConstantGridHeight.Value = constantLevelGridHeightD1.Value;
        levelConstantStackCount.Value = constantLevelStackCountD1.Value;
    }

    public void OnButtonLevel6X6()
    {
        levelConstantGridWidth.Value = constantLevelGridWidthD2.Value;
        levelConstantGridHeight.Value = constantLevelGridHeightD2.Value;
        levelConstantStackCount.Value = constantLevelStackCountD2.Value;
    }

    public void ConsumePlayerHearts()
    {
        playerHeartsRemain.Value--;
    }
}
