using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    ///51aspx�༭����
	/// <summary>
	/// SnakeMod ��ժҪ˵����
	/// </summary>
	public class SnakeMod
	{
		//�ж�ʳ���Ƿ�����������
		private bool hasFood = false;
		//�������
		private Label body;
		//�ߵ���ɫ
		private Color _color = System.Drawing.Color.SkyBlue;
		//��ɫ����
		public System.Drawing.Color BodyColor
		{
			set
			{
				this._color = value;
			}
		}
		//�ߵĴ�С
		private Size size;
		//�ƶ�����Ĭ������
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
		//����
		private ArrayList snake ;
		//���캯��
		public SnakeMod()
		{
		}
		//����
		public void DrawSnake()
		{
			//���ô�С
			size = new Size(10,10);
			//��������
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
		//��������
		public ArrayList GetSnake()
		{
			return snake;
		}
		//�����ƶ�
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
		//copy����
		private void CopyBody(Label x,Label y)
		{
			x.Location = y.Location;
			x.BackColor = y.BackColor;
			x.Size = y.Size;
			x.BorderStyle = y.BorderStyle;
		}
		//�Զ���
		public bool Eat(Point food)
		{
			if(((Label)snake[0]).Left == food.X && ((Label)snake[0]).Top == food.Y)
			{
				//�Ե�����
				this.hasFood = true;
				return true;
			}
			return false;
		}
	}
}