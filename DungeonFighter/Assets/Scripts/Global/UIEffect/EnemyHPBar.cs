/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，敌人血条
 * 
 * Description:
 *      具体作用：在敌人头上显示血条
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;
using Kernal;
using UnityEngine.UI;

namespace Global
{
    public class EnemyHPBar : MonoBehaviour
    {
        public float floHPPrefabLength = 0.5f;                                    //血条预设长度
        public float floHPPrefabHeight = 1;                                     //血条预设高度

        private GameObject _goTargetEenemy;                                     //目标对象
        private Camera _worldCamera;                                            //世界坐标系
        private Camera _guiCamera;                                              //UI坐标系
        private Slider _UISlider;                                               //显示控件

        //敌人生命数值
        private float _floCurrentHP;
        private float _floMaxHP;
        void Start()
        { 
            //控件尺寸
            transform.localScale = new Vector3(floHPPrefabLength, floHPPrefabHeight, 0);

            //得到UISlider控件
            _UISlider = GetComponent<Slider>();
            //世界摄像机
            _worldCamera = Camera.main.gameObject.GetComponent<Camera>();
            //UI摄像机
            _guiCamera = GameObject.FindGameObjectWithTag(Tag.UICamera).GetComponent<Camera>();
            if (_goTargetEenemy == null)
            {
                Debug.LogError(GetType() + "/Start()/_goTargetEenemy为空");
                return;
            }
        }

        public void SetTargetEnemy(GameObject _goEnemy)
        {
            _goTargetEenemy = _goEnemy;
        }
        void Update()
        {
            try
            {
                if (Time.frameCount % 3 == 0)
                {
                    //当前与最大生命数值
                    _floCurrentHP = _goTargetEenemy.GetComponent<Ctrl_BaseEnemyProperty>().floCurrentHealth;
                    _floMaxHP = _goTargetEenemy.GetComponent<Ctrl_BaseEnemyProperty>().MaxHealth;
                    //计算血量
                    _UISlider.value = _floCurrentHP / _floMaxHP;
                    //控件尺寸
                    transform.localScale = new Vector3(floHPPrefabLength, floHPPrefabHeight, 0);
                    //销毁条件判断
                    if (_floCurrentHP <= 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            catch
            {

            }
        }


        void LateUpdate()
        {
            //血条三维坐标系与UI坐标系转换
            if (Time.frameCount % 3 == 0)
            {
                if (_goTargetEenemy)
                {
                    //获取目标的屏幕坐标
                    Vector3 tmp_Pos = _worldCamera.WorldToScreenPoint(_goTargetEenemy.transform.position);
                    //屏幕坐标转UI世界坐标
                    tmp_Pos = _guiCamera.ScreenToWorldPoint(tmp_Pos);
                    //确定UI的最终位置
                    tmp_Pos.z = 0;
                    transform.position = new Vector3(tmp_Pos.x, tmp_Pos.y + 2f, tmp_Pos.z);
                }
            }
        }
    }//class end
}