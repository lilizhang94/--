
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Snake
{
	/// <summary>
	/// SnakeColor ��ժҪ˵����
	/// </summary>
	public class SnakeColor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Drawing.Color Color
		{
			get
			{
				return this.label1.BackColor;
			}
			set
			{
				this.label1.BackColor = value;
			}
		}

		public SnakeColor()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SkyBlue;
			this.label1.Location = new System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 40);
			this.label1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "��ɫ",
														   "��ɫ",
														   "��ɫ",
														   "����ɫ",
														   "�ۺ�ɫ",
														   "��ɫ"});
			this.comboBox1.Location = new System.Drawing.Point(136, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(112, 20);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "��ɫѡ��";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("����_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.ForeColor = System.Drawing.Color.Red;
			this.button1.Location = new System.Drawing.Point(104, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 32);
			this.button1.TabIndex = 2;
			this.button1.Text = "ȷ��";
			// 
			// SnakeColor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(272, 158);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SnakeColor";
			this.Text = "��ɫѡ��";
			this.ResumeLayout(false);

		}
		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(this.comboBox1.SelectedIndex)
			{
				case 0: this.Color = System.Drawing.Color.Red;break;
				case 1: this.Color = System.Drawing.Color.Yellow;break;
				case 2: this.Color = System.Drawing.Color.Green;break;
				case 3: this.Color = System.Drawing.Color.SkyBlue;break;
				case 4: this.Color = System.Drawing.Color.Pink;break;
				case 5: this.Color = System.Drawing.Color.Fuchsia;break;
			}
		}
	}
}