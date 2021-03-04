/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，"飘字"特效
 * 
 * Description:
 *      具体作用：受到伤害后现实伤害数值
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUpLabel : MonoBehaviour
{
    public float floHPPrefabLength = 2f;                                    //血条预设长度
    public float floHPPrefabHeight = 1f;                                     //血条预设高度
    public float floPosOffset = 2f;

    private GameObject _goTargetEenemy;                                     //目标对象
    private Camera _worldCamera;                                            //世界坐标系
    private Camera _guiCamera;                                              //UI坐标系
    private Text _txt_Num;                                                  //显示控件

    //敌人生命数值
    private int _intCurrentReduceHpNumber;                               //减少的生命数值
    void Start()
    {
        //得到UISlider控件
        _txt_Num = GetComponent<Text>();
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

    /// <summary>
    /// 设置目标对象
    /// </summary>
    /// <param name="_goEnemy"></param>
    public void SetTarget(GameObject _goEnemy)
    {
        _goTargetEenemy = _goEnemy;
    }

    /// <summary>
    /// 设置减少数值
    /// </summary>
    /// <param name="_intNumber"></param>
    public void SetReduceHpNumber(int _intNumber)
    {
        _intCurrentReduceHpNumber = _intNumber;
    }

    void Update()
    {
        if (Time.frameCount % 3 == 0)
        {
            //控件显示血量
            _txt_Num.text = _intCurrentReduceHpNumber.ToString();
            //控件尺寸
            this.transform.localScale = new Vector3(floHPPrefabLength, floHPPrefabHeight, 0);
            //位置的偏移量(向上移动)
            floPosOffset += 0.02f;
            //销毁，使用缓存技术
        }
    }

    /// <summary>
    /// 特效三维坐标系与UI坐标系转换
    /// </summary>
    void LateUpdate()
    {
        if (_goTargetEenemy)
        {
            //获取目标的屏幕坐标
            Vector3 tmp_Pos = _worldCamera.WorldToScreenPoint(_goTargetEenemy.transform.position);
            //屏幕坐标转UI世界坐标
            tmp_Pos = _guiCamera.ScreenToWorldPoint(tmp_Pos);
            //确定UI的最终位置
            tmp_Pos.z = 0;
            transform.position = new Vector3(tmp_Pos.x, tmp_Pos.y + floPosOffset, tmp_Pos.z);
        }
    }
}
