/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，玩家UI界面响应处理
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
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_PlayerUIResponse : MonoBehaviour
    {
        public static Ctrl_PlayerUIResponse Instance;

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void ExitGame()
        {
            StartCoroutine("HandleSavingGame");
        }

        IEnumerator HandleSavingGame()
        {
            SaveAndLoading.GetInstance().SaveGameProcess();
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            Application.Quit();
        }
    }
}