/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Collection.cs
* Version     : v1.0
* Author      : Gensaya, Carl Jerwin F.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Artsy {

   public class MyCollection : Panel {

      public MyCollection() {
         DisplayMyCollection();
      }

    /*============================================================================*
     *  Function   : DisplayMyCollection
     *  Params     : None 
     *  Returns    : Void
     *  Description: This serves as the GUI panel for Artsy's users artworks.
     *=============================================================================*/

      void DisplayMyCollection() {

			DoubleBuffered = true;

         _SemiTransBg = new Label() {
            Tag = "transbg",
            Size = new Size(900, 440),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(90, Color.Black)
         };
         this.Controls.Add(_SemiTransBg);
         _SemiTransBg.Hide();
         _SemiTransBg.Click += new EventHandler(__ClickLabel);

         _MainContainer = new Panel() {
            AutoScroll = true,
				Size = new Size(910, 400),
            Location = new Point(0, 0),
         };
         this.Controls.Add(_MainContainer);

         for(int loop = 0; loop < _ArtWorkDayCount; loop++) {

            Label _ArtWorkLbl = new Label() {
               Size = new Size(150, 30),
               BackColor = Color.White,
               Font = new Font("Segoe UI", 10),
               TextAlign = ContentAlignment.MiddleCenter,
               Text = "September " + (69 + loop) + ", 2069",
               Location = new Point(10, 100 * loop)
            };
            _ArtWorkDate.Add(_ArtWorkLbl);
            _MainContainer.Controls.Add(_ArtWorkLbl);

            Panel _ArtWorkPnl = new Panel() {
               // X depends on the total x size of all artwork content on that day.
               AutoScroll = true,
               Size = new Size(840, 170),
               BackColor = Color.Gray,
               Location = new Point(10, 100 * loop),
            };
            _ArtWorks.Add(_ArtWorkPnl);
            _MainContainer.Controls.Add(_ArtWorkPnl);

            int _ArtWorkPnlX = 0;
            for(int iloop = 0; iloop < _ArtWorkCount; iloop++) {
               PictureBox _ArtBox = new PictureBox() {
                  Size = new Size(150, 150),
                  Image = Image.FromFile("res/bae.jpg"),
                  SizeMode = PictureBoxSizeMode.StretchImage,
                  Location = new Point(150 * iloop, 0)
               };
               _ArtBox.MouseEnter += new EventHandler(__GlobalMEnterPBox);
               _ArtBox.MouseLeave += new EventHandler(__GlobalMLeavePBox);
               _ArtBox.Click += new EventHandler(__GlobalClickPbox);
               _ArtWorkBox.Add(_ArtBox);
               _ArtWorkPnl.Controls.Add(_ArtBox);
               _ArtWorkPnlX += 150;
            }

            _ArtWorkCount++;
            if(_ArtWorkPnlX <= 840) {
               _ArtWorkPnl.Size = new Size(_ArtWorkPnlX, 150);
            } if(_ArtWorkCount > 5) {
               _ArtWorkLbl.Location = new Point(10, 20 + (240 * loop));
               _ArtWorkPnl.Location = new Point(10, 50 + (240 * loop));
            }
         }

         _ArtViewer = new Label() {
            Size = new Size(750, 400),
            BackColor = Color.Gray,
            Location = new Point(50, 10)
         };
         _SemiTransBg.Controls.Add(_ArtViewer);
         _ArtViewer.MouseEnter += new EventHandler(__CustomCursor);
         _MainContainer.KeyDown += __DetectKeyPress;
         _ArtViewer.MouseLeave += new EventHandler(__NormalCursor);

            _ActionHolder = new Label() {
               Size = new Size(750, 40),
               BackColor = Color.White,
               Location = new Point(0, 360)
            };
            _ArtViewer.Controls.Add(_ActionHolder);

            _ArtActions[0] = new Label() {
               AutoSize = true,
               Font = new Font("Segoe UI", 13, FontStyle.Bold),
               TextAlign = ContentAlignment.MiddleCenter,
               Text = "Art Name: Art Desc"
            };
            _ActionHolder.Controls.Add(_ArtActions[0]);

            for(int loop = 1; loop < 4; loop++) {
               _ArtActions[loop] = new Label() {
                  Size = new Size(50, 50),
                  BackColor = ColorTranslator.FromHtml("#5F9EA0"),
                  Text = "Act" + loop,
                  Font = new Font("Segoe UI", 10),
                  TextAlign = ContentAlignment.MiddleCenter,
                  Location = new Point(250 + (loop * 60), 0)
               };
               _ActionHolder.Controls.Add(_ArtActions[loop]);
            }

            _ArtActions[4] = new Label() {
               Tag = "Zoom",
               Size = new Size(50, 50),
               Font = new Font("Segoe UI", 10),
               BackColor = ColorTranslator.FromHtml("#5F9EA0"),
               TextAlign = ContentAlignment.MiddleCenter,
               Text = "♥",
               Location = new Point(600, 0)
            };
            _ActionHolder.Controls.Add(_ArtActions[4]);

            _ArtActions[5] = new Label() {
               Tag = "Hide",
               Size = new Size(50, 50),
               Font = new Font("Segoe UI", 10),
               BackColor = ColorTranslator.FromHtml("#5F9EA0"),
               TextAlign = ContentAlignment.MiddleCenter,
               Text = "▼",
               Location = new Point(660, 0)
            };
            _ActionHolder.Controls.Add(_ArtActions[5]);
            _ArtActions[5].Click += new EventHandler(__ClickLabel);

            _ArtViewFrame = new PictureBox() {
               Size = new Size(750, 450),
               SizeMode = PictureBoxSizeMode.StretchImage
            };
            _ArtViewer.Controls.Add(_ArtViewFrame);

            _ArtViewer.Controls.SetChildIndex(_ActionHolder, 1);
            _ArtViewer.Controls.SetChildIndex(_ArtViewFrame, 1);

            _ToggleMagnify = new Label() {
               Tag = "Zoom",
               AutoSize = true,
               BackColor = Color.FromArgb(100, Color.Gray),
               ForeColor = Color.Gray,
               Text = "Zoom",
               Font = new Font("Segoe UI", 12, FontStyle.Bold),
               Location = new Point(690, 10)
            };
            _ToggleMagnify.Click += new EventHandler(__ClickLabel);
            _ArtViewFrame.Controls.Add(_ToggleMagnify);

            _ShowTabAction = new Label() {
               Tag = "Show",
               Text = "▲",
               BackColor = Color.Black,
               ForeColor = Color.White,
               Size = new Size(50, 50),
               TextAlign = ContentAlignment.MiddleCenter,
               Location = new Point(660, 360)
            };
            _ShowTabAction.Hide();
            _ArtViewFrame.Controls.Add(_ShowTabAction);
            _ShowTabAction.Click += new EventHandler(__ClickLabel);

         _MagnifyForm = new Form() {
            FormBorderStyle = FormBorderStyle.None,
         };
         _MagnifyForm.Hide();

            _MagnifiedFrame = new PictureBox() {
               Size = new Size(250, 250)
            };
            _MagnifyForm.Controls.Add(_MagnifiedFrame);

         _ZoomTimer = new System.Timers.Timer() {
            Interval = 100,
            Enabled = false
         };

         _ArtOption[0] = new Label() {
            Size = new Size(40, 100),
            BackColor = Color.Red
         };
         _ArtOption[0].Hide();
         this.Controls.Add(_ArtOption[0]);

         _PrintScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

      }


    /*============================================================================*
     *  Function   : __GlobalPaintPBox
     *  Params     : object source - Component that triggered the event. 
                     PaintEventArgs pa  - Event Argument
     *  Returns    : Void
     *  Description: Provides colored border for the picture boxes.
     *=============================================================================*/
      void __GlobalPaintPBox(object source, PaintEventArgs pa) {
         var sender = source as PictureBox;
         Color BorderColor = ColorTranslator.FromHtml("#9E94DE"); // Change the fcking color if ya want.
         int BorderThickness = 3; // Change this too if ya want to.
         ControlPaint.DrawBorder(pa.Graphics, sender.DisplayRectangle,
                                 BorderColor, BorderThickness, ButtonBorderStyle.Solid,
                                 BorderColor, BorderThickness, ButtonBorderStyle.Solid,
                                 BorderColor, BorderThickness, ButtonBorderStyle.Solid,
                                 BorderColor, BorderThickness, ButtonBorderStyle.Solid);
      }

    /*============================================================================*
     *  Function   : __GlobalMEnterPBox
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs mea  - Event Argument
     *  Returns    : Void
     *  Description: Provides colored border for the picture boxes when hovered.
     *=============================================================================*/
      void __GlobalMEnterPBox(object source, EventArgs mea) {
         var sender = source as PictureBox;
         sender.Paint += new PaintEventHandler(__GlobalPaintPBox);
         sender.Refresh();

         _CollArtDetails = new Label() {
            Size = new Size(sender.Width, 15),
            Text = "ARTNAME | #Likes | #Comments",
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.Black,
            BackColor = Color.FromArgb(80, Color.Gray),
            Font = new Font("Helvetica", 7),
            Location = new Point(0, -15)
         };
         sender.Controls.Add(_CollArtDetails);

         new Thread(() => {
            for(int loop = 0; loop <= 15; loop++) {
               try {
                  _CollArtDetails.Location = new Point(0, - 15 + loop);
                  Thread.Sleep(1);
               } catch(Exception e) {
                  Console.WriteLine(e.ToString());
               }
            }
         }).Start();

      }

    /*============================================================================*
     *  Function   : __GlobalMLeavePBox
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs mla  - Event Argument
     *  Returns    : Void
     *  Description: Resets picture box appearance when mouse leaves the component.
     *=============================================================================*/
      void __GlobalMLeavePBox(object source, EventArgs mla) {
         var sender = source as PictureBox;
         sender.Paint -= new PaintEventHandler(__GlobalPaintPBox);
         sender.Refresh();
         _CollArtDetails.Hide();
      }

    /*============================================================================*
     *  Function   : __GlobalClickPbox
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ca  - Event Argument
     *  Returns    : Void
     *  Description: Enlarges image when clicked.
     *=============================================================================*/
      void __GlobalClickPbox(object source, EventArgs ca) {
         var sender = source as PictureBox;
         Bitmap pic = new Bitmap(sender.Image);
         _ArtViewFrame.Image = pic;
         _SemiTransBg.BringToFront();
         _SemiTransBg.Show();
      }

    /*============================================================================*
     *  Function   : __ClickLabel
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs cea  - Event Argument
     *  Returns    : Void
     *  Description: Triggers magnify feature for the picture that is selected.
     *=============================================================================*/
      void __ClickLabel(object source, EventArgs cea) {
         var sender = source as Label;

         if(sender.Tag.ToString() == "Zoom") {
               if(_ActionTabFlag == 0 && _ZoomFlag == 0) {
                  new Thread(() => {
                     for(int loop = 0; loop <= 40; loop += 2) {
                        _ActionHolder.SetBounds(0, 360 + loop, 750, 40);
                        Thread.Sleep(3);
                     }
                  }).Start(); _ActionTabFlag = 1; _ShowTabAction.Show();
               } else if(_ActionTabFlag == 1 && _ZoomFlag == 1) {
                  new Thread(() => {
                     for(int loop = 0; loop <= 40; loop += 2) {
                        _ActionHolder.SetBounds(0, 400 - loop, 750, 40);
                        Thread.Sleep(3);
                     }
                  }).Start(); _ActionTabFlag = 0; _ShowTabAction.Hide();
               }

               if(_ZoomFlag == 0) {
                  _ZoomTimer.Enabled = true;
                  _ZoomTimer.Elapsed += new ElapsedEventHandler(__DisplayMagnifiedFrame);
                  _MagnifyForm.Show();
                  _ZoomFlag = 1;
                  _ToggleMagnify.BackColor = Color.FromArgb(50, ColorTranslator.FromHtml("#FF7F50"));
                  _ToggleMagnify.ForeColor = Color.Black;
               } else {
                  _ZoomTimer.Enabled = false;
                  _ZoomTimer.Elapsed -= new ElapsedEventHandler(__DisplayMagnifiedFrame);
                  _MagnifyForm.Hide();
                  _ZoomFlag = 0;
                  _ToggleMagnify.BackColor = Color.Transparent;
                  _ToggleMagnify.ForeColor = Color.Gray;
               }
         } else if(sender.Tag.ToString() == "Hide") {
            if(_ActionTabFlag == 0) {
               new Thread(() => {
                  for(int loop = 0; loop <= 40; loop += 2) {
                     _ActionHolder.SetBounds(0, 360 + loop, 750, 40);
                     Thread.Sleep(3);
                  }
               }).Start(); _ActionTabFlag = 1; _ShowTabAction.Show();
            }
         } else if(sender.Tag.ToString() == "Show") {
            if(_ActionTabFlag == 1) {
               new Thread(() => {
                  for(int loop = 0; loop <= 40; loop += 2) {
                     _ActionHolder.SetBounds(0, 400 - loop, 750, 40);
                     Thread.Sleep(3);
                  }
               }).Start(); _ActionTabFlag = 0; _ShowTabAction.Hide();
            }
         } else if(sender.Tag.ToString() == "transbg") {
            _MagnifyForm.Hide();
            _SemiTransBg.Hide();
            this.AutoScroll = true;
         }
      }

    /*============================================================================*
     *  Function   : __CustomCursor
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs mea  - Event Argument
     *  Returns    : Void
     *  Description: Changes mouse pointer when inside a picture box.
     *=============================================================================*/
      void __CustomCursor(object source, EventArgs mea) {
         // Add custom cursor.
         //Cursor myCursor = new Cursor("myCursor.cur");
         //myControl.Cursor = myCursor;
         var sender = source as PictureBox;
         sender.Paint += new PaintEventHandler(__GlobalPaintEvent);
         sender.Refresh();

         Point location = sender.Location;
         _ArtOption[0].Show();
         new Thread(() => {

            _ArtOption[0].SetBounds(location.X - 40, location.Y, 40, 100);

            for(int loop = 0; loop <= 40; loop += 5) {
               _ArtOption[0].SetBounds(location.X + 60 + loop, location.Y, 40, 100);
               Thread.Sleep(1);
            }
         }).Start();

         _ZoomTimer.Elapsed += new ElapsedEventHandler(__DisplayMagnifiedFrame);
         this.Cursor = Cursors.Hand;
      }

    /*============================================================================*
     *  Function   : __NormalCursor
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs mla  - Event Argument
     *  Returns    : Void
     *  Description: Resets mouse pointer when mouse leaves the picture box.
     *=============================================================================*/
      void __NormalCursor(object source, EventArgs mla) {
         var sender = source as PictureBox;
         sender.Paint -= new PaintEventHandler(__GlobalPaintEvent);
         sender.Refresh();

         Point location = sender.Location;
         new Thread(() => {
            for(int loop = 0; loop <= 40; loop += 5) {
               _ArtOption[0].SetBounds(location.X + 100 - loop, location.Y, 40, 100);
               Thread.Sleep(1);
            }
         }).Start();

         this.Cursor = Cursors.Default;
         _ZoomTimer.Elapsed -= new ElapsedEventHandler(__DisplayMagnifiedFrame);
         _MagnifyForm.Hide();
      }

    /*============================================================================*
     *  Function   : __DetectKeyPress
     *  Params     : object source  - Component that triggered the event. 
                     EventArgs kea  - Event Argument
     *  Returns    : Void
     *  Description: Hides artwork panel and turns off zoom function.
     *=============================================================================*/
      void __DetectKeyPress(object source, KeyEventArgs kea) {
         if(kea.KeyCode == Keys.Escape) {
            _MagnifyForm.Hide();
            _SemiTransBg.Hide();
         }
      }

    /*============================================================================*
     *  Function   : __DisplayMagnifiedFrame
     *  Params     : object source  - Component that triggered the event. 
                     ElapsedEventArgs eea  - Event Argument
     *  Returns    : Void
     *  Description: Displays magnified frame display of the picture.
     *=============================================================================*/
      void __DisplayMagnifiedFrame(object source, ElapsedEventArgs eea) {
         var graphics = Graphics.FromImage(_PrintScreen as Image);
         graphics.CopyFromScreen(0, 0, -30, 0, _PrintScreen.Size);
         var position = Cursor.Position;
         var MagniLens = new Bitmap(100, 100); // Have a bitmap for lens
         var RowCount = 0; // Variable for RowLoop count
         var ColumnCount = 0; // Variable for ColumnLoop count
         for (int RowLoop = position.X - 50; RowLoop < position.X + 50; RowLoop++) // Indicates RowLoop number
         {
               ColumnCount = 0; // Set ColumnLoop value '0' for new ColumnLoop
               for (int ColumnLoop = position.Y - 50; ColumnLoop < position.Y + 50; ColumnLoop++) // Indicate ColumnLoop number
               {
                    MagniLens.SetPixel(RowCount, ColumnCount, _PrintScreen.GetPixel(RowLoop, ColumnLoop)); // Place current region pixel to lens bitmap
                    ColumnCount++; // Increase RowLoop count
               }
               RowCount++; // Increase ColumnLoop count
           }
           _MagnifiedFrame.Image = new Bitmap(MagniLens, MagniLens.Width * zoom, MagniLens.Height * zoom); // Assign lens bitmap with zoom level to the picture box
           _MagnifyForm.Size = new Size(250, 250);
           _MagnifyForm.Left = position.X + 15; // Place form nearer to cursor X value
           _MagnifyForm.Top = position.Y + 15; // Place form nearer to cursor Y value
           _MagnifyForm.TopMost = true; // Keep the form top level
      }

    /*============================================================================*
     *  Function   : __GlobalPaintEvent
     *  Params     : object source  - Component that triggered the event. 
                     PaintEventArgs pea
     *  Returns    : Void
     *  Description: Provides colored border for the picture boxes.
     *=============================================================================*/
      void __GlobalPaintEvent(object source, PaintEventArgs pea) {
         var sender = source as PictureBox;
         ControlPaint.DrawBorder(pea.Graphics, sender.DisplayRectangle,
                                 ColorTranslator.FromHtml("#FF9D26"), 2, ButtonBorderStyle.Solid,
                                 ColorTranslator.FromHtml("#FF9D26"), 2, ButtonBorderStyle.Solid,
                                 ColorTranslator.FromHtml("#FF9D26"), 0, ButtonBorderStyle.Solid,
                                 ColorTranslator.FromHtml("#FF9D26"), 2, ButtonBorderStyle.Solid);
      }

      /*==============================INITIALIZATION==============================*/
      // Number depends on user's data.
      List<Label> _ArtWorkDate = new List<Label>();
      List<Panel> _ArtWorks = new List<Panel>();
      List<PictureBox> _ArtWorkBox = new List<PictureBox>();
      // The variable name explains it all.
      static int _ArtWorkDayCount = 10;
      // Number of artworks uploaded on that day.
      static int _ArtWorkCount = 5;

      Panel _MainContainer;
      Label[] _ArtOption = new Label[4];
      PictureBox[] _ArtHolder = new PictureBox[2];
      Label _SemiTransBg;
      Label _ArtViewer;
         public PictureBox _ArtViewFrame;
         Label _ActionHolder;
         Label[] _ArtActions = new Label[6];
         Label _ToggleMagnify;
         Label _ShowTabAction;
      Form _MagnifyForm;
         PictureBox _MagnifiedFrame;
         int zoom = 5;
      Bitmap _PrintScreen;
      System.Timers.Timer _ZoomTimer;
      static int _ZoomFlag = 0;
      static int _ActionTabFlag = 0;

      Label _CollArtDetails;

   }
}
