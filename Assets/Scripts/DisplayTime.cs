using UnityEngine;
using TMPro;
using System;

namespace SNAKE
{
    public class DisplayTime : MonoBehaviour
    {
        public bool displayCurrentTime;
        private TMP_Text CurrrentTimeText;
        private int hour;
        private int minute;
        private int second;
        private int year;
        private int month;
        private int day;

        private void Start () {
            CurrrentTimeText = GetComponent<TMP_Text>();
        }

        private void Update () {
            //获取当前时间
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;

            if (displayCurrentTime)
            {
                //格式化显示当前时间
                CurrrentTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}/{4:D2}/{5:D2}", hour, minute, second, year, month, day);
            }
            else
            {
                //格式化显示剩余时间
                CurrrentTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} ", 24 - hour - 1, 60 - minute - 1, 60 - second);
            }
        }
    }
}
