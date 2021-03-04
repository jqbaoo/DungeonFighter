/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，测试对话信息
 * 
 * Description:
 *      具体作用：
 *      仅作测试使用
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kernal;

namespace View
{
    public class Test_DialogsInfo : MonoBehaviour
    {
        public Text txt_Side;
        public Text txt_PersonName;
        public Text txt_PersonContent;

        /// <summary>
        /// 得到下一条对话信息
        /// </summary>
        public void DisplayNextDialogInfo()
        {
            e_DialogSide tmp_DiaSide = e_DialogSide.None;
            string tmp_StrDialogPersonName;
            string tmp_StrDialogPersonContent;
            bool tmp_Result = DialogDataManager.GetInstance().GetNextDialogInfoRecoder(1, out tmp_DiaSide, out tmp_StrDialogPersonName, out tmp_StrDialogPersonContent);

            if (tmp_Result)
            {
                switch (tmp_DiaSide)
                {
                    case e_DialogSide.None:
                        break;
                    case e_DialogSide.HersoSide:
                        txt_Side.text = "英雄";
                        break;
                    case e_DialogSide.NPCSide:
                        txt_Side.text = "NPC";
                        break;
                    default:
                        break;
                }
                txt_PersonName.text = tmp_StrDialogPersonName;
                txt_PersonContent.text = tmp_StrDialogPersonContent;
            }
            else
            {
                txt_PersonName.text = "没有输出数据了";
                txt_PersonContent.text = "没有输出数据了";
            }
            Log.SyncLogArrayToFile();
        }
    }
}