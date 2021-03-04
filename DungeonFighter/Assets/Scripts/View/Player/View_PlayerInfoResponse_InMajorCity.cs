/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，玩家主城信息相应
 * 
 * Description:
 *      具体作用：在主城场景中，关于玩家各种面板的显示与隐藏处理(任务系统、商城系统、技能系统、背包系统等)
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

namespace View
{
    public class View_PlayerInfoResponse_InMajorCity : MonoBehaviour
    {
        public GameObject goPlayerSkillPanel;
        public GameObject goPlayerMissionPanel;
        public GameObject goPlayerMarketPanel;
        public GameObject goPlayerPackagePanel;

        /// <summary>
        /// 显示英雄的角色
        /// </summary>
        public void DisplayPlayerRole()
        {
            View_PlayerInfoResponse.Instance.DisplayPlayerRole();
        }

        /// <summary>
        /// 隐藏英雄的角色
        /// </summary>
        public void HidePlayerRole()
        {
           View_PlayerInfoResponse.Instance.HidePlayerRole();
        }

        /// <summary>
        /// 显示英雄的技能信息
        /// </summary>
        public void DisplayPlayerSkillInfo()
        {
            //预处理
            if (goPlayerSkillPanel != null)
            {
                BeforeOpenWindow(goPlayerSkillPanel);
            }
            goPlayerSkillPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的技能信息
        /// </summary>
        public void HidePlayerSkillInfo()
        {
            if (goPlayerSkillPanel!=null)
            {
                BeforeCloseWindow();
            }
            goPlayerSkillPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的任务信息
        /// </summary>
        public void DisplayPlayerMission()
        {
            //预处理
            if (goPlayerSkillPanel != null)
            {
                BeforeOpenWindow(goPlayerMissionPanel);
            }
            goPlayerMissionPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的任务信息
        /// </summary>
        public void HidePlayerMission()
        {
            if (goPlayerSkillPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerMissionPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的商城系统
        /// </summary>
        public void DisplayPlayerMarket()
        {
            //预处理
            if (goPlayerSkillPanel != null)
            {
                BeforeOpenWindow(goPlayerMarketPanel);
            }
            goPlayerMarketPanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的商城系统
        /// </summary>
        public void HidePlayerMarket()
        {
            if (goPlayerSkillPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerMarketPanel.SetActive(false);
        }

        /// <summary>
        /// 显示英雄的背包系统
        /// </summary>
        public void DisplayPlayerPackage()
        {
            //预处理
            if (goPlayerSkillPanel != null)
            {
                BeforeOpenWindow(goPlayerPackagePanel);
            }
            goPlayerPackagePanel.SetActive(true);
        }

        /// <summary>
        /// 隐藏英雄的背包系统
        /// </summary>
        public void HidePlayerPackage()
        {
            if (goPlayerSkillPanel != null)
            {
                BeforeCloseWindow();
            }
            goPlayerPackagePanel.SetActive(false);
        }

        /// <summary>
        /// 打开窗体前的预处理
        /// </summary>
        /// <param name="_goNeedDisplayPanel"></param>
        private void BeforeOpenWindow(GameObject _goNeedDisplayPanel)
        {
            //禁用ET
            View_PlayerInfoResponse.Instance.HideET();
            //窗体的模态化处理
            this.gameObject.GetComponent<UIMaskManager>().SetMaskWindow(_goNeedDisplayPanel);            
        }

        /// <summary>
        /// 关闭窗体之前的预处理
        /// </summary>
        private void BeforeCloseWindow()
        {
            //开启ET
            View_PlayerInfoResponse.Instance.DisplayET();
            //取消窗体的模态化
            this.gameObject.GetComponent<UIMaskManager>().CancelMaskWindow();
        }
    }
}