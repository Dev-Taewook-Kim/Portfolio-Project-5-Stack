using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Teamp2.Library.Framework.DataType;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class PlaySceneManager : BaseSceneManager<PlaySceneManager>
{
    public void OnButtonPause(GameObject preventer)
    {
        if (preventer.activeSelf)
            preventer.SetActive(false);
        else
            preventer.SetActive(true);
    }

    public void OnButtonAdvertisement() 
    {
        //To Do :: Feature :: Google Ads
        //Recharge through Watching Ads
    }
}