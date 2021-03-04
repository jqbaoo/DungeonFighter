/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，使道具旋转
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

namespace Control
{
    public class MakeObjRotation : BaseControl
    {
        public float floRotateSpeed = 1f;

        void Update()
        {
            transform.Rotate(Vector3.up, floRotateSpeed);
        }
    }
}