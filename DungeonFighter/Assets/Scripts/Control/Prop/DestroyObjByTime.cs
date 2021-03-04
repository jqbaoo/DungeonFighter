/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，按照规定时间销毁道具
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
    public class DestroyObjByTime : BaseControl
    {
        public float floDestroyTime = 2f;

        void Start()
        {
            Destroy(this.gameObject, floDestroyTime);
        }
    }
}