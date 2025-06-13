using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DeployInfo
{
    /// <summary>
    /// �h������Ԋu
    /// </summary>
    public float deployDelay;

    /// <summary>
    /// �h������Ԋu�͈̔�
    /// </summary>
    public float deployDelayRange;

    /// <summary>
    /// �h������J�E���^�[
    /// </summary>
    [HideInInspector]
    public float deployCount;

    /// <summary>
    /// ���ɔh������^�C�~���O
    /// </summary>
    [HideInInspector]
    public float deployTime;
}
