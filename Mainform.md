# --using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace Snake
{
	//移动方向
	publicenumWay
	{
		EAST,
		SOUTH,
		WEST,
		NORTH
	}
	///<summary>
	/// Form1 的摘要说明。
	///</summary>
	publicclassmainForm : System.Windows.Forms.Form
	{

		//移动速度控制
		privateint speed = 500;
		//食物坐标
		privatePoint foodPoint ;
		//食物颜色
		private System.Drawing.Color foodColor = System.Drawing.Color.Green;
		//统计吞下多少食物
		privateint foodCount = 0;
		//是否停止游戏
		privatebool isStop = false;
		private System.Windows.Forms.Panel panel1;
		privateSnakeMod snake  = newSnakeMod();
		private System.Windows.Forms.Button button1;
privateThread game;
privateIContainer components;
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
