/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，登陆场景
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
using UnityEngine.UI;
using Control;
using Global;

namespace View
{    
    public class View_LoginScene : MonoBehaviour
    {
        public GameObject goSwordHero;                          
        public GameObject goMagicHero;
        public GameObject goUISwordHeroInfo;
        public GameObject goUIMagicHeroInfo;

        public InputField input_UserName;

        void Awake()
        {

        }

        void Start()
        {
            //获取玩家的类型(系统默认)
            GlobalParaMgr.PlayerTypes = e_PlayerType.SwordHero;
            //用户名默认值
            input_UserName.text = "李逍遥";
        }

        /// <summary>
        /// 选择剑士
        /// </summary>
        public void ChangeToSwordHero()
        {
            //显示对象
            goSwordHero.SetActive(true);
            goMagicHero.SetActive(false);
            //显示UI
            goUISwordHeroInfo.SetActive(true);
            goUIMagicHeroInfo.SetActive(false);
            //获取玩家类型
            GlobalParaMgr.PlayerTypes = e_PlayerType.SwordHero;
            Ctrl_LoginScene.Instance.PlayAudioEffectBySword();
        }

        /// <summary>
        /// 选择魔法师
        /// </summary>
        public void ChangeToMagicHero()
        {
            //显示对象
            goSwordHero.SetActive(false);
            goMagicHero.SetActive(true);
            //显示UI
            goUISwordHeroInfo.SetActive(false);
            goUIMagicHeroInfo.SetActive(true);
            //获取玩家类型
            GlobalParaMgr.PlayerTypes = e_PlayerType.MagicHero;
            Ctrl_LoginScene.Instance.PlayAudioEffectByMagic();
        }
        /// <summary>
        /// 提交信息
        /// </summary>
        public void SubmitInfo()
        {
            //获取用户成名
            GlobalParaMgr.PlayerName = input_UserName.text;
            //跳转下一个场景
            Ctrl_LoginScene.Instance.EnterNextScene();
        }
    }
}