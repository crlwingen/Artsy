/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Artwork.cs
* Version     : v1.0
* Author      : Batan, John Aldrin B,
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

	/*============================================================================*
     *  Function   : Artwork
     *  Params     : None 
     *  Returns    : Void
     *  Description: This serves as the GUI panel for Artsy's rules and regulations.
                     (Credits to E-bay for the rules that I used.)
     *=============================================================================*/
	public class Artwork {

		public string ArtworkID{
			get;
			set;
		}

		public string UserID{
			get;
			set;
		}

		public string DatePosted{
			get;
			set;
		}

		public string Caption{
			get;
			set;
		}

		public string ImageAddress{
			get;
			set;
		}

		public bool IsForSale{
			get;
			set;
		}

		public string Category{
			get;
			set;
		}
		/*
		public Artwork(ArtworkID, UserID, DatePosted, Caption, ImageAddress, Category, IsForSale) {
			this.ArtworkID = ArtworkID;
			this.UserID = UserID;
			this.DatePosted = DatePosted;
			this.Caption = Caption;
			this.ImageAddress = ImageAddress;
			this.IsForSale = IsForSale;
			this.Category = Category;
		}
		*/

		public string AddArtwork(int UserID, string Filename){
			string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\Artsy.accdb";
			string file = "";
			string sql = "INSERT INTO Artwork(UserID,DatePosted,Caption,ImageAddress,CategoryID) VALUES(@UserID,#"+DateTime.Now.Date.ToShortDateString()+"#,'HEY',@Filename,1);";
			string sql2 = "SELECT ArtworkID FROM Artwork ORDER BY ArtworkID DESC";

			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + CurrentPath;

			try{
				con.Open();
				OleDbCommand command = new OleDbCommand(sql2,con);

				command.CommandType = CommandType.Text;
				OleDbDataAdapter adapater = new OleDbDataAdapter(command);
				var result = command.ExecuteReader(CommandBehavior.SingleRow);
				if(result.Read()){
					Console.WriteLine(result.GetValue(0).ToString());
					file = "uploads/" + result.GetValue(0).ToString() + UserID + Filename;
					Console.WriteLine(result.GetValue(0).ToString());
				}
				result.Close();
				con.Close();
				con.Open();
				OleDbCommand command1 = new OleDbCommand(sql,con);
				command1.Parameters.AddWithValue("@UserID", UserID);
				command1.Parameters.AddWithValue("@Filename", file);
				command1.ExecuteNonQuery();
				//command.Parameters.AddWithValue("@DatePosted", DateTime.Now.Date.ToShortDateString());
				MessageBox.Show("Inserted!");
			} catch(Exception e){
				MessageBox.Show(e.Message);
			} finally{
				con.Close();
			}

			return file;
		}
	}
}