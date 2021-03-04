/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 核心层，事件触发监听器
 * 
 * Description:
 *      具体作用：可以监听任何一个指定的游戏对象
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Kernal
{
    public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger
    {
        public delegate void VoidDelegate(GameObject _go);
        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onUp;
        public VoidDelegate onSelect;
        public VoidDelegate onUpdateSelect;

        /// <summary>
        /// 得到监听器组件
        /// </summary>
        /// <param name="_go">监听的游戏对象</param>
        /// <returns>返回监听器</returns>
        public static EventTriggerListener Get(GameObject _go)
        {
            EventTriggerListener tmp_Lister = _go.GetComponent<EventTriggerListener>();
            if (tmp_Lister == null)
            {
                tmp_Lister = _go.AddComponent<EventTriggerListener>();
            }
            return tmp_Lister;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (onClick != null)
            {
                onClick(gameObject);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (onDown != null)
            {
                onDown(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
            {
                onEnter(gameObject);
            }
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            if (onExit != null)
            {
                onExit(gameObject);
            }
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (onUp != null)
            {
                onUp(gameObject);
            }
        }
        public override void OnSelect(BaseEventData eventData)
        {
            if (onSelect != null)
            {
                onSelect(gameObject);
            }
        }
        public override void OnUpdateSelected(BaseEventData eventData)
        {
            if (onUpdateSelect != null)
            {
                onUpdateSelect(gameObject);
            }
        }
    }//class end
}
