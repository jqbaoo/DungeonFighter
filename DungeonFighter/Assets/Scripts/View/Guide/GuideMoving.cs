/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，新手引导动画移动
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
using DG.Tweening;

namespace View
{
    public class GuideMoving : MonoBehaviour
    {
        public GameObject goMovingGoal;                                     //移动的目标对象
        void OnEnable()
        {
            Tweener tmp_MoveTW = transform.DOMove(goMovingGoal.transform.position, 1f);
            tmp_MoveTW.SetLoops(5);
        }
    }
}