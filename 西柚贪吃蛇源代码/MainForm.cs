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
	public  enum Way
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
		private Point foodPoint ;
		//食物颜色
		private System.Drawing.Color foodColor = System.Drawing.Color.Green;
		//统计吞下多少食物
		private int foodCount = 0;
		//是否停止游戏
		private bool isStop = false;
		private System.Windows.Forms.Panel panel1;
		private SnakeMod snake  = new SnakeMod();
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
		private  delegate void DrawDele();
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
		protected override void Dispose( bool disposing )
		{
			try
			{
				game.Abort();
			}
			catch
			{
			}
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 497);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(759, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "开始";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(835, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(744, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "积分";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuExit});
            this.menuItem1.Text = "游戏设置";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "蛇体颜色设置";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "食物颜色设置";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11});
            this.menuItem4.Text = "游戏难度设置";
            // 
            // menuItem8
            // 
            this.menuItem8.Checked = true;
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "简单";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "一般";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.Text = "困难";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.Text = "自虐";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 3;
            this.menuExit.Text = "退出";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6});
            this.menuItem5.Text = "帮助";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "游戏控制说明";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(755, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 61);
            this.label2.TabIndex = 5;
            this.label2.Text = "adws为左右上下方向控制键，空格暂停";
            // 
            // mainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(977, 497);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "贪吃蛇";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		//画蛇51aspx
		private void DrawSnake()
		{
			lock(this)
			{
				foreach(Label temp in snake.GetSnake())
				{
					this.panel1.Controls.Add(temp);
				}
			}
		}
  
		//开始游戏
		private void StartGame()
		{
			drawDelegate = new DrawDele(PutFood);
			this.Invoke(drawDelegate,null); 
			while(true)
			{
				Thread.Sleep(speed);
				if(this.IsGameOver())
				{
					MessageBox.Show("GAME OVER");

                    try
                    {
                        if (game.IsAlive)
                        {
                            game.Abort();
                        }

                    }
                    catch
                    {
                    }
				}
				if(this.snake.Eat(this.foodPoint))
				{ 
					//改变积分
                    foodCount++;
                    SetText(System.Convert.ToString(foodCount * 10)); 
                    
					//消除原本食物
					drawDelegate = new DrawDele(KillFood);
					this.Invoke(drawDelegate,null); 
					//添加新食物
					drawDelegate = new DrawDele(PutFood);
					this.Invoke(drawDelegate,null); 
				}
				drawDelegate = new DrawDele(MoveSnake);
				this.Invoke(drawDelegate,null);    
			}
		}
		[STAThread]
		static void Main() 
		{
			Application.Run(new mainForm());
			//Application.Run(new Snake.SnakeColor());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//屏蔽游戏菜单
			this.menuItem1.Enabled = false;
			this.menuItem5.Enabled = false;
			//画蛇
			this.snake.DrawSnake();
			game = new Thread(new ThreadStart(StartGame));
			game.Start();
			this.DrawSnake();
			this.button1.Enabled = false;
			this.Focus();
		}
		private void MoveSnake()
		{
			this.snake.Move(this.panel1);
		}

		//发放食物
		private void PutFood()
		{

			Random rand = new Random();
			int x = rand.Next(350);
			int y = rand.Next(250);
			Label lblFood = new Label();
			lblFood.Size = new Size(10,10);
			lblFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblFood.BackColor = foodColor;
			lblFood.Location = new Point(x%10==0?x:x+(10-x%10),y%10==0?y:y+(10-y%10));
			this.foodPoint = new Point(lblFood.Left,lblFood.Top);
			this.panel1.Controls.Add(lblFood);

		}
		//接受键盘事件处理
		private void mainForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == 'a')
				this.snake.SnakeWay=(this.snake.SnakeWay ==Way.EAST)? Way.EAST:Way.WEST;
			else if(e.KeyChar == 'd')
				this.snake.SnakeWay=(this.snake.SnakeWay ==Way.WEST)? Way.WEST:Way.EAST;
			else if(e.KeyChar == 'w')
				this.snake.SnakeWay =(this.snake.SnakeWay==Way.SOUTH)?Way.SOUTH:Way.NORTH;
			else if(e.KeyChar == 's')
				this.snake.SnakeWay=(this.snake.SnakeWay==Way.NORTH)?Way.SOUTH:Way.SOUTH;
			else if(e.KeyChar==32)
			{
				if(this.isStop)
					game.Resume();
				else
					game.Suspend();
				this.isStop=!this.isStop;
			}
			else
				e.Handled = true;   
		}
		private void KillFood()
		{
			this.ClearFood(this.foodPoint);
		}
		private void ClearFood(Point food)
		{
			this.panel1.Controls.Remove(this.panel1.GetChildAtPoint(food));
		}
		//是否GameOver
		private bool IsGameOver()
		{
			ArrayList temp = this.snake.GetSnake();
			Label head = (Label)temp[0];
			foreach(Label lbl in temp.GetRange(1,temp.Count-1))
			{
				if(lbl.Left==head.Left && lbl.Top==head.Top)
				{
					return true;
				}
			}
			if(((Label)this.snake.GetSnake()[0]).Left==0 ||((Label)this.snake.GetSnake()[0]).Left==390 ||((Label)this.snake.GetSnake()[0]).Top==0 ||((Label)this.snake.GetSnake()[0]).Top==290)
			{
				return true;
			}
			return false;
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this,"ASDW为方向控制键\n空格为游戏暂停","控制说明"); 
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			//蛇体颜色设置
			SnakeColor temp = new SnakeColor();
			if(temp.ShowDialog(this)==DialogResult.OK)
			{
				this.snake.BodyColor = temp.Color;
				temp.Dispose();
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//食物颜色设置
			SnakeColor temp = new SnakeColor();
			if(temp.ShowDialog(this)==DialogResult.OK)
			{
				this.foodColor = temp.Color;
				temp.Dispose();
			}
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			ClearHook();
			this.menuItem8.Checked = true;
			this.speed = 300;
			//普通难度
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			ClearHook();
			this.menuItem10.Checked = true;
			this.speed=80;
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			ClearHook();
			this.menuItem11.Checked = true;
			this.speed=25;
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			//大鸟难度
			ClearHook();
			this.menuItem9.Checked = true;
			this.speed = 150;
		}
		//取消菜单前的钩
		private void ClearHook()
		{
			this.menuItem8.Checked =false;
			this.menuItem9.Checked =false;
			this.menuItem10.Checked =false;
			this.menuItem11.Checked =false;
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

