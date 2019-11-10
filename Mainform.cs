using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace Snake
{
    //移动方向
    public enum Way
    {
        EAST,
        SOUTH,
        WEST,
        NORTH
    }
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class mainForm : System.Windows.Forms.Form
    {

        //移动速度控制
        private int speed = 500;
        //食物坐标
        private Point foodPoint;
        //食物颜色
        private System.Drawing.Color foodColor = System.Drawing.Color.Green;
        //统计吞下多少食物
        private int foodCount = 0;
        //是否停止游戏
        private bool isStop = false;
        private System.Windows.Forms.Panel panel1;
        private SnakeMod snake = new SnakeMod();
        private System.Windows.Forms.Button button1;
        private Thread game;
        private IContainer components;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.Label label2;
        //创建委托
        private delegate void DrawDele();
        private DrawDele drawDelegate;

        public mainForm()
        {

            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }



        private delegate void SetTextCallback(string text);
        //在给textBox1.text赋值的地方调用以下方法即可
        private void SetText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                game.Abort();
            }
            catch
            {
            }
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
