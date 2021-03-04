/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，背包系统_防御力道具
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
using UnityEngine.EventSystems;

namespace View
{
    public class DEF_PackItem : BasePackage, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        //定义"目标"格子名称
        public string strTargetGridName = "Img_DEF";
        //主角增加最大防御力
        public float floAddHeroMaxDEF = 20;

        void Start()
        {
            //赋值目标格子名称
            base.strMoveToTargetGridName = strTargetGridName;
            //运行父类的初始化
            base.RunInstanceByChildClass();
        }

        protected override void InvokeMethodByEndDrag()
        {
            Debug.Log(GetType() + "/InvokeMethodByEndDrag()");
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(floAddHeroMaxDEF);
            Model_PlayerKernalDataProxy.GetInstance().UpdateDEFValue();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            base.Base_OnBeginDrag(eventData);
        }
        public void OnDrag(PointerEventData eventData)
        {
            base.Base_OnDrag(eventData);
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            Base_OnEndDrag(eventData);
        }
    }
}