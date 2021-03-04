/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角攻击输入(通过EasyTouch插件）
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
using Model;

namespace Control
{
    public class Ctrl_HeroAttackInputByET : BaseControl
    {
#if UNITY_ANDROID || UNITY_IPHONE
        public static Ctrl_HeroAttackInputByET Instance;
        public static event del_PlayerControlWithStr event_PlayerControl;

        void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// 响应普攻
        /// </summary>
        public void ResponseATKByNormal()
        {
            if (event_PlayerControl != null)
            {
                event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            }
        }
        /// <summary>
        /// 响应技能A
        /// </summary>
        public void ResponseATKByMagicA()
        {
            if (event_PlayerControl != null)
            {
                event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKA);
            }
        }
        /// <summary>
        /// 响应技能B
        /// </summary>
        public void ResponseATKByMagicB()
        {
            if (event_PlayerControl != null)
            {
                event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKB);
            }
        }
        /// <summary>
        /// 响应技能C
        /// </summary>
        public void ResponseATKByMagicC()
        {
            if (event_PlayerControl != null)
            {
                event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKC);
            }
        }
        /// <summary>
        /// 响应技能D
        /// </summary>
        public void ResponseATKByMagicD()
        {
            if (event_PlayerControl != null)
            {
                event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKD);
            }
        }
#endif
    }
}