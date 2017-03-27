/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : tabholder.cs
* Version     : v1.0
* Author      : Gensaya, Carl Jerwin F.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Artsy {
   public class BaseTab : Panel {

      public BaseTab() {
         __DisplayArtBaseTab();
         __SetActiveTab();
      }

      /*============================================================================*
        *  Function   : __DisplayArtBaseTab
        *  Params     : None 
        *  Returns    : Void
        *  Description: This code shows the main holder of the tabs in the GUI.
        *=============================================================================*/
      void __DisplayArtBaseTab() {

         Size = new Size(900, 600);
         MinimumSize = new Size(900, 600);
         BackColor = ColorTranslator.FromHtml("#212121");
         Text = "ARTSY";
         this.SizeChanged += new EventHandler(__Resized);

         _AppNameLbl = new Label() {
            Size = new Size(900, 79),
            Text = "APP NAME",
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI Semibold", 20, FontStyle.Bold)
         };
         _AppNameLbl.MouseEnter += new EventHandler(__HideMenu);
         this.Controls.Add(_AppNameLbl);

            _AppSayLbl = new Label() {
               AutoSize = true,
               Anchor = AnchorStyles.Left | AnchorStyles.Right,
               Text = "SLOGAN: SAMPLE SLOGAN",
               Font = new Font("Segoe UI", 10, FontStyle.Bold),
               ForeColor = Color.White,
               Location = new Point(680, 50)
            };
            _AppSayLbl.MouseEnter += new EventHandler(__HideMenu);
            _AppNameLbl.Controls.Add(_AppSayLbl);

         _NavTabLbl = new Label() {
            Tag = "TabLbl",
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Size = new Size(884, 50),
            Location = new Point(0, 80)
         };
         _NavTabLbl.Paint += new PaintEventHandler(__GlobalNeonBorderLbl);
         this.Controls.Add(_NavTabLbl);

            _HomeTabLogo = new Label() {
               Size = new Size(50, 50),
               Text = "LOGO",
               Font = new Font("Segoe UI", 10, FontStyle.Bold),
               TextAlign = ContentAlignment.MiddleCenter,
               BackColor = Color.White
            };
            _NavTabLbl.Controls.Add(_HomeTabLogo);

            _TabHighL = new Label() {
               Size = new Size(150, 10),
               BackColor = Color.Red
            };
            _TabHighL.Hide();
            _NavTabLbl.Controls.Add(_TabHighL);

            _MeMenuContainer = new Label{
               Size = new Size(150, 130),
               Location = new Point(60, 130),
               BackColor = Color.Transparent
            };
            this.Controls.Add(_MeMenuContainer);
            _MeMenuContainer.Hide();

               for(int loop = 0; loop < 3; loop++){
                  _MeMenuItem[loop] = new Label(){
                     Size = new Size(140, 40),
                     Location = new Point(5, 5 + (loop * 41)),
                     Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                     TextAlign = ContentAlignment.MiddleCenter,
                     Font = new Font("Segoe UI", 10, FontStyle.Bold),
                     BackColor = ColorTranslator.FromHtml("#212121"),
                     ForeColor = Color.White
                  };
                  _MeMenuItem[loop].MouseEnter += new EventHandler(__GlobalEnterLbl);
                  _MeMenuItem[loop].MouseLeave += new EventHandler(__GlobalLeaveLbl);
                  _MeMenuItem[loop].Click += new EventHandler(__ItemClicked);

                  switch(loop){
                     case 0: _MeMenuItem[loop].Text = "COLLECTION";
                             _MeMenuItem[loop].Tag = "MENUITEM1";
                             _MeMenuItem[loop].Click += new EventHandler(__ItemClicked);
                             break;
                     case 1: _MeMenuItem[loop].Text = "SETTINGS";
                             _MeMenuItem[loop].Tag = "MENUITEM2";
                             _MeMenuItem[loop].Click += new EventHandler(__ItemClicked);
                             break;
                     case 2: _MeMenuItem[loop].Text = "LOGOUT";
                             _MeMenuItem[loop].Tag = "MENUITEM3";
                             break;
                  }
                  _MeMenuContainer.Controls.Add(_MeMenuItem[loop]);
               }

            for(int loop = 0; loop < 4; loop++) {
               _NavTabNames[loop] = new Label() {
                  Size = new Size(150, 47),
                  Location = new Point(60 + (loop * 150), 1),
                  Font = new Font("Segoe UI", 10, FontStyle.Bold),
                  TextAlign = ContentAlignment.MiddleCenter,
                  ForeColor = Color.White
               };

               switch(loop){
                  case 0: _NavTabNames[loop].Text = "ME";
                          _NavTabNames[loop].Tag = "ME";
                          _NavTabNames[loop].Size = new Size(50, 47);
                          _NavTabNames[loop].Location = new Point(60, 1);
                          _NavTabNames[loop].MouseEnter += new EventHandler(__GlobalEnterLbl);
                          _NavTabNames[loop].MouseLeave += new EventHandler(__GlobalLeaveLbl);
                          break;
                  case 1: _NavTabNames[loop].Text = "LOBBY";
                          _NavTabNames[loop].Size = new Size(100, 47);
                          _NavTabNames[loop].Location = new Point(110, 1);
                          _NavTabNames[loop].MouseEnter += new EventHandler(__GlobalEnterLbl);
                          _NavTabNames[loop].MouseLeave += new EventHandler(__GlobalLeaveLbl);
                          break;
                  case 2: _NavTabNames[loop].Text = "SHOWROOM";
                          _NavTabNames[loop].Size = new Size(140, 47);
                          _NavTabNames[loop].Location = new Point(210, 1);
                          _NavTabNames[loop].MouseEnter += new EventHandler(__GlobalEnterLbl);
                          _NavTabNames[loop].MouseLeave += new EventHandler(__GlobalLeaveLbl);
                          break;
                  case 3: _NavTabNames[loop].Text = "NEWS";
                          _NavTabNames[loop].Size = new Size(100, 47);
                          _NavTabNames[loop].Location = new Point(350, 1);
                          _NavTabNames[loop].MouseEnter += new EventHandler(__GlobalEnterLbl);
                          _NavTabNames[loop].MouseLeave += new EventHandler(__GlobalLeaveLbl);
                          break;
               }
               _NavTabNames[loop].Click += new EventHandler(__ShowContent);
               _NavTabLbl.Controls.Add(_NavTabNames[loop]);
            }

            _NavTabNames[4] = new Label() {
               Size = new Size(150, 47),
               Text = "◄ SEARCH",
               TextAlign = ContentAlignment.MiddleCenter,
               Location = new Point(730, 1),
               Font = new Font("Segoe UI", 8, FontStyle.Bold),
               ForeColor = ColorTranslator.FromHtml("#FFF9E0")
            };
            _NavTabLbl.Controls.Add(_NavTabNames[4]);
            _NavTabNames[4].MouseEnter += new EventHandler(__GlobalEnterLbl);
            _NavTabNames[4].MouseLeave += new EventHandler(__GlobalLeaveLbl);
            _NavTabNames[4].Click += new EventHandler(__ShowContent);


         _TabContent = new Panel() {
            Size = new Size(910, 420),
            Location = new Point(0, 130),
            BackColor = Color.Transparent,
            AutoScroll = true,
         };
         this.Controls.Add(_TabContent);

         _TabProfile = new Profile() {
            Size = new Size(890, 600),
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabProfile.MouseEnter += new EventHandler(__HideMenu);
         _TabContent.Controls.Add(_TabProfile);

         _TabLobby = new Lobby() {
            Size = new Size(890, 600),
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabLobby.MouseEnter += new EventHandler(__HideMenu);
         _TabContent.Controls.Add(_TabLobby);

         _TabShowroom = new Showroom() {
            Size = new Size(900, 420),
            BackColor = ColorTranslator.FromHtml("#212121"),
         };
         _TabShowroom.MouseEnter += new EventHandler(__HideMenu);
         _TabContent.Controls.Add(_TabShowroom);

         _TabNews = new News() {
            Size = new Size(900, 420),
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabNews.MouseEnter += new EventHandler(__HideMenu);
         _TabContent.Controls.Add(_TabNews);

         _TabSettings = new Settings() {
            Size = new Size(900, 600),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left,
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabContent.Controls.Add(_TabSettings);

         _TabCollection = new MyCollection() {
            Size = new Size(900, 100),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left,
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabCollection.Hide();
         _TabContent.Controls.Add(_TabCollection);

         _TabSearch = new SearchTab() {
            Size = new Size(900, 600),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left,
            BackColor = ColorTranslator.FromHtml("#212121")
         };
         _TabContent.Controls.Add(_TabSearch);
         _TabSearch.Hide();

         _SearchMenuContainer = new Label() {
            Size = new Size(_NavTabNames[4].Width, 65),
            Location = new Point(_NavTabNames[4].Location.X, _NavTabNames[4].Location.Y + 128),
            BackColor = Color.Transparent
         };
         _SearchMenuContainer.Hide();
         this.Controls.Add(_SearchMenuContainer);

            _SearchMenuBox = new TextBox() {
               Size = new Size(_NavTabNames[4].Width - 20, 50),
               Location = new Point(10, 10),
               Font = new Font("Helvetica", 10)
            };
            _SearchMenuContainer.Controls.Add(_SearchMenuBox);

            _SearchButton = new Label() {
               Size = new Size(_NavTabNames[4].Width - 20, 20),
               Location = new Point(10, 35),
               TextAlign = ContentAlignment.MiddleCenter,
               BackColor = ColorTranslator.FromHtml("#954535"),
               ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
               Text = "SEARCH",
               Font = new Font("Segoe UI", 10)
            };
            _SearchMenuContainer.Controls.Add(_SearchButton);
            _SearchButton.Click += new EventHandler(__ItemClicked);

      }

       /*============================================================================*
        *  Function   : __GlobalNeonBorderLbl
        *  Params     : object source - Component that triggered the event.
                        PaintEventArgs pea - Event Argument
        *  Returns    : Void
        *  Description: Paint event for putting highlight in tab header.
        *=============================================================================*/
      void __GlobalNeonBorderLbl(object source, PaintEventArgs pea) {
         var sender = source as Label;

         if(sender.Tag.ToString() == "TabLbl") {
            ControlPaint.DrawBorder(pea.Graphics, _NavTabLbl.DisplayRectangle,
                                    ColorTranslator.FromHtml("#F8D0D8"), 0, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#F8D0D8"), 1, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#F8D0D8"), 0, ButtonBorderStyle.Solid,
                                    ColorTranslator.FromHtml("#F8D0D8"), 2, ButtonBorderStyle.Solid);
         }
      }

      /*============================================================================*
        *  Function   : __GlobalEnterLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Put hightlight on hovered tab label.
        *=============================================================================*/
      void __GlobalEnterLbl(object source, EventArgs mea) {
         var sender = source as Label;
         var senderX = sender.Location.X;

         if(_MenuShown == 1){
            _TabHighL.Hide();
         } else{
            _TabHighL.Location = new Point(senderX, 45);
            _TabHighL.Width = sender.Width;
            _TabHighL.Show();
         }
         sender.BackColor = Color.White;
         sender.ForeColor = ColorTranslator.FromHtml("#954535");
         sender.Font = new Font("Segoe UI Semibold", 13, FontStyle.Bold);
      }

      /*============================================================================*
        *  Function   : __GlobalLeaveLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Remove highlight on unhovered tab label.
        *=============================================================================*/
      void __GlobalLeaveLbl(object source, EventArgs mea) {
         var sender = source as Label;
         _TabHighL.Hide();
         sender.BackColor = ColorTranslator.FromHtml("#212121");
         sender.ForeColor = Color.White;
         sender.Font = new Font("Segoe UI", 10, FontStyle.Bold);
         __SetActiveTab();
      }

      /*============================================================================*
        *  Function   : __ShowMenu
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Shows submenu for user tab label.
        *=============================================================================*/
      void __ShowMenu(object source, EventArgs mea) {
         _NavTabNames[0].BackColor = Color.White;
         _NavTabNames[0].ForeColor = ColorTranslator.FromHtml("#212121");
      }

      void __HideMenu(object source, EventArgs mea) {
         //_NavTabNames[0].BackColor = ColorTranslator.FromHtml("#212121");
         //_NavTabNames[0].ForeColor = Color.White;
         //_MeMenuContainer.Hide();
         //__SetActiveTab();
         //_TabProfile.Focus();
         //_TabLobby.Focus();
         //_TabShowroom.Focus();
         //_TabNews.Focus();
      }

      /*============================================================================*
        *  Function   : __ItemClicked
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Handles click events for the submenu of a tab.
        *=============================================================================*/
      void __ItemClicked(object source, EventArgs mea) {
         Label sender = source as Label;

         if(sender.Text == "LOGOUT"){
            this.Hide();
            this.Refresh();

         } else if(sender.Text == "SETTINGS") {
            _TabSettings.Size = _TabProfile.Size;
            _TabSettings.Location = _TabProfile.Location;
            _TabSettings.BringToFront();
            _TabSettings.Show();
            _MeMenuContainer.Hide();
            this.Refresh();

         } else if(sender.Text == "COLLECTION") {
            _TabCollection.Size = _TabProfile.Size;
            _TabCollection.Location = _TabProfile.Location;
            _TabCollection.Show();
            _TabCollection.BringToFront();
            _MeMenuContainer.Hide();
            this.Refresh();
         } else if(sender.Text == "SEARCH") {
            _TabSearch.Show();
            _SearchMenuContainer.Hide();
            _TabSearch.Show();
            _TabSearch.BringToFront();
            _TabProfile.Hide();
            _TabLobby.Hide();
            _TabShowroom.Hide();
            _TabNews.Hide();
            _TabSettings.Hide();
            _TabCollection.Hide();

         }
      }

      /*============================================================================*
        *  Function   : __SetActiveTab
        *  Params     : None
        *  Returns    : Void
        *  Description: Controls tab highlights loop for the tab labels.
        *=============================================================================*/
      void __SetActiveTab() {
         for(int loop = 0; loop < 5; loop++) {

            _NavTabNames[loop].BackColor = ColorTranslator.FromHtml("#212121");
            _NavTabNames[loop].ForeColor = Color.White;

            if(loop == _ActiveTabIndex) {
               _NavTabNames[loop].BackColor = Color.White;
               _NavTabNames[loop].ForeColor = ColorTranslator.FromHtml("#212121");

               switch(loop) {
                  case 0: {
                     _TabProfile.Show();
                     _TabLobby.Hide();
                     _TabShowroom.Hide();
                     _TabNews.Hide();
                     _TabSearch.Hide();
                     break;
                  }
                  case 1: {
                     _TabProfile.Hide();
                     _TabLobby.Show();
                     _TabShowroom.Hide();
                     _TabNews.Hide();
                     _TabSettings.Hide();
                     _TabCollection.Hide();
                     _TabSearch.Hide();
                     break;
                  }
                  case 2: {
                     _TabProfile.Hide();
                     _TabLobby.Hide();
                     _TabShowroom.Show();
                     _TabNews.Hide();
                     _TabSettings.Hide();
                     _TabCollection.Hide();
                     _TabSearch.Hide();
                     break;
                  }
                  case 3: {
                     _TabProfile.Hide();
                     _TabLobby.Hide();
                     _TabShowroom.Hide();
                     _TabNews.Show();
                     _TabSettings.Hide();
                     _TabCollection.Hide();
                     _TabSearch.Hide();
                     break;
                  }
               }
               /*
               switch(loop) {
                  case 0: {
                     this.Controls.SetChildIndex(_TabProfile, 0);
                     if(_MenuShown == 0){
                        _MenuShown = 1;
                        Console.WriteLine("container must be shown");
                        _MeMenuContainer.SendToBack();
                     } else {
                        _MeMenuContainer.BringToFront();
                        Console.WriteLine("IN");
                        _MenuShown = 0;
                     }
                     this.Refresh();
                     //_MeMenuContainer.Show();
                     break;
                  }
                  case 1: {
                     _TabLobby.BringToFront();
                     this.Refresh();
                     break;
                  }
                  case 2: {
                     _TabShowroom.BringToFront();
                     this.Refresh();
                     break;
                  }
                  case 3: {
                     _TabNews.BringToFront();
                     this.Refresh();
                     break;
                  }
               }*/
            }
         }
      }

      /*============================================================================*
        *  Function   : __ShowContent
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Shows content of the selected tab.
        *=============================================================================*/
      void __ShowContent(object source, EventArgs mea) {
         Label sender = source as Label;

         if(sender.Text.ToString() == "ME") {
            _ActiveTabIndex = 0;
            _TabSettings.Hide();
            _TabCollection.Hide();
            if(_MenuShown == 0){
               _MenuShown = 1;
               _MeMenuContainer.SendToBack();
               _MeMenuContainer.Hide();
            } else {
               _MeMenuContainer.BringToFront();
               _MeMenuContainer.Show();
               _MenuShown = 0;
            }
         } else if(sender.Text.ToString() == "LOBBY") {
            _MeMenuContainer.SendToBack();
            _MenuShown = 0;
            _ActiveTabIndex = 1;
         } else if(sender.Text.ToString() == "SHOWROOM") {
            _MeMenuContainer.SendToBack();
            _MenuShown = 0;
            _ActiveTabIndex = 2;
         } else if(sender.Text.ToString() == "NEWS") {
            _MeMenuContainer.SendToBack();
            _MenuShown = 0;
            _ActiveTabIndex = 3;
         } else if(sender.Text.ToString() == "◄ SEARCH") {
            if(_SearchShown == 0){
               _SearchMenuContainer.Show();
               _SearchShown = 1;
            } else {
               _SearchMenuContainer.Hide();
               _SearchShown = 0;
            }
            _SearchMenuContainer.BringToFront();
         }
         __SetActiveTab();
      }

      /*============================================================================*
        *  Function   : __Resized
        *  Params     : object source - Component that triggered the event.
                        EventArgs e   - Event Argument
        *  Returns    : Void
        *  Description: Handles the resize behavior of the tab holder.
        *=============================================================================*/
      void __Resized(object source, EventArgs e){
         _NavTabLbl.Location = new Point(0, 80);
         _NavTabNames[4].Location = new Point(this.Width - 170, 1);
         this.Controls.SetChildIndex(_NavTabLbl, 0);
      }


      /*==============================INITIALIZATION==============================*/
      Label _AppNameLbl;
         Label _AppSayLbl;
      Label _NavTabLbl;
         Label _HomeTabLogo;
         Label[] _NavTabNames = new Label[5];
         Label _TabHighL;
      Label _MeMenuContainer;
         Label[] _MeMenuItem = new Label[3];
      Label _SearchMenuContainer;
         TextBox _SearchMenuBox;
         Label _SearchButton;

      Panel _TabProfile;
      Panel _TabLobby;
      Panel _TabShowroom;
      Panel _TabNews;
      Panel _TabSettings;
      Panel _TabCollection;
      Panel _TabContent;
      Panel _TabSearch;

      int _ActiveTabIndex = 0;
      int _MenuShown = 0;
      int _SearchShown = 0;
   }
}
