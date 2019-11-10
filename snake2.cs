
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