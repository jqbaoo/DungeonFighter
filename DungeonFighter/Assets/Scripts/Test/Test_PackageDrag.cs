/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，学习背包系统的拖拽基本原理
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
using UnityEngine.EventSystems;

namespace Test
{
    public class Test_PackageDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private CanvasGroup _canvasGroup;                             //用于贴图的穿透处理
        private Vector3 _originalPosition;                            //原始方位
        private RectTransform _myReTransform;                         //二维方位

        void Start()
        {
            //获取贴图穿透组件
            _canvasGroup = GetComponent<CanvasGroup>();

            _myReTransform = transform as RectTransform;
            //获得原始方位
            _originalPosition = _myReTransform.position;
        }

        /// <summary>
        /// 拖拽前处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            //忽略自身(可以穿透)
            _canvasGroup.blocksRaycasts = false;
            //保证当前贴图可见。
            this.gameObject.transform.SetAsLastSibling();
        }

        /// <summary>
        /// 拖拽中处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 tmp_MousePos;                                                       //当前鼠标的位置
            //屏幕坐标，转二维矩阵坐标
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_myReTransform, eventData.position, eventData.pressEventCamera, out tmp_MousePos))
            {
                _myReTransform.position = tmp_MousePos;
            }
        }

        /// <summary>
        /// 拖拽后处理
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            //当前鼠标经过的格子名称
            GameObject tmp_cur = eventData.pointerEnter;
            if (tmp_cur != null)
            {
                if (tmp_cur.name.Equals("Img_GoalPos1"))
                {
                    _myReTransform.position = tmp_cur.transform.position;
                    _originalPosition = _myReTransform.position;
                }
                //没有遇到目标点
                else
                {
                    _myReTransform.position = _originalPosition;
                    //组织穿透，可以再次移动
                    _canvasGroup.blocksRaycasts = true;
                }
            }
            //拖拽到空区域
            else
            {
                //返回
                _myReTransform.position = _originalPosition;
            }
        }
    }
}