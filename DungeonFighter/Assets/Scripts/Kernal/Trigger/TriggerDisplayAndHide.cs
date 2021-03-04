/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 核心层，触发游戏对象显示与隐藏
 * 
 * Description:
 *      具体作用：手工版的"遮挡剔除"
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
    public class TriggerDisplayAndHide : MonoBehaviour
    {
        public string tagNameByHero = "Player";                                         //标签：英雄
        public string tagNameByDisplayObject = "TagNameDisplayName";                    //标签：需要显示的对象
        public string tagNameByHideObject = "tagNameHideObject";                        //标签：需要隐藏的对象

        private GameObject[] _goDisplayObjectArray;                                       //需要显示的对象集合 
        private GameObject[] _goHideObjectArray;                                          //需要隐藏的对象集合
        void Start()
        {
            //得到需要显示的游戏对象
            _goDisplayObjectArray = GameObject.FindGameObjectsWithTag(tagNameByDisplayObject);
            //得到需要隐藏的游戏对象
            _goHideObjectArray = GameObject.FindGameObjectsWithTag(tagNameByHideObject);

        }

        /// <summary>
        /// 进入触发检测
        /// </summary>
        /// <param name="_col"></param>
        void OnTriggerEnter(Collider _col)
        {
            //发现英雄
            if (_col.gameObject.tag == tagNameByHero)
            {
                foreach (GameObject tmp_GoItem in _goDisplayObjectArray)
                {
                    tmp_GoItem.SetActive(true);
                }
            }
        }

        /// <summary>
        /// 退出触发检测
        /// </summary>
        /// <param name="_col"></param>
        void OnTriggerExit(Collider _col)
        {
            //发现英雄
            if (_col.gameObject.tag == tagNameByHero)
            {
                foreach (GameObject tmp_GoItem in _goHideObjectArray)
                {
                    tmp_GoItem.SetActive(false);
                }
            }
        }

    }//class end
}