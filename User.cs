/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : User.cs
* Version     : v1.0
* Author      : Batan, John Aldrin B.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Artsy {
	public class User {

		public static void Main(String[] args){
			User user = new User("test","123");
			user.Login();
			user.AddUser("test", "123");
			MessageBox.Show(@"USER ID:" + user.GetUserID());
		}

		public string Username{
			get;
			set;
		}

		public string UserID{
			get;
			set;
		}

		public string Password{
			get;
			set;
		}
		
		public User(string Username, string Password) {
			this.Username = Username;
			this.Password = Password;
		}

		public void Login(){
			if(FindMatch())
				MessageBox.Show("Login success");
			else
				MessageBox.Show("Account not registered");
		}

		public bool FindMatch(){

			string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\Artsy.accdb";
			string sql = "SELECT * FROM [User] WHERE [UserName] = @Username AND [Password] = @Password;";

			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + CurrentPath;

			try{
				con.Open();
				OleDbCommand command = new OleDbCommand(sql, con);
				command.CommandType = CommandType.Text;
				command.Parameters.AddWithValue("@Username", this.Username);
				command.Parameters.AddWithValue("@Password", this.Password);
				command.ExecuteNonQuery();
				OleDbDataAdapter adapter = new OleDbDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				if(dt != null){
					if(dt.Rows.Count > 0){
						con.Close();
						return true;
					} else{
						con.Close();	
						return false;
					}
				} else {
					con.Close();
					return false;
				}
			} catch(Exception e){
				MessageBox.Show(e.Message);
				return false;
			}
		}

		public bool FindMatch(string Username, string Password){

			string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\Artsy.accdb";
			string sql = "SELECT * FROM [User] WHERE [UserName] = @Username AND [Password] = @Password;";

			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + CurrentPath;

			try{
				con.Open();
				OleDbCommand command = new OleDbCommand(sql, con);
				command.CommandType = CommandType.Text;
				command.Parameters.AddWithValue("@Username", Username);
				command.Parameters.AddWithValue("@Password", Password);
				command.ExecuteNonQuery();
				OleDbDataAdapter adapter = new OleDbDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				if(dt != null){
					if(dt.Rows.Count > 0){
						con.Close();
						return true;
					} else{
						con.Close();	
						return false;
					}
				} else {
					con.Close();
					return false;
				}
			} catch(Exception e){
				MessageBox.Show(e.Message);
				return false;
			}
		}

		public string GetUserID(){
			string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\Artsy.accdb";
			string sql = "SELECT UserID FROM [User] WHERE UserName = @Username AND Password = @Password;";

			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + CurrentPath;

			try{
				con.Open();
				OleDbCommand command = new OleDbCommand(sql, con);
				command.CommandType = CommandType.Text;
				command.Parameters.AddWithValue("@Username", Username);
				command.Parameters.AddWithValue("@Password", Password);
				command.ExecuteNonQuery();
				OleDbDataAdapter adapter = new OleDbDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				if(dt != null){
					if(dt.Rows.Count > 0){
						con.Close();
						return dt.Rows[0][0].ToString();
					} else{
						con.Close();	
						return "";
					}
				} else {
					con.Close();
					return "";
				}
			} catch(Exception e){
				MessageBox.Show(e.Message);
				return "";
			}
		}

		public void AddUser(string Username, string Password){
			string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\Artsy.accdb";
			string sql = "INSERT INTO [User]([UserName], [Password]) VALUES(@Username,@Password);";

			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + CurrentPath;

			try{				
				if(FindMatch(Username,Password)){
					MessageBox.Show("Account Already taken");
				} else {
					con.Open();
					OleDbCommand command = new OleDbCommand(sql, con);
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@Username", Username);
					command.Parameters.AddWithValue("@Password", Password);
					command.ExecuteNonQuery();
					MessageBox.Show("Inserted!");
				}
			} catch(Exception e){
				MessageBox.Show(e.Message);
			} finally{
				con.Close();
			}
		}
		
	}
}