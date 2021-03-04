/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，背包系统父类
 * 
 * Description:
 *      具体作用：
 *      1、定义装备系统的公共操作，例如拖拽。。。
 *      2、必须给每一个道具添加同样的标签
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
using UnityEngine.EventSystems;

namespace View
{
    public class BasePackage : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        protected string strMoveToTargetGridName;                     //"目标格子"名称
        private CanvasGroup _canvasGroup;                             //用于贴图的穿透处理
        private Vector3 _originalPosition;                            //原始位置
        private Transform _myTransform;                               //本对象方位
        private RectTransform _myRectTransform;                         //二维方位

        /// <summary>
        /// 运行本类实例，通过子类调用
        /// </summary>
        protected void RunInstanceByChildClass()
        {
            Base_Start();
        }

        /// <summary>
        /// 父类实例化
        /// </summary>
        void Base_Start()
        {
            //获取贴图穿透组件
            _canvasGroup = GetComponent<CanvasGroup>();
            //转化成二维方位
            _myRectTransform = transform as RectTransform;
            //本帖图方位
            _myTransform = this.transform;
        }

        /// <summary>
        /// 拖拽前处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnBeginDrag(PointerEventData eventData)
        {
            //忽略自身(可以穿透)
            _canvasGroup.blocksRaycasts = false;
            //保证当前贴图可见。
            this.gameObject.transform.SetAsLastSibling();
            //获得原始方位
            _originalPosition = _myTransform.position;
        }

        /// <summary>
        /// 拖拽中处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnDrag(PointerEventData eventData)
        {
            Vector3 tmp_MousePos;                                                       //当前鼠标的位置
            //屏幕坐标，转二维矩阵坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_myRectTransform, eventData.position, eventData.pressEventCamera, out tmp_MousePos))
            {
                _myRectTransform.position = tmp_MousePos;
            }
        }

        /// <summary>
        /// 拖拽后处理
        /// </summary>
        /// <param name="eventData"></param>
        public void Base_OnEndDrag(PointerEventData eventData)
        {
            //当前鼠标经过的格子名称  tmp_cur当前鼠标被透下去的那个贴图     eventData.pointerEnter当前鼠标   
            GameObject tmp_cur = eventData.pointerEnter;
            if (tmp_cur != null)
            {
                //移动到符合条件的物品格子上
                if (tmp_cur.name.Equals(strMoveToTargetGridName))
                {
                    _myTransform.position = tmp_cur.transform.position;
                    _originalPosition = _myTransform.position;
                    //执行特定的装备方法
                    InvokeMethodByEndDrag();
                    
                    //阻止穿透，可以再次移动
                    _canvasGroup.blocksRaycasts = true;
                }
                //没有遇到目标点
                else
                {
                    //移动到背包系统的其他有效位置

                    //如果是同类背包道具，则交换位置
                    if ((tmp_cur.tag == eventData.pointerDrag.tag) && (tmp_cur.name != eventData.pointerDrag.name))
                    {
                        //"被覆盖贴图"位置与"当前贴图"位置的互换
                        Vector3 tmp_TargetPos = tmp_cur.transform.position;
                        tmp_cur.transform.position = _originalPosition;
                        _myTransform.position = tmp_TargetPos;
                        //重新确定新的"原始位置"
                        _originalPosition = _myTransform.position;
                    }
                    else   //拖拽到背包界面的其他对象上
                    {
                        _myTransform.position = _originalPosition;
                    }
                    //阻止穿透，可以再次移动
                    _canvasGroup.blocksRaycasts = true;
                }
            }
            else //拖拽到空区域
            {
                //返回
                _myTransform.position = _originalPosition;
            }
        }

        /// <summary>
        /// 执行特定的装备方法
        /// </summary>
        protected virtual void InvokeMethodByEndDrag()
        {
            Debug.Log(GetType() + "/InvokeMethodByEndDrag()");
        }
    }
}