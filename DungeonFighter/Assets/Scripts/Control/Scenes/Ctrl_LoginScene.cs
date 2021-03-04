/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，登录场景
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
using Global;
using Kernal;

namespace Control
{
    public class Ctrl_LoginScene : BaseControl
    {
        public static Ctrl_LoginScene Instance;
        public AudioClip auc_BackgroundMusic;            //登陆场景的背景音乐
        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            //设置音量
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);
            //播放
            AudioManager.PlayBackground(auc_BackgroundMusic);
        }

        /// <summary>
        /// 播放剑士音效
        /// </summary>
        public void PlayAudioEffectBySword()
        {
            AudioManager.PlayAudioEffectA("SwordHero_MagicA");
        }

        /// <summary>
        /// 播放魔法师音效
        /// </summary>
        public void PlayAudioEffectByMagic()
        {
            AudioManager.PlayAudioEffectA("2_FireBallEffect_MagicHero");
        }
        /// <summary>
        /// 转到下一个场景
        /// </summary>
        public void EnterNextScene()
        {
            base.EnterNextScene(e_ScenesEnum.MajorCity);
        }
    }
}