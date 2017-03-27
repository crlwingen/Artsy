/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Settings.cs
* Version     : v1.0
* Author      : Gensaya, Carl Jerwin F.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Artsy {
   class Settings : Panel {

      public Settings() {
         DisplayUserSettings();
      }

       /*============================================================================*
        *  Function   : DisplayUserSettings
        *  Params     : None 
        *  Returns    : Void
        *  Description: The panel that displays the settings tab of Artsy.
        *=============================================================================*/
      void DisplayUserSettings() {

         BackColor = Color.White;
         DoubleBuffered = true;
         AutoScroll = true;
         Size = new Size(900, 500); BackColor = Color.Black;

         _TabHL = new Label() {
            Size = new Size(250, 5),
            BackColor = ColorTranslator.FromHtml("#ff6933"),
            Location = new Point(10, 215)
         };
         this.Controls.Add(_TabHL);

         _UserInfo[0] = new Label() {
            Size = new Size(250, 150),
            BackColor = Color.White,
            Location = new Point(10, 20)
         };
         this.Controls.Add(_UserInfo[0]);

            _UserInfo[1] = new Label() {
               Size = new Size(250, 90),
               Text = "Art chosen by the user",
               TextAlign = ContentAlignment.TopCenter
            };
            _UserInfo[0].Controls.Add(_UserInfo[1]);

            _UserInfo[2] = new Label() {
               Size = new Size(70, 70),
               Location = new Point(5, 40),
               BackColor = Color.Green,
               Text = "USERPIC",
               TextAlign = ContentAlignment.MiddleCenter
            };
            _UserInfo[0].Controls.Add(_UserInfo[2]);

            _UserInfo[3] = new Label() {
               Size = new Size(250, 60),
               Location = new Point(0, 90),
               BackColor = Color.Gray,
               Text = "USERNAME AND SHITS",
               TextAlign = ContentAlignment.MiddleCenter
            };
            _UserInfo[0].Controls.Add(_UserInfo[3]);

            _UserInfo[0].Controls.SetChildIndex(_UserInfo[1], 2);
            _UserInfo[0].Controls.SetChildIndex(_UserInfo[2], 1);
            _UserInfo[0].Controls.SetChildIndex(_UserInfo[3], 2);

         _UserSets[0] = new Label() {
            Size = new Size(250, 120),
            BackColor = Color.White,
            Location = new Point(10, 190)
         };
         this.Controls.Add(_UserSets[0]);

         for(int loop = 1; loop < 5; loop++) {
            _UserSets[loop] = new Label() {
               Size = new Size(250, 30),
               Location = new Point(0, loop * 30 - 30),
               Text = _SettingHeader[loop - 1],
               TextAlign = ContentAlignment.MiddleLeft,
               BackColor = ColorTranslator.FromHtml("#333333"),
               Font = new Font("Helvetica", 10),
               ForeColor = ColorTranslator.FromHtml("#bfbfbf")
            };
            _UserSets[0].Controls.Add(_UserSets[loop]);
            _UserSets[loop].Click += new EventHandler(__GlobalClickLbl);
         }

         _SettingsCont[0] = new Label() {
            BackColor = Color.Transparent,
            Size = new Size(600, 500),
            Location = new Point(280, 20)
         };
         this.Controls.Add(_SettingsCont[0]);

         _SettingsCont[1] = new Label() {
            BackColor = Color.Gray,
            Size = new Size(400, 500)
         };
         _SettingsCont[0].Controls.Add(_SettingsCont[1]);

            _Cont1[0] = new Label() {
               Size = new Size(400, 50),
               BackColor = Color.White,
               Font = new Font("Segoe UI", 13),
               Text = @"  GENERAL SETTINGS
   Change your basic account settings"
            };
            _SettingsCont[1].Controls.Add(_Cont1[0]);

            _Cont1[1] = new Label() {
               Size = new Size(310, 60),
               Location = new Point(10, 90),
               Text = @"Username:

                          Change your account's username.",
               Font = new Font("Segoe UI", 10),
               ForeColor = Color.White,
               BackColor = Color.Transparent
            };
            _SettingsCont[1].Controls.Add(_Cont1[1]);

               _ContTxtBox[0] = new TextBox() {
                  Font = new Font("Segoe UI", 10),
                  Size = new Size(200, 40),
                  Location = new Point(95, 0)
               };
               _Cont1[1].Controls.Add(_ContTxtBox[0]);

            _Cont1[2] = new Label() {
               Size = new Size(310, 60),
               Location = new Point(10, 170),
               Text = @"Password:

                          Change your acoount's password.",
               Font = new Font("Segoe UI", 10),
               ForeColor = Color.White
            };
            _SettingsCont[1].Controls.Add(_Cont1[2]);

            _ContTxtBox[1] = new TextBox() {
               Font = new Font("Segoe UI", 10),
               Size = new Size(200, 40),
               Location = new Point(95, 0),
               PasswordChar = '•'
            };
            _Cont1[2].Controls.Add(_ContTxtBox[1]);

            _Cont1[3] = new Label() {
               Size = new Size(310, 60),
               Location = new Point(10, 250),
               Text = @"Followers:

                                                      On/off followers.",
               Font = new Font("Segoe UI", 10),
               ForeColor = Color.White
            };
            _SettingsCont[1].Controls.Add(_Cont1[3]);

            _CmbFollow = new ComboBox() {
               Font = new Font("Segoe UI", 10),
               Size = new Size(200, 40),
               Location = new Point(95, 0),
               DropDownStyle = ComboBoxStyle.DropDownList
            };
            _CmbFollow.Items.Add("Enabled");
            _CmbFollow.Items.Add("Disabled");
            _Cont1[3].Controls.Add(_CmbFollow);

            _ApplyBtn = new Button() {
               Size = new Size(150, 30),
               Font = new Font("Arial", 10),
               FlatStyle = FlatStyle.Flat,
               Text = "Apply",
               Location = new Point(150, 330)
            };
            _SettingsCont[1].Controls.Add(_ApplyBtn);

            _SettingsCont[2] = new Label() {
               Size = new Size(400, 500),
               BackColor = Color.Yellow
            };
            _SettingsCont[0].Controls.Add(_SettingsCont[2]);

               _Cont2[0] = new Label() {
                  Size = new Size(400, 50),
                  BackColor = Color.White,
                  Font = new Font("Segoe UI", 11),
                  Text = @"  TRANSACTIONS AND CARDS
  Manage your cards and check your transaction history"
               };
               _SettingsCont[2].Controls.Add(_Cont2[0]);

               _Cont2[1] = new Label() {
                  Size = new Size(380, 150),
                  BackColor = Color.White,
                  Location = new Point(10, 90),
                  Font = new Font("Segoe UI", 12, FontStyle.Bold),
                  Text = "Transaction History"
               };
               _SettingsCont[2].Controls.Add(_Cont2[1]);

                  _Cont2[2] = new Label() {
                     Size = new Size(380, 140),
                     Font = new Font("Segoe UI", 10),
                     ForeColor = Color.Gray,
                     Text = "Seems like you still don't have any buy/sell history here at Artsy. Why not try bidding or selling some of your artworks? It sure would be fun. :)",
                     Location = new Point(5, 30)
                  };
                  _Cont2[1].Controls.Add(_Cont2[2]);

               _Cont2[3] = new Label() {
                  Size = new Size(380, 150),
                  BackColor = Color.White,
                  Location = new Point(10, 260),
                  Font = new Font("Segoe UI", 12, FontStyle.Bold),
                  Text = "Registered Cards"
               };
               _SettingsCont[2].Controls.Add(_Cont2[3]);

                  _Cont2[4] = new Label() {
                     Size = new Size(380, 140),
                     Font = new Font("Segoe UI", 10),
                     ForeColor = Color.Gray,
                     Text = "You still don't have any registered cards yet.",
                     Location = new Point(5, 30)
                  };
                  _Cont2[3].Controls.Add(_Cont2[4]);

            _SettingsCont[3] = new Label() {
               Size = new Size(400, 500),
               BackColor = Color.Gray
            };
            _SettingsCont[0].Controls.Add(_SettingsCont[3]);

               _Cont3[0] = new Label() {
                  Size = new Size(400, 50),
                  BackColor = Color.White,
                  Font = new Font("Segoe UI", 11),
                  Text = @"  PRIVACY AND BLOCKING
   Change privacy settings and block other Artsy users"
               };
               _SettingsCont[3].Controls.Add(_Cont3[0]);

               _Cont3[1] = new Label() {
                  Size = new Size(380, 120),
                  BackColor = Color.Transparent,
                  Location = new Point(10, 80),
                  Text = "Discoverability",
                  Font = new Font("Segoe UI", 12, FontStyle.Bold),
               };
               _SettingsCont[3].Controls.Add(_Cont3[1]);

               _ChkDiscover[0] = new CheckBox() {
                  Size = new Size(350, 50),
                  Text = "Let others find me by my email address.",
                  Font = new Font("Segoe UI", 10),
                  Location = new Point(20, 30)
               };
               _Cont3[1].Controls.Add(_ChkDiscover[0]);

               _ChkDiscover[1] = new CheckBox() {
                  Size = new Size(350, 50),
                  Text = "Let others find me by my phone number.",
                  Font = new Font("Segoe UI", 10),
                  Location = new Point(20, 65)
               };
               _Cont3[1].Controls.Add(_ChkDiscover[1]);

               _Cont3[2] = new Label() {
                  Size = new Size(380, 200),
                  BackColor = Color.Transparent,
                  Location = new Point(10, 220),
                  Text = "Blocking",
                  Font = new Font("Segoe UI", 12, FontStyle.Bold),
               };
               _SettingsCont[3].Controls.Add(_Cont3[2]);

               _TxtBlockUser = new TextBox() {
                  Size = new Size(360, 40),
                  Text = "User to be blocked",
                  Font = new Font("Arial", 10),
                  Location = new Point(10, 40),
                  ForeColor = Color.Gray
               };
               _Cont3[2].Controls.Add(_TxtBlockUser);

               _Cont3[3] = new Label() {
                  Size = new Size(360, 100),
                  Text = @"Blocked users:

   *Insert blocked users' names here.*",
                  Location = new Point(0, 80),
                  Font = new Font("Segoe UI", 10)
               };
               _Cont3[2].Controls.Add(_Cont3[3]);

               _ApplyBtn3 = new Button() {
                  Size = new Size(150, 30),
                  Font = new Font("Arial", 10),
                  FlatStyle = FlatStyle.Flat,
                  Text = "Apply",
                  Location = new Point(230, 440)
               };
               _SettingsCont[3].Controls.Add(_ApplyBtn3);

               _SettingsCont[4] = new Label() {
                  Size = new Size(500, 500),
                  BackColor = Color.Gray
               };
               _SettingsCont[0].Controls.Add(_SettingsCont[4]);
               _SettingsCont[4].Hide();

                  Panel _RuleHolder = new Panel() {
                     Size = new Size(500, 500),
                     AutoScroll = true
                  };
                  _SettingsCont[4].Controls.Add(_RuleHolder);

                  Panel _AuctionRules = new Rules() {
                     Size = new Size(500, 500)
                  };
                  _RuleHolder.Controls.Add(_AuctionRules);
      }

      void __GlobalClickLbl(object source, EventArgs cea) {
         var sender = source as Label;

         for(int loop = 1; loop < 5; loop++) {
            if(sender.Text == _UserSets[loop].Text) {
               _TabHL.Location = new Point(10, 200 + _UserSets[loop].Location.Y + _UserSets[loop].Height - 15);
               _SettingsCont[loop].Show();
               _SettingsCont[loop].BringToFront();
            } else {
               _SettingsCont[loop].SendToBack();
               _SettingsCont[loop].Hide();
            }
         }
      }

      /*============================================================================*
        *  Function   : __GlobalMEnterLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Unused event for hovered labels.
        *=============================================================================*/
      void __GlobalMEnterLbl(object source, EventArgs mea) {
         // Enter Mouse Enter Event for Labels
      }

      /*============================================================================*
        *  Function   : __GlobalMLeaveLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mla - Event Argument
        *  Returns    : Void
        *  Description: Unused event for unhovered labels.
        *=============================================================================*/
      void __GlobalMLeaveLbl(object source, EventArgs mla) {
         // Enter Mouse Leave Event for Labels
      }

      /*==============================INITIALIZATION==============================*/
      Label _TabHL;
      Label[] _UserInfo = new Label[4];
      Label[] _UserSets = new Label[5];
         String[] _SettingHeader = {"General", "Transactions", "Privacy", "Bidding Rules"};
         Color[] _SettingColor = {Color.Red, Color.Blue, Color.Gray};
      Label[] _SettingsCont = new Label[5];
         // _SettingsCont[1]
         Label[] _Cont1 = new Label[4];
         TextBox[] _ContTxtBox = new TextBox[2];
         ComboBox _CmbFollow;
         Button _ApplyBtn;
         // _SettingsCont[2]
         Label[] _Cont2 = new Label[5];
         // _SettingsCont[3]
         Label[] _Cont3 = new Label[4];
         CheckBox[] _ChkDiscover = new CheckBox[2];
         TextBox _TxtBlockUser;
         Button _ApplyBtn3;


   }
}
