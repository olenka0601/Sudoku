﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace sudoku
{
    /// <summary>
    /// Description of MainForm.
    /// <summary>
    public partial class MainForm : Form
	{	
     	private  int a = 0;
     	private  int b = 0;
      	private  int c = 0;
      	private int ur=0;
		private string specznak;
    	private int CountOfError=0;
	private	 Label [,]lib=new Label[9,9];
	private  ChooseNum but=new ChooseNum();
	private  open_TO_file file =new open_TO_file();
		private bool flag_x_y=true;
		private bool flag=true;
		private string ryven;
		private string []listofrules=new string[72];
		private int error;
		private int fullTime;
		private bool close;
		public MainForm(string str,string pravula)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Initialization_lib();
			
			file.OpenPazel("pazel.tt");
			file.Znaky(str);
			
			ryven=pravula;
			Puzel(file.SL);
			specznak=str;
			for(int i=0;i<72;i++)
			{
				listofrules[i]=file.Mas[i];
			}
			timer();
		}
		void PRVL()
		{
	 			
			if(ryven=="Easy")
			{
				 file.GoToLevel("light.tt");
				 label89.Text=file.Str;
				 
				 label86.Text="0";
				
			}else if(ryven=="Normal")
			{
				 file.GoToLevel("average.tt");
			 label89.Text=file.Str;
				 error=6;
				 label86.Text=error.ToString();
				 fullTime=6;
				
			}else if(ryven=="Complicated")
			{
				 file.GoToLevel("hard.tt");
			label89.Text=file.Str;
				 error=3;
				 label86.Text=error.ToString();
				 fullTime=8;
				
			}
		}
		void Initialization_lib()
        {
        	lib[0,0]=label1;
     	  	lib[0,1]=label2;
        	lib[0,2]=label3;
        	lib[0,3]=label4;
     	  	lib[0,4]=label5;
        	lib[0,5]=label6;
        	lib[0,6]=label7;
     	  	lib[0,7]=label8;
        	lib[0,8]=label9;
        	
        	lib[1,0]=label10;
     	  	lib[1,1]=label11;
        	lib[1,2]=label12;
        	lib[1,3]=label13;
     	  	lib[1,4]=label14;
        	lib[1,5]=label15;
        	lib[1,6]=label16;
     	  	lib[1,7]=label17;
        	lib[1,8]=label18;
        	
        	lib[2,0]=label19;
     	  	lib[2,1]=label20;
        	lib[2,2]=label21;
        	lib[2,3]=label22;
     	  	lib[2,4]=label23;
        	lib[2,5]=label24;
        	lib[2,6]=label25;
     	  	lib[2,7]=label26;
        	lib[2,8]=label27;
        	
        	lib[3,0]=label28;
     	  	lib[3,1]=label29;
        	lib[3,2]=label30;
        	lib[3,3]=label31;
     	  	lib[3,4]=label32;
        	lib[3,5]=label33;
        	lib[3,6]=label34;
     	  	lib[3,7]=label35;
        	lib[3,8]=label36;
        	
        	lib[4,0]=label37;
     	  	lib[4,1]=label38;
        	lib[4,2]=label39;
        	lib[4,3]=label40;
     	  	lib[4,4]=label41;
        	lib[4,5]=label42;
        	lib[4,6]=label43;
     	  	lib[4,7]=label44;
        	lib[4,8]=label45;
        	
        	lib[5,0]=label46;
     	  	lib[5,1]=label47;
        	lib[5,2]=label48;
        	lib[5,3]=label49;
     	  	lib[5,4]=label50;
        	lib[5,5]=label51;
        	lib[5,6]=label52;
     	  	lib[5,7]=label53;
        	lib[5,8]=label54;
        	
        	lib[6,0]=label55;
     	  	lib[6,1]=label56;
        	lib[6,2]=label57;
        	lib[6,3]=label58;
     	  	lib[6,4]=label59;
        	lib[6,5]=label60;
        	lib[6,6]=label61;
     	  	lib[6,7]=label62;
        	lib[6,8]=label63;
        	
        	lib[7,0]=label64;
     	  	lib[7,1]=label65;
        	lib[7,2]=label66;
        	lib[7,3]=label67;
     	  	lib[7,4]=label68;
        	lib[7,5]=label69;
        	lib[7,6]=label70;
     	  	lib[7,7]=label71;
        	lib[7,8]=label72;
        	
        	lib[8,0]=label73;
     	  	lib[8,1]=label74;
        	lib[8,2]=label75;
        	lib[8,3]=label76;
     	  	lib[8,4]=label77;
        	lib[8,5]=label78;
        	lib[8,6]=label79;
     	  	lib[8,7]=label80;
        	lib[8,8]=label81;
		}
		void Puzel(string st)
        {
		 	for(int i=0,y=0;i<9;i++)
            	{
                for (int o = 0; o < 9; o++, y++)
                {
                    if (st[y] != '*' )  
        		{
        			lib[i,o].Text=st[y].ToString();
        			lib[i,o].Enabled=false;
        			
        		}
        		else{lib[i,o].Text=" ";}
        		}
		 	}
        	
        	
        }
		void timer()
		 {
	
		 	timer1.Start();
		 	timer2.Start();
		 }
		private void terms(int x,int y)
		 {
		 					 if (but.ShowDialog() == DialogResult.OK)
			  			 {
			  			 	for(int i =0;i<9;i++)
			  			 	{
			  			 		if( lib[x,i].Text!=but.STR()&&lib[i,y].Text!=but.STR())
			  			 		{
			  			 			flag_x_y=true;
			  			 		}else{ 
			  			 			if(lib[x,i].Text==but.STR())
			  			 				lib[x,i].BackColor=Color.Red;
			  			 			else
			  			 				lib[i,y].BackColor=Color.Red;
			  			 			flag_x_y =false;
			  			 			
			  			 			CountOfError++;
			  			 			
			  			 			break;
			  			 		}
			  			 	}
			  		
			  		if((x==0||x<3)&&(y==0||y<3))
			{
			  			pravula_hody(0,0,3,3);
			} else if((x==0||x<3)&&(y==3||y<6))
			{
			  			pravula_hody(0,3,3,6);
			}else if((x==0||x<3)&&(y==6||y<9))
			{
			  			pravula_hody(0,6,3,9);
				}else if((x==3||x<6)&&(y==0||y<3))
			{
			  			pravula_hody(3,0,6,3);
			}else if((x==3||x<6)&&(y==3||y<6))
			{
			  			pravula_hody(3,3,6,6);
			}else if((x==3||x<6)&&(y==6||y<9))
			{
			  			pravula_hody(3,6,6,9);
				}else if((x==6||x<9)&&(y==0||y<3))
			{
			  			pravula_hody(6,0,9,3);
			}else if((x==6||x<9)&&(y==3||y<6))
			{
			  			pravula_hody(6,3,9,6);
			}else if((x==6||x<9)&&(y==6||y<9))
			{
			  			pravula_hody(6,6,9,9);
			}
		 					 }
		}
		private void check(int x,int y)
		 {
		 	int i=0;
		 	 if(flag_x_y==true&&flag==true)
			  	lib[x,y].Text=but.STR();
			  else
			  {
			  
			  	MessageBox.Show("This number has already existed");
			  	if(flag_x_y==false)
			  	{
			  		label85.Text=CountOfError.ToString();
			  	}else if(flag==false){
			  		label85.Text=CountOfError.ToString();
			  	}  
			  		if (error ==CountOfError)
			  	{
			  		DialogResult dr=MessageBox.Show("A lot of mistakes!","Would you try again?",MessageBoxButtons.YesNo);
			  		if(dr== DialogResult.Yes)
			  		{
			  			restart();
			  			
			  		}else if(dr== DialogResult.No)
			  		{
			  			this.Close();
			  		}
			  	}
			  
			  	
			  }
			
			  for(int z=0;z<9;z++)
			  {
			  	for(int c=0;c<9;c++)
			  	{
			  		lib[z,c].BackColor=Color.White;
			  		if(lib[z,c].Text.ToString()!=" ")
			  		{
			  			
			  			i++;
			  		}	
			  	} 
			  }
			  
			  
			  
			  
			  if(i==81)
			  {
			  	the_transition_to_a_new_level level =new the_transition_to_a_new_level(specznak,ryven);
			  	if(level.ShowDialog() == DialogResult.OK)
			  	{
			  		 New_Game();
			  	}else if(level.DialogResult== DialogResult.Retry)
			  	{
			  		restart();
			  	}
			  	else if(level.DialogResult== DialogResult.No)
			  	{
			  		this.Close();
			  	}
			  }
		 }
		void restart()
		 {
		 	timer1.Stop();
		 	timer2.Stop();
		 	a=0;
		 	c=0;
		 	b=0;
		 	CountOfError=0;
            file.Znaky(specznak);
			Puzel(file.SL);
			PRVL();
			timer();
		 	
		 }
		void pravula_hody(int x,int y,int c,int b)
		{
			for(int t=x;t<c;t++)
			{
			 for(int v=y;v<b;v++)
			  	{
			  	if(lib[t,v].Text==but.STR())
				{
			  		flag=false;
			  		lib[t,v].BackColor=Color.Red;
			  	}
			  			        		
				 }
			}
					
		}
		void Click(object sender, EventArgs e)
		{
			int x=0,y=0;
			  for (int index_x=0 ; index_x < 9; index_x++)
			  {
			  	for(int index_y=0;index_y<9;index_y++)
			  	{
			  		if (sender as Label == lib[index_x,index_y])
			  		{
			  			x=index_x;
			  			y=index_y;
			  			break;
			  		}
			  	}
			  	if(x!=0&&y!=0)
			  		break;
			  }
			  terms(x,y);
			  check(x,y);
			  flag=true;
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			 timer1.Interval = 1000;
            timer1.Enabled = true;
            a++;
            if (a == 60)
            {
                b++;
                a = 0;
                if (b == 60)
                {
                    c++;
                    b = 0;
                }
            }
            label82.Text = c.ToString() + ":" + b.ToString() + ":" + a.ToString();
		 
		}
		void New_Game()
		{
			if(ur<12)
			{
				string temp="";
			variants varin =new variants();
			for(int i=1;i<=12;i++)
			{
				if(varin.SSR[i]==specznak)
				{
					i=i+1;
					specznak=varin.SSR[i];
					break;
				}
			}
			timer1.Stop();
			a=0;
			b=0;
			c=0;
			CountOfError=0;
			for(int i=0;i<72;i++)
			{
				if(listofrules[i]==specznak)
				{
					i=i+1;
					temp=listofrules[i];
				break;
				}
			}
			Puzel(temp);
			timer();
//			
			}else {
				MessageBox.Show("Level was successfully completed!");
				the_transition_to_a_new_level  lev=new the_transition_to_a_new_level(specznak,ryven);
				lev.save();
				ur++;
			}
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			DialogResult dr=MessageBox.Show("Do you want to finish?","Exit",MessageBoxButtons.YesNo);
			
			if(dr==DialogResult.Yes){
				close=true;
                this.Close();
				
			}else if(dr== DialogResult.No)
			{
				close=false;
			}
			
		}	
		void MainFormLoad(object sender, EventArgs e)
		{
			
			PRVL();
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			if(close==true)
			   {
			   this.DialogResult= DialogResult.No;
			   }else{
				this.DialogResult= DialogResult.OK;
			   }
		}
		void Timer2Tick(object sender, EventArgs e)
		{
			if(ryven=="Complicated"||ryven=="Normal")
			{
			timer2.Interval = 1000;
            timer2.Enabled = true;
				if (fullTime==b||fullTime<b)
			  	{
			  			timer2.Stop();
			  			timer1.Stop();
			  		DialogResult dr=MessageBox.Show("Try again?","You lose",MessageBoxButtons.YesNo);
			  		if(dr== DialogResult.Yes)
			  		{
			  			restart();
			  			
			  		}else if(dr== DialogResult.No)
			  		{
			  			this.Close();
			  		}
			  	}
			}else timer2.Stop();
		}

        private void label89_Click(object sender, EventArgs e)
        {

        }
    }
}

