/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，第一关卡场景
 * 
 * Description:
 *      具体作用：第一关卡的场景的界面控制
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
    public class View_Level1Scene : MonoBehaviour
    {
        public GameObject goUINormalATK;                                        //普通攻击
        public GameObject goUIMagicA;                                           //技能A
        public GameObject goUIMagicB;                                           //技能B
        public GameObject goUIMagicC;                                           //技能C
        public GameObject goUIMagicD;                                           //技能D
        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);
            
            goUIMagicA.GetComponent<View_ATKBtnCDEffet>().EnableSelf();
            goUIMagicB.GetComponent<View_ATKBtnCDEffet>().EnableSelf();
            goUIMagicC.GetComponent<View_ATKBtnCDEffet>().DisableSelf();
            goUIMagicD.GetComponent<View_ATKBtnCDEffet>().DisableSelf();
        }
    }
}