/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 核心层，通用触发脚本
 * 
 * Description:
 *      具体作用：
 *      1、NPC/敌人 触发对话
 *      2、游戏进行到一定进度触发存盘功能
 *      3、加载与启用特定脚本(例如：产生敌人)
 *      4、触发"对话/确认框"等
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kernal
{
    /// <summary>
    /// 委托，通用触发
    /// </summary>
    /// <param name="_CTT"></param>
    public delegate void del_CommonTrigger(e_CommonTriggerType _CTT);
    public class TriggerCommonEvent : MonoBehaviour
    {
        //定义事件
        public static event del_CommonTrigger event_CommonTrigger;
        //对话类型
        public e_CommonTriggerType triggerType = e_CommonTriggerType.None;
        public string tagNameByHero = "Player";

        /// <summary>
        /// 触发进入检测
        /// </summary>
        /// <param name="_coll"></param>
        void OnTriggerEnter(Collider _coll)
        {
            if (_coll.gameObject.tag == tagNameByHero)
            {
                if (event_CommonTrigger != null)
                {
                    event_CommonTrigger(triggerType);
                }
            }
        }
    }
    public enum e_CommonTriggerType
    {
        None,
        NPC1_Dialog,                                                        //NPC1对话
        NPC2_Dialog,
        NPC3_Dialog,
        NPC4_Dialog,
        NPC5_Dialog,
        Enemy1_Dialog,                                                      //敌人对话
        Enemy2_Dialog,
        Enemy3_Dialog,
        Enemy4_Dialog,
        Enemy5_Dialog,
        SaveDataOrScene,                                                    //存盘
        LoadDataOrScene,                                                    //加载存档
        EnableScript1,                                                      //加载或启动特定脚本
        EnableScript2,      
        ActiveConfimWindows,                                                //触发确认窗体
        ActiveDialogWindows,                                                //触发对话窗体
        EnterLevel1,                                                        //进入场景
        EnterLevel2,
    }
}