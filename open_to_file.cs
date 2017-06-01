using System;
using System.IO;
using System.Windows.Forms;

namespace sudoku
{
	/// <summary>
	/// Description of open_TO_file.
	/// </summary>
	public class open_TO_file
	{
		private string max;
		private string []mas=new string[72];
		private string str;
		public void Open(string str)
		{
			string url= string.Format(@"{0}\{1}","file",str);
			try{
				  if (File.Exists(url))
                {
                    StreamReader reader = File.OpenText(url);
                    max = reader.ReadToEnd();
                      for(int i=0,u=0;i<max.Length;i++)
                    {
                    	if(!max[i].Equals('\n'))
                    	{
                    		mas[u]+=max[i];
                    	}else{ mas[u]=mas[u].Trim('\r'); u++; }
                    }
                    reader.Close();
                    reader.Close();
                }
                else
                    MessageBox.Show("File is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			}
			catch(Exception)
			{
				 MessageBox.Show("Folder is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public void GoToLevel(string str)
		{
				string url= string.Format(@"{0}\{1}","file",str);
			try{
				  if (File.Exists(url))
                {
                    StreamReader reader = File.OpenText(url);
                    max = reader.ReadToEnd();
                    for(int i=0,u=0;i<max.Length;i++)
                    {
                    	if(!max[i].Equals('\n'))
                    	{
                    		mas[u]+=max[i];
                    	}else{ mas[u]=mas[u].Trim('\r'); u++; }
                    }
                    reader.Close();
                }
				  
                else
                    MessageBox.Show("File is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			}
				  
			catch(Exception)
			{
				                    MessageBox.Show("Folder is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
			
		}
	public	void OpenPazel(string str)
		{
		string url= string.Format(@"{0}\{1}","file",str);
			try{
				  if (File.Exists(url))
                {
                    StreamReader reader = File.OpenText(url);
                    max = reader.ReadToEnd();
			for(int  i=0,u=0;i<72;i++)
			{
				for(;u<max.Length;u++)
				{
						if(!max[u].Equals('\n'))
						{	
							mas[i]+=max[u].ToString();
						}else{mas[i]=mas[i].Trim('\r');u++; break;}
				}
			
			}
			reader.Close();
                     }
				  
                else
                    MessageBox.Show("File is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			}
				  
			catch(Exception)
			{
				    MessageBox.Show("Folder is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		}
		public void Znaky(string znak)
	{
		for(int i=0;i<72;i++)
		{
			if(znak==mas[i])
			{
				str=mas[i+1];
			break;
			}
		}
	}
		public string SL
	{
		get{return str;}
	}
		public string Str
		{
			get{return max;}
		}
		public string []Mas
		{
			get{return mas;}
		}
		
		}
}
