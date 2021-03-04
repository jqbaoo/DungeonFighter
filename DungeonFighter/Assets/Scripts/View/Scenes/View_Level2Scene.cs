/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，第二关卡场景
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
using Kernal;
using Global;
using Control;
using UnityEngine.UI;

namespace View
{
    public class View_Level2Scene : MonoBehaviour
    {
        public Button btn_ReturnMajorCity;

        void Awake()
        {
            btn_ReturnMajorCity = GetComponent<Button>();
        }
        void Start()
        {
            btn_ReturnMajorCity.onClick.AddListener(ReturnMajorCity);
        }
        private void ReturnMajorCity()
        {
            Ctrl_Level2Scene.Instance.ReturnMajorCity();
        }
    }
}