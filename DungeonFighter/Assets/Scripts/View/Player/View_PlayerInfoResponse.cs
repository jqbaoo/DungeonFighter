/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，相应玩家信息
 * 
 * Description:
 *      具体作用：
 *      1、专门相应玩家"点击"处理
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;
using Global;


namespace View
{
    public class View_PlayerInfoResponse : MonoBehaviour
    {
        public static View_PlayerInfoResponse Instance;
        public GameObject goPlayerDetailInfoPanel;                                      //玩家详细信息面板
        public GameObject goET;                                                         //EastTouch摇杆
        public GameObject goHeroInfo;                                                   //英雄UI信息
        //攻击虚拟按键
        public GameObject goNormalATK;                                                  //普攻
        public GameObject goMagicA;                                                     //技能A
        public GameObject goMagicB;                                                     //技能B
        public GameObject goMagicC;                                                     //技能C
        public GameObject goMagicD;                                                     //技能D
        public GameObject goAddHp;                                                      //加血


        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            DisplayET();
        }

        /// <summary>
        /// 显示与隐藏"玩家详细信息面板"
        /// </summary>
        //public void DisplayerOrHidePlayerDetailInfoPanel()
        //{
        //    goPlayerDetailInfoPanel.SetActive(!goPlayerDetailInfoPanel.activeSelf);
        //}

        public void DisplayPlayerRole()
        {
            if (goPlayerDetailInfoPanel != null)
            {
                BeforeOpenWindow(goPlayerDetailInfoPanel);
            }
            goPlayerDetailInfoPanel.SetActive(true);
        }


        public void HidePlayerRole()
        {
            if (goPlayerDetailInfoPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerDetailInfoPanel.SetActive(false);
        }

        /// <summary>
        /// 显示ET
        /// </summary>
        public void DisplayET()
        {
            goET.SetActive(true);
        }
        /// <summary>
        /// 隐藏ET
        /// </summary>
        public void HideET()
        {
            goET.SetActive(false);
        }

        /// <summary>
        /// 显示所有UI按键
        /// </summary>
        public void DisplayAllUIKey()
        {
            goNormalATK.SetActive(true);
            goMagicA.SetActive(true);
            goMagicB.SetActive(true);
            goMagicC.SetActive(true);
            goMagicD.SetActive(true);
            goAddHp.SetActive(true);
        }

        /// <summary>
        /// 隐藏所有UI按键
        /// </summary>
        public void HideAllUIKey()
        {
            goNormalATK.SetActive(false);
            goMagicA.SetActive(false);
            goMagicB.SetActive(false);
            goMagicC.SetActive(false);
            goMagicD.SetActive(false);
            goAddHp.SetActive(false);
        }

        /// <summary>
        /// 显示主要攻击按键
        /// </summary>
        public void DisplayMainATK()
        {
            goNormalATK.SetActive(true);
            goMagicA.SetActive(false);
            goMagicB.SetActive(false);
            goMagicC.SetActive(false);
            goMagicD.SetActive(false);
            goAddHp.SetActive(false);
        }

        /// <summary>
        /// 显示英雄UI信息
        /// </summary>
        public void DisplayHeroUIInfo()
        {
            goHeroInfo.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄UI信息
        /// </summary>
        public void HideHeroUIInfo()
        {
            goHeroInfo.SetActive(false);
        }

        /// <summary>
        /// 退出游戏系统
        /// </summary>
        public void ExitGame()
        {
            //Application.Quit();
            Ctrl_PlayerUIResponse.Instance.ExitGame();
        }

        /// <summary>
        /// 打开窗体前的预处理
        /// </summary>
        /// <param name="_goNeedDisplayPanel"></param>
        private void BeforeOpenWindow(GameObject _goNeedDisplayPanel)
        {
            //禁用ET
            HideET();
            //窗体的模态化处理
            this.gameObject.GetComponent<UIMaskManager>().SetMaskWindow(_goNeedDisplayPanel);
        }

        /// <summary>
        /// 关闭窗体之前的预处理
        /// </summary>
        private void BeforeCloseWindow()
        {
            //开启ET
            DisplayET();
            //取消窗体的模态化
            this.gameObject.GetComponent<UIMaskManager>().CancelMaskWindow();
        }

        #if UNITY_ANDROID || UNITY_IPHONE

        #region 响应虚拟按键点击
        //public void ResponseNormalATK()
        //{
        //    Ctrl_HeroAttackInputByET.Instance.ResponseATKByNormal();
        //}
        public void ResponseATKByMagicA()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicA();
        }

        public void ResponseATKByMagicB()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicB();
        }

        public void ResponseATKByMagicC()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicC();
        }

        public void ResponseATKByMagicD()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicD();
        }
        #endregion

        #endif
    }
}