using System.Collections;
using System.Collections.Generic;
using Teamp2.Library.Framework.DataType;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MainSceneManager : BaseSceneManager<MainSceneManager>
{
    private void Start() => LoadSceneByIndexAdditive(1);
}
