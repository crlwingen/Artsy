/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : login.cs
* Version     : v1.0
* Author      : Batan, John Aldrin B.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Artsy {
   public class Login : Form {

      // Main
      public static void Main(String [] args) {
         Application.Run(new Login());
      }

      public Login() {
         __DisplayArtLogin();
      }

       /*============================================================================*
        *  Function   : __DisplayArtLogin
        *  Params     : None 
        *  Returns    : Void
        *  Description: The page that shows at the program startup. Registration and
                        search is included in this part of the program.
        *=============================================================================*/
      void __DisplayArtLogin() {

         // Form Properties
         ShowIcon = false;
         Text = "Artsy";
         Size = new Size(900, 600);
         StartPosition = FormStartPosition.CenterScreen;
         BackColor = Color.FromArgb(11, 91, 65);
         MinimumSize = new Size(900, 600);
         MaximizeBox = false;
         SizeChanged += new EventHandler(__Resized);

         // BgTimer
         System.Timers.Timer _BgTimer = new System.Timers.Timer();
         _BgTimer.Interval = 500;
         _BgTimer.Enabled  = true;
         _BgTimer.Elapsed += new ElapsedEventHandler(__BgChange);

         _MainPanel =  new Panel() {
            Size = new Size(850, 500),
            BackColor = Color.Transparent
         };
         _MainPanel.Left = (this.ClientSize.Width - _MainPanel.Width) / 2 ;
         _MainPanel.Top = (this.ClientSize.Height - _MainPanel.Height) / 2;
         _MainPanel.MouseEnter += new EventHandler(__ActContLeave);
         this.Controls.Add(_MainPanel);

         _FeatHL = new Label() {
            Size = new Size(280, 10),
            BackColor = Color.FromArgb(90, Color.Yellow),
         };
         _FeatHL.Hide();
         _MainPanel.Controls.Add(_FeatHL);

         // Action Container
         _ActContPnl = new Panel() {
            Size = new Size(150, 150),
            Location = new Point(100, 100),
            BackColor = Color.Red
         };
         _MainPanel.Controls.Add(_ActContPnl);
         _ActContPnl.BringToFront();

            // Hovered Buttons
            _ActContBtn[0] = new Label() {
               Size = new Size(150, 40),
               TextAlign = ContentAlignment.MiddleCenter,
               Location = new Point(100, 100),
               Font = new Font("Helvetica", 13, FontStyle.Regular),
               BackColor = Color.Black,
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Text = "L O G I N"
            };
            _ActContBtn[0].Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
            _ActContBtn[0].Click += new EventHandler(__GlobalClickFilterLbl);
            _MainPanel.Controls.Add(_ActContBtn[0]);

                  _LoginTxt[0] = new TextBox() {
                     Tag = "LogTxt1",
                     Size = new Size(150, 40),
                     Location = new Point(100, 100),
                     Font = new Font("Helvetica", 25),
                     ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
                     BackColor = Color.Black,
                     BorderStyle = BorderStyle.None,
                     Text = "Username"
                  };
                  _MainPanel.Controls.Add(_LoginTxt[0]);
                  _LoginTxt[0].Paint += new PaintEventHandler(__GlobalNeonBorderTxt);
                  _LoginTxt[0].GotFocus += __GlobalTxtGotFocus;
                  _LoginTxt[0].LostFocus += __GlobalTxtLostFocus;

                  _LoginTxt[1] = new TextBox() {
                     Tag = "LogTxt2",
                     Size = new Size(150, 40),
                     Location = new Point(100, 140),
                     ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
                     BackColor = Color.Black,
                     Font = new Font("Helvetica", 25),
                     BorderStyle = BorderStyle.None,
                     Text = "Password"
                  };
                  _MainPanel.Controls.Add(_LoginTxt[1]);
                  _LoginTxt[1].Paint += new PaintEventHandler(__GlobalNeonBorderTxt);
                  _LoginTxt[1].GotFocus += __GlobalTxtGotFocus;
                  _LoginTxt[1].LostFocus += __GlobalTxtLostFocus;

            _ActContBtn[1] = new Label() {
               Size = new Size(150, 40),
               TextAlign = ContentAlignment.MiddleCenter,
               Location = new Point(100, 210),
               BackColor = Color.Black,
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Text = "R E G I S T E R",
               Font = new Font("Helvetica", 13, FontStyle.Regular)
            };

            _ActContBtn[1].Click += new EventHandler(__GlobalClickFilterLbl);
            _ActContBtn[1].Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
            _MainPanel.Controls.Add(_ActContBtn[1]);

            _ActContBtn[2] = new Label() {
               Size = new Size(40, 150),
               TextAlign = ContentAlignment.MiddleCenter,
               Location = new Point(100, 100),
               BackColor = Color.Black,
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Text = "?",
               Font = new Font("Helvetica", 13, FontStyle.Regular)
            };
            _ActContBtn[2].Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
            _ActContBtn[2].Click += new EventHandler(__GlobalClickFilterLbl);
            _MainPanel.Controls.Add(_ActContBtn[2]);

            _LoginBtn = new Button() {
               Tag = "LogBtn",
               Size = new Size(150, 70),
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               BackColor = Color.Black,
               FlatStyle = FlatStyle.Flat,
               Font = new Font("Helvetica", 13, FontStyle.Regular),
               Location= new Point(100, 180)
            };
            _MainPanel.Controls.Add(_LoginBtn);
            _LoginBtn.Click += new EventHandler(__GlobalBtnClicked);

            _CompanyName = new Label() {
               Size = new Size(450, 100),
               BackColor = Color.Black,
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
               TextAlign = ContentAlignment.MiddleCenter,
               Font = new Font("Helvetica", 25, FontStyle.Regular),
               Text = "C O M P A N Y  N A M E",
               Location = new Point(50, 400)
            };

            _CompanyName.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);

            _MainPanel.Controls.Add(_CompanyName);

            _AppLogoLbl = new Label() {
               Size = new Size(150, 150),
               BackColor = Color.Black,
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Text = "\" L O G O \"",
               TextAlign = ContentAlignment.MiddleCenter,
               Font = new Font("Helvetica", 15, FontStyle.Regular),
            };
            _AppLogoLbl.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
            _AppLogoLbl.MouseEnter += new EventHandler(__ActContHover);
            _ActContPnl.Controls.Add(_AppLogoLbl);

         _FeatArtPnl[0] = new Panel() {
            Tag = "Feat1",
            Size = new Size(280, 220),
            Anchor = AnchorStyles.Right | AnchorStyles.Top,
            BackColor = Color.Black,
            Location = new Point(550, 50)
         };

            _FeatArtBox[0] = new PictureBox {
               Size = new Size(280, 150),
               SizeMode = PictureBoxSizeMode.StretchImage,
               Image = Image.FromFile("res/art2.jpg")
            };
            _FeatArtPnl[0].Controls.Add(_FeatArtBox[0]);
            _FeatArtBox[0].MouseEnter += new EventHandler(__PictureBoxEnter);
            _FeatArtBox[0].MouseLeave += new EventHandler(__PictureBoxLeave);

            _FeatArtCont[0] = new Label() {
               AutoSize = true,
               Text = "Featured Art #1 Description",
               Font = new Font("Helvetica", 13, FontStyle.Regular),
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Location = new Point(20, 170),
            };
            _FeatArtPnl[0].Controls.Add(_FeatArtCont[0]);
            _FeatArtCont[0].MouseEnter += new EventHandler(__LabelEnter);
            _FeatArtCont[0].MouseLeave += new EventHandler(__LabelLeave);

         _FeatArtPnl[1] = new Panel() {
            Tag       = "Feat2",
            Anchor    = AnchorStyles.Right | AnchorStyles.Top,
            Size      = new Size(280, 220),
            BackColor = Color.Black,
            Location  = new Point(550, 280)
         };

         _FeatArtBox[1] = new PictureBox {
            Size = new Size(280, 150),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Image = Image.FromFile("res/Spo.jpg")
         };
         _FeatArtPnl[1].Controls.Add(_FeatArtBox[1]);
         _FeatArtBox[1].MouseEnter += new EventHandler(__PictureBoxEnter);
         _FeatArtBox[1].MouseLeave += new EventHandler(__PictureBoxLeave);

            _FeatArtCont[1] = new Label() {
               AutoSize = true,
               Text = "Featured Art #2 Description",
               Font = new Font("Helvetica", 13, FontStyle.Regular),
               ForeColor = ColorTranslator.FromHtml("#F6FFFF"),
               Location = new Point(20, 170),
            };
            _FeatArtPnl[1].Controls.Add(_FeatArtCont[1]);
            _FeatArtCont[1].MouseEnter += new EventHandler(__LabelEnter);
            _FeatArtCont[1].MouseLeave += new EventHandler(__LabelLeave);

            _RegisterLbl = new Label() {
               Tag = "RegLbl",
               Location = new Point(550, 50),
               Anchor = AnchorStyles.Right | AnchorStyles.Top,
               BackColor = Color.Black,
               Size = new Size(280, 450)
            };
            _RegisterLbl.Hide();
            _RegisterLbl.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);

               _RegisterMes = new Label() {
                  AutoSize = true,
                  Text = "Join Artsy today. [Logo]",
                  Font = new Font("Segoe UI", 15),
                  ForeColor = Color.White,
                  Location = new Point(20, 40)
               };
               _RegisterLbl.Controls.Add(_RegisterMes);

               _RegisterBox[0] = new TextBox() {
                  Tag = "RegFullName",
                  Size = new Size(220, 40),
                  Text = "Full Name",
                  Font = new Font("Segoe UI", 15),
                  BackColor = Color.White,
                  Location = new Point(20, 100)
               };
               _RegisterBox[0].GotFocus += __GlobalTxtGotFocus;
               _RegisterBox[0].LostFocus += __GlobalTxtLostFocus;
               _RegisterLbl.Controls.Add(_RegisterBox[0]);

               _RegisterBox[1] = new TextBox() {
                  Tag = "RegEmail",
                  Size = new Size(220, 40),
                  Text = "Email",
                  Font = new Font("Segoe UI", 15),
                  BackColor = Color.White,
                  Location = new Point(20, 160)
               };
               _RegisterBox[1].GotFocus += __GlobalTxtGotFocus;
               _RegisterBox[1].LostFocus += __GlobalTxtLostFocus;
               _RegisterLbl.Controls.Add(_RegisterBox[1]);

               _RegisterBox[2] = new TextBox() {
                  Tag = "RegPass",
                  Size = new Size(220, 40),
                  Text = "Password",
                  Font = new Font("Segoe UI", 15),
                  Location = new Point(20, 220)
               };
               _RegisterBox[2].GotFocus += __GlobalTxtGotFocus;
               _RegisterBox[2].LostFocus += __GlobalTxtLostFocus;
               _RegisterLbl.Controls.Add(_RegisterBox[2]);

               _RegisterBtn = new Button() {
                  Tag = "RegBtn",
                  Size = new Size(220, 40),
                  Text = "Sign me up.",
                  TextAlign = ContentAlignment.MiddleCenter,
                  Font = new Font("Segoe UI", 15),
                  BackColor = Color.Black,
                  ForeColor = Color.White,
                  Location = new Point(20, 280),
                  FlatStyle = FlatStyle.Flat
               };
               _RegisterLbl.Controls.Add(_RegisterBtn);
               _RegisterBtn.Click += new EventHandler(__GlobalBtnClicked);

               _RegisterAgree = new Label() {
                  Size = new Size(220, 80),
                  Text = "By signing up, you agree to the Terms of Service and Privacy Policy. Others will be able to find you by email when provided.",
                  Font = new Font("Segoe UI", 8),
                  ForeColor = Color.White,
                  Location = new Point(27, 340)
               };
               _RegisterLbl.Controls.Add(_RegisterAgree);

            _SearchLbl = new Label() {
               Tag = "SrcLbl",
               Anchor = AnchorStyles.Right | AnchorStyles.Top,
               Location = new Point(550, 50),
               BackColor = Color.Black,
               Size = new Size(280, 450)
            };
            _SearchLbl.Hide();
            _SearchLbl.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);

               _SearchBox = new TextBox() {
                  Tag = "SeaSearch",
                  Size = new Size(175, 40),
                  Text = "Search something",
                  Font = new Font("Segoe UI", 15),
                  BackColor = Color.White,
                  Location = new Point(20, 20)
               };
               _SearchLbl.Controls.Add(_SearchBox);
               _SearchBox.GotFocus += __GlobalTxtGotFocus;
               _SearchBox.LostFocus += __GlobalTxtLostFocus;

               _SearchBtn = new Button() {
                  Tag = "SeaBtn",
                  Size = new Size(60, 35),
                  Text = "OK",
                  Font = new Font("Segoe UI", 14),
                  Location = new Point(200, 20),
                  FlatStyle = FlatStyle.Flat,
                  ForeColor = Color.White
               };
               _SearchLbl.Controls.Add(_SearchBtn);
               _SearchBtn.Click += new EventHandler(__GlobalBtnClicked);


               _SearchMess = new Label() {
                  MaximumSize = new Size(220, 0),
                  AutoSize = true,
                  Text = "Some info are not shown in this search. To view it all, login your account.",
                  Font = new Font("Segoe UI", 8),
                  ForeColor = Color.White,
                  Location = new Point(20, 60)
               };
               _SearchLbl.Controls.Add(_SearchMess);

               _SearchArtPnl = new Panel() {
                  AutoScroll = true,
                  Size = new Size(300, 340),
                  BackColor = Color.Transparent,
                  Location = new Point(0, 100)
               };
               _SearchLbl.Controls.Add(_SearchArtPnl);

            this.Controls.Add(bas);

            bas.Hide();

            _MainPanel.Controls.Add(_SearchLbl);
            _MainPanel.Controls.Add(_RegisterLbl);
            _MainPanel.Controls.Add(_FeatArtPnl[0]);
            _MainPanel.Controls.Add(_FeatArtPnl[1]);

            _MainPanel.Controls.SetChildIndex(_SearchLbl, 1);
            _MainPanel.Controls.SetChildIndex(_RegisterLbl, 1);

      }

    /*============================================================================*
     *  Function   : __GlobalNeonBorderLbl
     *  Params     : object source - Component that triggered the event. 
                     PaintEventArgs pea - Event Argument
     *  Returns    : Void
     *  Description: Provides neon colored border for the labels.
     *=============================================================================*/
      void __GlobalNeonBorderLbl(object source, PaintEventArgs pea) {

         var sender = source as Label;

         if(sender.Text == "\" L O G O \"")
            ControlPaint.DrawBorder(pea.Graphics, _AppLogoLbl.DisplayRectangle,
                                    ColorTranslator.FromHtml("#ff1aff"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#ff1aff"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#ff1aff"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#ff1aff"), 3, ButtonBorderStyle.Solid);

         else if(sender.Text == "C O M P A N Y  N A M E")
            ControlPaint.DrawBorder(pea.Graphics, _CompanyName.DisplayRectangle,
                                    ColorTranslator.FromHtml("#7FFF00"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#7FFF00"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#7FFF00"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#7FFF00"), 3, ButtonBorderStyle.Solid);

         else if(sender.Text == "L O G I N")
            ControlPaint.DrawBorder(pea.Graphics, _ActContBtn[0].DisplayRectangle,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid);

         else if(sender.Text == "R E G I S T E R")
            ControlPaint.DrawBorder(pea.Graphics, _ActContBtn[1].DisplayRectangle,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid);

         else if(sender.Text == "?")
            ControlPaint.DrawBorder(pea.Graphics, _ActContBtn[2].DisplayRectangle,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#2eb8b3"), 3, ButtonBorderStyle.Solid);

         else if(sender.Tag.ToString() == "RegLbl")
            ControlPaint.DrawBorder(pea.Graphics, _RegisterLbl.DisplayRectangle,
                                    ColorTranslator.FromHtml("#FFDF33"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#FFDF33"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#FFDF33"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#FFDF33"), 3, ButtonBorderStyle.Solid);

         else if(sender.Tag.ToString() == "SrcLbl")
            ControlPaint.DrawBorder(pea.Graphics, _SearchLbl.DisplayRectangle,
                                    ColorTranslator.FromHtml("#E86680"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#E86680"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#E86680"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#E86680"), 3, ButtonBorderStyle.Solid);

      }

    /*============================================================================*
     *  Function   : __GlobalTxtGotFocus
     *  Params     : object source - Component that triggered the event. 
                     EventArgs gfe - Event Argument
     *  Returns    : Void
     *  Description: Removes textbox place holder when on focus.
     *=============================================================================*/
      void __GlobalTxtGotFocus(object source, EventArgs gfe) {

         var sender = source as TextBox;

         if(sender.Tag.ToString() == "LogTxt2") { sender.PasswordChar = '•'; }

         if(sender.Tag.ToString() == "LogTxt1" && sender.Text == "Username") {
            sender.Text = "";
         } else if(sender.Tag.ToString() == "LogTxt2" && sender.Text == "Password") {
            sender.Text = "";
         } else if(sender.Tag.ToString() == "RegFullName" && sender.Text == "Full Name") {
            sender.Text = "";
         } else if(sender.Tag.ToString() == "RegEmail" && sender.Text == "Email") {
            sender.Text = "";
         } else if(sender.Tag.ToString() == "RegPass" && sender.Text == "Password") {
            sender.Text = "";
            sender.PasswordChar = '•';
         } else if(sender.Tag.ToString() == "SeaSearch" && sender.Text == "Search something") {
            sender.Text = "";
         }
      }

    /*============================================================================*
     *  Function   : __GlobalTxtLostFocus
     *  Params     : object source - Component that triggered the event. 
                     EventArgs gfe - Event Argument
     *  Returns    : Void
     *  Description: Puts placeholder back on text box when it loses focus.
     *=============================================================================*/
      void __GlobalTxtLostFocus(object source, EventArgs gfe) {

         var sender = source as TextBox;

         if(sender.Tag.ToString() == "LogTxt1" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Username";
         } else if(sender.Tag.ToString() == "LogTxt2" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Password";
            sender.PasswordChar = '\0';
         } else if(sender.Tag.ToString() == "RegFullName" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Full Name";
         } else if(sender.Tag.ToString() == "RegEmail" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Email";
         } else if(sender.Tag.ToString() == "RegPass" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Password";
            sender.PasswordChar = '\0';
         } else if(sender.Tag.ToString() == "SeaSearch" && String.IsNullOrEmpty(sender.Text)) {
            sender.Text = "Search something.";
         }
      }

    /*============================================================================*
     *  Function   : __BgChange
     *  Params     : object source - Component that triggered the event. 
                     ElapsedEventArgs eea - Event Argument
     *  Returns    : Void
     *  Description: Changes panel background over time.
     *=============================================================================*/
      void __BgChange(object source, ElapsedEventArgs eea) {

         new Thread(() => {
            if(_TimerCount % 2 == 0) {
               _AppLogoLbl.Paint -= new PaintEventHandler(__GlobalNeonBorderLbl);
            }
         }).Start(); _AppLogoLbl.Refresh();
         _AppLogoLbl.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
         _AppLogoLbl.Refresh();

         new Thread(() => {
            if(_TimerCount % 8 == 1) {
               _CompanyName.Paint -= new PaintEventHandler(__GlobalNeonBorderLbl);
            } else if(_TimerCount % 2 == 0) {
               _CompanyName.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
            }
         }).Start(); _CompanyName.Refresh();
         _TimerCount++;
      }

    /*============================================================================*
     *  Function   : __GlobalNeonBorderPnl
     *  Params     : object source - Component that triggered the event. 
                     PaintEventArgs pea - Event Argument
     *  Returns    : Void
     *  Description: Provides blinking neon colored border for the logo 
                     (still has a bug lol).
     *=============================================================================*/
      void __GlobalNeonBorderPnl(object source, PaintEventArgs pea) {

         var sender = source as Panel;

         if(sender.Tag.ToString() == "Feat1")
            ControlPaint.DrawBorder(pea.Graphics, _FeatArtPnl[0].DisplayRectangle,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid);

         else if(sender.Tag.ToString() == "Feat2")
            ControlPaint.DrawBorder(pea.Graphics, _FeatArtPnl[0].DisplayRectangle,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid);

      }

    /*============================================================================*
     *  Function   : __GlobalNeonBorderTxt
     *  Params     : object source - Component that triggered the event. 
                     PaintEventArgs pea - Event Argument
     *  Returns    : Void
     *  Description: Provides neon colored border for textboxes.
     *=============================================================================*/
      void __GlobalNeonBorderTxt(object source, PaintEventArgs pea) {

         var sender = source as TextBox;

         if(sender.Tag.ToString() == "LogTxt1") {
            ControlPaint.DrawBorder(pea.Graphics, _LoginTxt[0].DisplayRectangle,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid);
         } else if(sender.Tag.ToString() == "LogTxt2") {
            ControlPaint.DrawBorder(pea.Graphics, _LoginTxt[1].DisplayRectangle,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#9E94DE"), 3, ButtonBorderStyle.Solid);
         }
      }

    /*============================================================================*
     *  Function   : __ActContHover
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ea - Event Argument
     *  Returns    : Void
     *  Description: Show animation for the textboxes.
     *=============================================================================*/
      void __ActContHover(object source, EventArgs ea) {

         if(_MidFlag == 0) {
            new Thread(() => {
               for(int loop = 0; loop < 42; loop += 2) {
                  try {
                     if(_LoginFlag == 0) _ActContBtn[0].SetBounds(100, 100 - loop, 150, 40);
                     if(_RegisterFlag == 0) _ActContBtn[1].SetBounds(100, 210 + loop, 150, 40);
                     if(_SearchFlag == 0) _ActContBtn[2].SetBounds(100 - loop, 100, 40, 150);
                     Thread.Sleep(2);
                  } catch(Exception e) {
                     Console.WriteLine(e.ToString());
                  }
               }
            }).Start(); _MidFlag++;
         }
      }

    /*============================================================================*
     *  Function   : __ActContLeave
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ea  - Event Argument
     *  Returns    : Void
     *  Description: Hide animation for the textboxes.
     *=============================================================================*/
      void __ActContLeave(object source, EventArgs ea) {

         if(_MidFlag == 1) {
            new Thread(() => {
               for(int loop = 0; loop <= 40; loop += 2) {
                  try {
                     if(_LoginFlag == 0) _ActContBtn[0].SetBounds(100, 60 + loop, 150, 40);
                     if(_RegisterFlag == 0) _ActContBtn[1].SetBounds(100, 250 - loop, 150, 40);
                     if(_SearchFlag == 0) _ActContBtn[2].SetBounds(60 + loop, 100, 40, 150);
                     Thread.Sleep(2);
                  } catch(Exception e) {
                     Console.WriteLine(e.ToString());
                  }
               }
            }).Start(); _MidFlag--;
         }
      }

    /*============================================================================*
     *  Function   : __GlobalClickFilterLbl
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ca  - Event Argument
     *  Returns    : Void
     *  Description: Shows/hides assigned panel for the labels.
     *=============================================================================*/
      void __GlobalClickFilterLbl(object source, EventArgs ce) {

         var sender = source as Label;

         if(sender.Text == "L O G I N") {
            if(_LoginFlag == 0) {
               new Thread(() => {
                  for(int loop = 0; loop <= 160; loop += 5) {
                     try {
                        _LoginTxt[0].SetBounds(100 + loop, 100, 150, 40);
                        _LoginTxt[1].SetBounds(100 + loop, 140, 150, 40);
                        _LoginBtn.Text = "OK";
                        _LoginBtn.SetBounds(100 + loop, 180, 150, 70);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
               }).Start();
               _LoginFlag = 1;
               _RegisterFlag = 0;
               _SearchFlag = 0;
               _RegisterLbl.Hide();
               _SearchLbl.Hide();
            } else if(_LoginFlag == 1) {
               new Thread(() => {
                  for(int loop = 0; loop <= 150; loop += 5) {
                     try {
                        _LoginTxt[0].SetBounds(250, 100, 150 - loop, 40);
                        _LoginTxt[1].SetBounds(250, 140, 150 - loop, 40);
                        _LoginBtn.Text = "OK";
                        _LoginBtn.SetBounds(250 - loop, 180, 150, 70);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
                  _LoginTxt[0].Text = "Username";
                  _LoginTxt[1].Text = "Password";
                  _LoginTxt[1].PasswordChar = '\0';
               }).Start();
               _LoginFlag = 0;
            }
         } else if(sender.Text == "R E G I S T E R") {
            if(_LoginFlag == 1) {
               new Thread(() => {
                  for(int loop = 0; loop <= 150; loop += 5) {
                     try {
                        _LoginTxt[0].SetBounds(250, 100, 150 - loop, 40);
                        _LoginTxt[1].SetBounds(250, 140, 150 - loop, 40);
                        _LoginBtn.Text = "OK";
                        _LoginBtn.SetBounds(250 - loop, 180, 150, 70);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
                  _LoginTxt[0].Text = "Username";
                  _LoginTxt[1].Text = "Password";
                  _LoginTxt[1].PasswordChar = '\0';
               }).Start();
            }
            if(_RegisterFlag == 0) {
               new Thread(() => {
                  for(int loop = 0; loop <= 450; loop += 5) {
                     try {
                        _RegisterLbl.Size = new Size(280, 0 + loop);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
               }).Start();
               _RegisterLbl.Show();
               _SearchLbl.Hide();
               _SearchFlag = 0;
               _RegisterFlag = 1;
               _LoginFlag = 0;
           } else if(_RegisterFlag == 1) {
                new Thread(() => {
                   for(int loop = 0; loop <= 450; loop += 5) {
                      try {
                        _RegisterLbl.Size = new Size(280, 450 - loop);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                   }
                   _RegisterBox[0].Text = "Full Name";
                   _RegisterBox[1].Text = "Email";
                   _RegisterBox[2].Text = "Password";
                   _RegisterBox[2].PasswordChar = '\0';
                }).Start();
                 _RegisterFlag = 0;

            }
         } else if(sender.Text == "?") {
            if(_LoginFlag == 1) {
               new Thread(() => {
                  for(int loop = 0; loop <= 150; loop += 5) {
                     try {
                        _LoginTxt[0].SetBounds(250, 100, 150 - loop, 40);
                        _LoginTxt[1].SetBounds(250, 140, 150 - loop, 40);
                        _LoginBtn.Text = "OK";
                        _LoginBtn.SetBounds(250 - loop, 180, 150, 70);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
                  _LoginTxt[0].Text = "Username";
                  _LoginTxt[1].Text = "Password";
                  _LoginTxt[1].PasswordChar = '\0';
               }).Start();
            }
            if(_SearchFlag == 0) {
               new Thread(() => {
                  for(int loop = 0; loop <= 450; loop += 5) {
                     try {
                        _SearchLbl.Size = new Size(280, 0 + loop);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
               }).Start();

               _SearchLbl.Show();
               _RegisterLbl.Hide();
               _RegisterFlag = 0;
               _SearchFlag = 1;
               _LoginFlag = 0;
            } else if(_SearchFlag == 1) {
               new Thread(() => {
                  for(int loop = 0; loop <= 450; loop += 5) {
                     try {
                        _SearchLbl.Size = new Size(280, 450 - loop);
                        Thread.Sleep(1);
                     } catch(Exception e) {
                        Console.WriteLine(e.ToString());
                     }
                  }
                  _SearchBox.Text = "Search something";
               }).Start();
                _SearchFlag = 0;
            }
         }
      }

    /*============================================================================*
     *  Function   : __GlobalBtnClicked
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ca  - Event Argument
     *  Returns    : Void
     *  Description: Click event handler for buttons.
     *=============================================================================*/
      void __GlobalBtnClicked(object source, EventArgs ce) {

         Button sender = source as Button;

         if(sender.Tag.ToString() == "LogBtn") {
            MessageBox.Show("Check if shit is correct. If not, show some shitty shit.");
            __ResetAllFields();
            bas.Anchor = (AnchorStyles.Left | AnchorStyles.Right |AnchorStyles.Top | AnchorStyles.Bottom);
            bas.Show();
            this.Controls.SetChildIndex(bas, 0);
         } else if(sender.Tag.ToString() == "RegBtn") {
            MessageBox.Show("Check if some shit is already existing.");
         } else if(sender.Tag.ToString() == "SeaBtn") {
            for(int sealoop = 0; sealoop < _SearchCount; sealoop++) {
               _SearchArtWork[sealoop] = new PictureBox() {
                  Size = new Size(280, 150),
                  Location = new Point(0, 157 * sealoop),
                  Image = Image.FromFile("res/ph.jpg"),
                  SizeMode = PictureBoxSizeMode.StretchImage
               };
               _SearchArtPnl.Controls.Add(_SearchArtWork[sealoop]);

               _SearchArtName[sealoop] = new Label() {
                  Size = new Size(280, 20),
                  TextAlign = ContentAlignment.MiddleCenter,
                  Text = "Kalabaw Ni Cholo",
                  Font = new Font("Helvetica", 10),
                  ForeColor = Color.Black,
                  BackColor = Color.FromArgb(90, Color.Transparent),
                  Location = new Point(0, 130)
               };
               _SearchArtWork[sealoop].Controls.Add(_SearchArtName[sealoop]);
            }
         }
      }

    /*============================================================================*
     *  Function   : __PictureBoxEnter
     *  Params     : object source - Component that triggered the event. 
                     EventArgs mea - Event Argument
     *  Returns    : Void
     *  Description: Highlights featured content on the side bar.
     *=============================================================================*/
      void __PictureBoxEnter(object source, EventArgs mea) {
         var sender = source as PictureBox;
         Point location = sender.Parent.Location;
         _FeatHL.Location = new Point(location.X, location.Y + 210);
         _FeatHL.Show();
      }

    /*============================================================================*
     *  Function   : __PictureBoxLeave
     *  Params     : object source - Component that triggered the event. 
                     EventArgs mea - Event Argument
     *  Returns    : Void
     *  Description: Removes highlights featured content on the side bar.
     *=============================================================================*/
      void __PictureBoxLeave(object source, EventArgs mla) {
         _FeatHL.Hide();
      }

      /*============================================================================*
     *  Function   : __LabelEnter
     *  Params     : object source - Component that triggered the event. 
                     EventArgs mea - Event Argument
     *  Returns    : Void
     *  Description: Shows highlight for labels.
     *=============================================================================*/
      void __LabelEnter(object source, EventArgs mea) {
         var sender = source as Label;
         Point location = sender.Parent.Location;
         _FeatHL.Location = new Point(location.X, location.Y + 210);
         _FeatHL.Show();
      }

    /*============================================================================*
     *  Function   : __LabelLeave
     *  Params     : object source - Component that triggered the event. 
                     EventArgs mla - Event Argument
     *  Returns    : Void
     *  Description: Removes highlights for labels.
     *=============================================================================*/
      void __LabelLeave(object source, EventArgs mla) {
         _FeatHL.Hide();
      }

    /*============================================================================*
     *  Function   : __Resized
     *  Params     : object source - Component that triggered the event. 
                     EventArgs ce  - Event Argument
     *  Returns    : Void
     *  Description: Resize behavio of the form.
     *=============================================================================*/ 
      void __Resized(object source, EventArgs ce) {
         _MainPanel.Left = (this.ClientSize.Width - _MainPanel.Width) / 2 ;
         _MainPanel.Top = (this.ClientSize.Height - _MainPanel.Height) / 2;
      }

      /*============================================================================*
     *  Function   : __ResetAllFields
     *  Params     : None
     *  Returns    : Void
     *  Description: Resets all fields and variables.
     *=============================================================================*/
      void __ResetAllFields() {
         _ActContBtn[0].Location = new Point(100, 100);
         _ActContBtn[1].Location = new Point(100, 210);
         _ActContBtn[2].Location = new Point(100, 100);
         _LoginTxt[0].Location = new Point(100, 100);
            _LoginTxt[0].Text = "Username";
         _LoginTxt[1].Location = new Point(100, 140);
            _LoginTxt[1].Text = "Password"; _LoginTxt[1].PasswordChar = '\0';
         _LoginBtn.Location = new Point(100, 180);
            _RegisterBox[0].Text = "Full Name";
            _RegisterBox[1].Text = "Email";
            _RegisterBox[2].Text= "Password";
               _RegisterBox[2].PasswordChar = '\0';
            _SearchBox.Text = "Search something";
         _MidFlag = 0;
         _LoginFlag = 0;
         _RegisterFlag = 0;
         _SearchFlag = 0;
      }

      /*==============================INITIALIZATION==============================*/
      Panel _MainPanel;
      Panel _ActContPnl;
      Label _FeatHL;
      Panel[] _FeatArtPnl = new Panel[2];
         PictureBox[] _FeatArtBox = new PictureBox[2];
         Label[] _FeatArtCont = new Label[4];
      Label[]  _ActContBtn = new Label[3];
      TextBox[] _LoginTxt = new TextBox[3];
      Button _LoginBtn;
      Label _CompanyName;
      Label _AppLogoLbl;
      Label _RegisterLbl;
         Label _RegisterMes;
         TextBox[] _RegisterBox = new TextBox[3];
         Button _RegisterBtn;
         Label _RegisterAgree;
      Label _SearchLbl;
         TextBox _SearchBox;
         Label _SearchMess;
         Button _SearchBtn;
         Panel _SearchArtPnl;
         PictureBox[] _SearchArtWork = new PictureBox[_SearchCount];
         Label[] _SearchArtName = new Label[_SearchCount];

      BaseTab bas = new BaseTab();
      static int _TimerCount = 0;
      static int _MidFlag = 0;
      static int _LoginFlag = 0;
      static int _RegisterFlag = 0;
      static int _SearchFlag = 0;
      static int _SearchCount = 10;

   }
}
