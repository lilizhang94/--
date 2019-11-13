private void menuItem8_Click(object sender, System.EventArgs e)
        {
            //简单难度
			ClearHook();
			this.menuItem8.Checked = true;
			this.speed = 500;
		}

        private void menuItem9_Click(object sender, System.EventArgs e)
        {
            //一般难度
            ClearHook();
            this.menuItem9.Checked = true;
            this.speed = 300;
        }

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
            //困难难度
			ClearHook();
			this.menuItem10.Checked = true;
			this.speed=180;
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
            //自虐难度
			ClearHook();
			this.menuItem11.Checked = true;
			this.speed=100;
		}


		//取消菜单前的钩
		private void ClearHook()
		{
			this.menuItem8.Checked =false;
			this.menuItem9.Checked =false;
			this.menuItem10.Checked =false;
			this.menuItem11.Checked =false;
		}
	}