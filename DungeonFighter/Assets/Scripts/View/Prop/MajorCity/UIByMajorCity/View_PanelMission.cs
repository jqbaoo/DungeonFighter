/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，主城UI界面_任务系统
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
using Control;

namespace View
{
    public class View_PanelMission : MonoBehaviour
    {
        /// <summary>
        /// 任务1：进入第二关卡
        /// </summary>
        public void EnterNextLevel2()
        {
            //调用控制层
            Ctrl_PanelMission.Instance.EnterLevel2();
        }

    }
}