/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角攻击输入(通过键盘输入)
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
    public class Ctrl_HeroAttackInputByKey : BaseControl
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        //事件：主角控制
        public static event del_PlayerControlWithStr event_PlayerControl;
        void Update()
        {
            if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
            {
                print("NormalAttack");
                if (event_PlayerControl != null)
                {
                    event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
                }
            }
            else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKA))
            {
                print("MagicTrickA");
                if (event_PlayerControl != null)
                {
                    event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKA);
                }
            }
            else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKB))
            {
                print("MagicTrickB");
                if (event_PlayerControl != null)
                {
                    event_PlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKB);
                }
            }
        }//update end

#endif
    }
}