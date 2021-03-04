/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，英雄展示
 * 
 * Description:
 *      具体作用：
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_DisplayHero : MonoBehaviour
{
    public AnimationClip anim_Idle;
    public AnimationClip anim_Run;
    public AnimationClip anim_Attack;

    private Animation _anim_CurrentAnimation;

    private float _floIntervalTime = 3f;                        //间隔时间切换动作
    private int _intRandomPlayNum;                                 //随机动作编号
	void Start () 
	{
        _anim_CurrentAnimation = GetComponent<Animation>();
	}
    void Update()
    {
        _floIntervalTime -= Time.deltaTime;
        if (_floIntervalTime <= 0)
        {
            _floIntervalTime = 3f;
            _intRandomPlayNum = Random.Range(1, 4);
            DisplayHeroPlaying(_intRandomPlayNum);
        }
    }
    /// <summary>
    /// 展示动作
    /// </summary>
    /// <param name="_intPlayingNum"></param>
    internal void DisplayHeroPlaying(int _intPlayingNum)
    {
        switch (_intRandomPlayNum)
        {
            case 1:
                DisplayIdle();
                break;
            case 2:
                DisplayRun();
                break;
            case 3:
                DisplayAttack();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 展示休闲动作
    /// </summary>
    internal void DisplayIdle()
    {
        if (_anim_CurrentAnimation)
        {
            _anim_CurrentAnimation.CrossFade(anim_Idle.name);
        }
    }
    /// <summary>
    /// 展示跑步动作
    /// </summary>
    internal void DisplayRun()
    {
        if (_anim_CurrentAnimation)
        {
            _anim_CurrentAnimation.CrossFade(anim_Run.name);
        }
    }
    /// <summary>
    /// 展示攻击动作
    /// </summary>
    internal void DisplayAttack()
    {
        if (_anim_CurrentAnimation)
        {
            _anim_CurrentAnimation.CrossFade(anim_Attack.name);
        }
    }
}
