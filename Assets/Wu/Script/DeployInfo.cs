using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DeployInfo
{
    /// <summary>
    /// ”hŒ­‚·‚éŠÔŠu
    /// </summary>
    public float deployDelay;

    /// <summary>
    /// ”hŒ­‚·‚éŠÔŠu‚Ì”ÍˆÍ
    /// </summary>
    public float deployDelayRange;

    /// <summary>
    /// ”hŒ­‚·‚éƒJƒEƒ“ƒ^[
    /// </summary>
    [HideInInspector]
    public float deployCount;

    /// <summary>
    /// Ÿ‚É”hŒ­‚·‚éƒ^ƒCƒ~ƒ“ƒO
    /// </summary>
    [HideInInspector]
    public float deployTime;
}
