using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    ///51aspx编辑测试
	/// <summary>
	/// SnakeMod 的摘要说明。
	/// </summary>
	public class SnakeMod
	{
		//判断食物是否在蛇身体里
		private bool hasFood = false;
		//蛇身介质
		private Label body;
		//蛇的颜色
		private Color _color = System.Drawing.Color.SkyBlue;
		//颜色属性
		public System.Drawing.Color BodyColor
		{
			set
			{
				this._color = value;
			}
		}
		//蛇的大小
		private Size size;
		//移动方向默认向西
		private Snake.Way way =Way.WEST; 
		public Way SnakeWay
		{
			set
			{
				this.way=value;
			}
			get
			{
				return way;
			}
		}
		//蛇身
		private ArrayList snake ;
		//构造函数
		public SnakeMod()
		{
		}
		//画蛇
		public void DrawSnake()
		{
			//设置大小
			size = new Size(10,10);
			//设置身体
			snake = new ArrayList();
			for(int i=0;i<5;i++)
			{
				body = new Label();
				body.BackColor = _color;
				body.Size = size;
				body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				body.Location=new Point(200+i*10,150);
				snake.Add(body);
			}
		}
		//返回蛇体
		public ArrayList GetSnake()
		{
			return snake;
		}
		//蛇体移动
		public void Move(System.Windows.Forms.Control control)
		{
			if(!this.hasFood)
			{
				control.Controls.Remove(control.GetChildAtPoint(((Label)snake[snake.Count-1]).Location));
				snake.RemoveAt(snake.Count-1);
			}
			Label temp = new Label();
			this.CopyBody(temp,(Label)snake[0]);
			switch(this.way)
			{ 
     
				case Way.WEST:
				{    
					temp.Left-=10;
					snake.Insert(0,temp);
					break;
				}
     
				case Way.EAST:
				{
					temp.Left+=10;
					snake.Insert(0,temp);
					break;
				}
				case Way.NORTH:
				{
					temp.Top-=10;
					snake.Insert(0,temp);
					break;
				}
				case Way.SOUTH:
				{
					temp.Top+=10;
					snake.Insert(0,temp);
					break;
				}
			}
			control.Controls.Add((Label)snake[0]);
			if(this.hasFood)
			{
				this.hasFood=false;
			}
   
		}
		//copy蛇身
		private void CopyBody(Label x,Label y)
		{
			x.Location = y.Location;
			x.BackColor = y.BackColor;
			x.Size = y.Size;
			x.BorderStyle = y.BorderStyle;
		}
		//吃东西
		public bool Eat(Point food)
		{
			if(((Label)snake[0]).Left == food.X && ((Label)snake[0]).Top == food.Y)
			{
				//吃到东西
				this.hasFood = true;
				return true;
			}
			return false;
		}
	}
}