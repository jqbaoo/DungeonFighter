/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，背包系统_敏捷道具
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

namespace View{
public class DEX_PackItem : BasePackage, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        //定义"目标"格子名称
        public string strTargetGridName = "Img_DEX";
        //主角增加最大防御力
        public float floAddHeroMaxDEX = 10;

        void Start()
        {
            //赋值目标格子名称
            base.strMoveToTargetGridName = strTargetGridName;
            //运行父类的初始化
            base.RunInstanceByChildClass();
        }

        protected override void InvokeMethodByEndDrag()
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEX(floAddHeroMaxDEX);
            Model_PlayerKernalDataProxy.GetInstance().UpdateDEXValue();
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