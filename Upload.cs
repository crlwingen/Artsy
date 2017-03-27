/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Upload.cs
* Version     : v1.0
* Author      : Gensaya, Carl Jerwin F.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace Artsy {
   public class UploadTemp : Form {

      public static void Main(String[] args) {
         Application.Run(new UploadTemp());
      }

      public UploadTemp() {
         DisplayUpload();
      }

      /*============================================================================*
        *  Function   : DisplayUpload
        *  Params     : None 
        *  Returns    : Void
        *  Description: Test cs file for image uploading.
        *=============================================================================*/
      void DisplayUpload() {
         Size = new Size(900, 600); StartPosition = FormStartPosition.CenterScreen;
         BackColor = Color.White; AutoScroll = true;

         Button Btn = new Button() {
            Size = new Size(150, 150),
            Location = new Point(10, 10),
            Text = "!!!"
         };
         Btn.Click += new EventHandler(TestClick);
         this.Controls.Add(Btn);

         Button Save = new Button() {
          Size = new Size(150, 150),
          Location = new Point(10, 200),
          Text = "SAVE"
         };
         Save.Click += new EventHandler(TestClick);
         this.Controls.Add(Save);

         Pbx = new PictureBox() {
            Size = new Size(300, 300),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new Point(170, 10)
         };
         this.Controls.Add(Pbx);

      }

      void TestClick(object source, EventArgs ca) {

        var sender = source as Button;

        if(sender.Text == "SAVE"){
          if(pic != null){
            Artwork upload = new Artwork();
            string CurrentPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DB\";
            pic.Save(CurrentPath + upload.AddArtwork(30,".png"), ImageFormat.Png);
            MessageBox.Show("Image successfully uploaded");
          }
        } else {
          OpenFileDialog _OFDialog = new OpenFileDialog() {
           InitialDirectory = @"C:\",
           Title = "Locate your artwork",
           CheckFileExists = true,
           CheckPathExists = true,
           Filter = "All Pictures (*.jpg, *.png, *.jpeg, *.bmp)|*.jpg; *.png; *.jpeg; *.bmp",
           RestoreDirectory = true,
           ReadOnlyChecked = true,
           ShowReadOnly = true,
        };

         if (_OFDialog.ShowDialog() == DialogResult.OK) {
            pic = new Bitmap(_OFDialog.FileName);
            Pbx.Size = pic.Size;
            Pbx.Image = new Bitmap(_OFDialog.FileName);
          }
        }
      }

      /*==============================INITIALIZATION==============================*/
      PictureBox Pbx;
      Bitmap pic;

   }
}
