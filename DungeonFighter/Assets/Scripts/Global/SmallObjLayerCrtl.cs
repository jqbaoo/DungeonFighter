/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，层消隐技术
 * 
 * Description:
 *      具体作用：小物件远距离消隐，近距离显示
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class SmallObjLayerCrtl : MonoBehaviour
    {
        public int intDisappearDistance = 10;                                   //消隐距离
        private float[] _distanceArray = new float[32];
        void Start()
        {
            //指定第八层为消隐层
            _distanceArray[8] = intDisappearDistance;
            Camera.main.layerCullDistances = _distanceArray;
        }
    }
}