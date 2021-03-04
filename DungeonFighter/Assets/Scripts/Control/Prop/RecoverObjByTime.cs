/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，使用对象缓存池按指定时间回收对象
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

namespace Control
{
    public class RecoverObjByTime : MonoBehaviour
    {
        public float floRecoverTime = 1f;
        void OnEnable()
        {
            StartCoroutine("RecoverGameObjectByTime");
        }
        void OnDisable()
        {            
            StopCoroutine("RecoverGameObjectByTime");
        }

        IEnumerator RecoverGameObjectByTime()
        {
            yield return new WaitForSeconds(floRecoverTime);
            PoolManager.PoolsArray["ParticleSys"].RecoverGameObjectToPool(this.gameObject);
        }
    }
}