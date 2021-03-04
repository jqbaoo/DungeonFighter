/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主城UI界面_任务系统的功能实现
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
    public class Ctrl_PanelMission : BaseControl
    {
        public static Ctrl_PanelMission Instance;

        void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// 副本：进入第二关卡
        /// </summary>
        public void EnterLevel2()
        {
            base.EnterNextScene(e_ScenesEnum.Level2);
        }
    }
}