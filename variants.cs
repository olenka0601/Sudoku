using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace sudoku
{
	/// <summary>
	/// Description of variants.
	/// </summary>
	public partial class variants : Form
	{
        private string[] level = { "Easy", "Normal", "Complicated" };
        private int  number=0;
		private int index=0;
		private bool tmp=false;
        private bool close;
		public variants()
		{
			//
			// ThSystem.Drawing.Bitmape InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
		
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(tmp==true)
			{
			MainForm mainform=new MainForm(struck[index],label1.Text);
			this.Hide();
			if(mainform.ShowDialog()== DialogResult.OK)
			{
				this.Close();
				
			}else if(mainform.DialogResult== DialogResult.No)
			{
				open_TO_file  to_file=new open_TO_file();
				to_file.GoToLevel("level.tt");
                to_file.Znaky(label1.Text);
			//	CheckPuzel(to_file.SL);
				this.Visible=true;
			}
			}else{MessageBox.Show("You didn't choose","Error");}
			
			
		}
		void VariantsLoad(object sender, EventArgs e)
		{
			menu menu=new menu();
			if(menu.ShowDialog()==DialogResult.Cancel)
			{
                close = true;
				this.Close();
			}else if(menu.DialogResult== DialogResult.OK)
			{
				 open_TO_file file = new open_TO_file();
				file.GoToLevel("level.tt");
                file.Znaky(label1.Text);
				//CheckPuzel(file.SL);
			
			}
		}
		void CheckPuzel(string str)
		{

			string []mas_pazl=new string[13];
			for(int i=0,t=1;i<str.Length;i++)
			{
				if(!str[i].Equals(','))
					mas_pazl[t]+=str[i].ToString();
				else{t++;}
				
			}
			
				for(int b=1;b<=12;b++)
				{
				if(!RB[b].Name.Equals(mas_pazl[b]))
				{RB[b].Enabled=false;}else{RB[b].Enabled=true;}
				}
			
			
		}
		void Label2Click(object sender, EventArgs e)
		{
			number++;
			open_TO_file file = new open_TO_file();
			file.GoToLevel("level.tt");
			if(number==3)
				number=0;
			label1.Text=level[number];
            file.Znaky(label1.Text);
			
			//	CheckPuzel(file.SL);
			
		}
		void RB_Click(object sender, EventArgs e)
		{			
			for(int i=1;i<=12;i++)
			{
				if (sender as RadioButton == RB[i])
				{
					index=Convert.ToInt32(RB[i].Text);
					break;
				}
			}
			if(label1.Text=="Normal")
			{
				index=index+11;
			}else if(label1.Text=="Complicated")
			{
				index=index+21;
			}
		tmp=true;
			
		}
		void Label3Click(object sender, EventArgs e)
		{
			 open_TO_file file = new open_TO_file();
			file.GoToLevel("level.tt");
			
			number--;
			if(number<0)
				number=2;
			label1.Text=level[number];
            file.Znaky(label1.Text);
			
				//CheckPuzel(file.SL);
		}
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		public string []SSR
		{
			get{return struck;}
		}		
		void VariantsFormClosed(object sender, FormClosedEventArgs e)
		{
            if (close == true)
            { this.DialogResult = DialogResult.No; }
            else
            {
                DialogResult dr = MessageBox.Show("Do you really want to finish the game?", "Exit", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                { }
                { this.DialogResult = DialogResult.No; }
            }
		}

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
