/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Search.cs
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

   public class SearchTab : Panel {

      public SearchTab() {
         DisplaySearchTab();
      }

      /*============================================================================*
        *  Function   : DisplaySearchTab
        *  Params     : None 
        *  Returns    : Void
        *  Description: The panel that displays the search tab of Artsy.
        *=============================================================================*/
      void DisplaySearchTab() {
         BackColor = ColorTranslator.FromHtml("#212121");
         AutoSize = true;
         AutoScroll = true;

         _SrcResInfoPnl = new Panel() {
            Size = new Size(750, 400),
            Location = new Point(60, 10),
            BackColor = ColorTranslator.FromHtml("#404040")
         };
         this.Controls.Add(_SrcResInfoPnl);
         _SrcResInfoPnl.Hide();

            Label _SrcResInfoExit = new Label() {
               Tag = "SrcExit",
               Size = new Size(30, 30),
               Text = "X",
               Location = new Point(715, 5),
               TextAlign = ContentAlignment.MiddleCenter,
               Font = new Font("Helvetica", 10, FontStyle.Bold),
               BackColor = ColorTranslator.FromHtml("#333333"),
               ForeColor = ColorTranslator.FromHtml("#884949")
            };
            _SrcResInfoPnl.Controls.Add(_SrcResInfoExit);
            _SrcResInfoExit.Click += new EventHandler(__MouseClick);

            _SrcResInfoBox = new PictureBox() {
               Size = new Size(250, 250),
               SizeMode = PictureBoxSizeMode.StretchImage,
               Image = Image.FromFile("res/user.jpg"),
               Location = new Point(10, 10)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResInfoBox);

            _SrcResCatLbl = new Label() {
               Size = new Size(250, 30),
               Location = new Point(0, 220),
               TextAlign = ContentAlignment.MiddleCenter,
               Font = new Font("Helvetica", 11),
               BackColor = Color.FromArgb(90, Color.Gray)
            };
            _SrcResInfoBox.Controls.Add(_SrcResCatLbl);

            Panel _SrcInfoHolder = new Panel() {
               Size = new Size(440, 350),
               Location = new Point(270, 10),
               BackColor = ColorTranslator.FromHtml("#262626"),
               AutoScroll = true
            };
            _SrcResInfoPnl.Controls.Add(_SrcInfoHolder);

            _SrcResInfo = new Label() {
               MaximumSize = new Size(440, 0),
               AutoSize = true,
               Font = new Font("Helvetica", 10),
               Text = "DITO MO NA LANG LAGAY LAHAT NG BASIC INFO NITONG HINANAP.",
               BackColor = Color.Transparent
            };
            _SrcInfoHolder.Controls.Add(_SrcResInfo);

            _SrcResFollow = new Button() {
               Size = new Size(80, 40),
               Location = new Point(40, 265),
               FlatStyle = FlatStyle.Flat,
               Text = "Follow",
               Font = new Font("Helvetica", 10)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResFollow);
            _SrcResFollow.Hide();

            _SrcResMess = new Button() {
               Size = new Size(80, 40),
               Location = new Point(140, 265),
               FlatStyle = FlatStyle.Flat,
               Text = "Message",
               Font = new Font("Helvetica", 10)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResMess);
            _SrcResMess.Hide();

            _SrcResLike = new Button() {
               Size = new Size(80, 40),
               Location = new Point(40, 265),
               FlatStyle = FlatStyle.Flat,
               Text = "Like",
               Font = new Font("Helvetica", 10)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResLike);
            _SrcResLike.Hide();

            _SrcResComment = new Button() {
               Size = new Size(80, 40),
               Location = new Point(140, 265),
               FlatStyle = FlatStyle.Flat,
               Text = "Comment",
               Font = new Font("Helvetica", 10)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResComment);
            _SrcResComment.Hide();

            _SrcResSellPriceLbl = new Label() {
               AutoSize = true,
               Text = "Current Bid: ",
               TextAlign = ContentAlignment.MiddleCenter,
               Font = new Font("Helvetica", 10, FontStyle.Bold),
               Location = new Point(10, 285)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResSellPriceLbl);

            _SrcResSellPrice = new Label() {
               AutoSize = true,
               Text = "P Price Here",
               Font = new Font("Helvetica", 12, FontStyle.Bold),
               Location = new Point(110, 285)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResSellPrice);

            _SrcResBuyIt = new Button() {
               Size = new Size(200, 30),
               Text = "Buy it for $$$$$$",
               Font = new Font("Helvetica", 12, FontStyle.Bold),
               FlatStyle = FlatStyle.Flat,
               Location = new Point(30, 315)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResBuyIt);

            _SrcResMakeOffer = new Button() {
               Size = new Size(200, 30),
               Text = "Make an offer",
               Font = new Font("Helvetica", 12, FontStyle.Bold),
               FlatStyle = FlatStyle.Flat,
               Location = new Point(30, 355)
            };
            _SrcResInfoPnl.Controls.Add(_SrcResMakeOffer);

         _SrcResLbl = new Label() {
            Size = new Size(900, 50),
            Text = "Showing search results for: *Search query here*",
            Font = new Font("Segoe UI", 15),
            BackColor = ColorTranslator.FromHtml("#808080"),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter
         };
         this.Controls.Add(_SrcResLbl);

         // Search results for bids.

         _SrcBidPnl = new Panel() {
            Size = new Size(300, 360),
            BackColor = Color.Gray,
            Location = new Point(0, 80),
            AutoScroll = true
         };
         this.Controls.Add(_SrcBidPnl);

            _SrcBidLbl = new Label() {
               Size = new Size(285, 30),
               Text = "RESULTS FOR BIDS",
               TextAlign = ContentAlignment.MiddleCenter,
               BackColor = ColorTranslator.FromHtml("#663800"),
               ForeColor = Color.White,
               Font = new Font("Segoe UI", 12),
               Location = new Point(0, 50)
            };
            this.Controls.Add(_SrcBidLbl);

            for(int loop = 0; loop < _BidResCount; loop++) {
               Panel dyBidPnl = new Panel() {
                  Size = new Size(300, 150),
                  BackColor = ColorTranslator.FromHtml("#595959"),
                  Location = new Point(3, 150 * loop + 3),
                  BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
               };
               _BidPnl.Add(dyBidPnl);
               _SrcBidPnl.Controls.Add(dyBidPnl);

               PictureBox dyBidBox = new PictureBox() {
                  Size = new Size(130, 150),
                  Image = Image.FromFile("res/bae.jpg"),
                  SizeMode = PictureBoxSizeMode.StretchImage,
                  Location = new Point(3, 0)
               };
               dyBidBox.MouseEnter += new EventHandler(__GlobalMEnterBox);
               dyBidBox.MouseLeave += new EventHandler(__GlobalMLeaveBox);
               _BidBox.Add(dyBidBox);
               dyBidPnl.Controls.Add(dyBidBox);

               Label dyBidLbl = new Label() {
                  Tag = "DyBid",
                  Size = new Size(170, 150),
                  Text = "Ang Cute nila. Bae ko sila. <3 <3",
                  Font = new Font("Arial", 9),
                  Location = new Point(133, 0),
                  TextAlign = ContentAlignment.MiddleLeft,
                  BackColor = ColorTranslator.FromHtml("#595959"),
               };
               dyBidLbl.MouseEnter += new EventHandler(__GlobalMEnterLbl);
               dyBidLbl.MouseLeave += new EventHandler(__GlobalMLeaveLbl);
               dyBidLbl.Click += new EventHandler(__MouseClick);
               _BidLbl.Add(dyBidLbl);
               dyBidPnl.Controls.Add(dyBidLbl);

            }

         // Search results for artworks.

         _SrcArtPnl = new Panel() {
            Size = new Size(300, 360),
            BackColor = Color.Gray,
            Location = new Point(285, 80),
            AutoScroll = true
         };
         this.Controls.Add(_SrcArtPnl);

            _SrcArtLbl = new Label() {
               Size = new Size(290, 30),
               Text = "RESULTS FOR ARTWORKS",
               Font = new Font("Segoe UI", 13),
               Location = new Point(285, 50),
               TextAlign = ContentAlignment.MiddleCenter,
               BackColor = ColorTranslator.FromHtml("#264040"),
               ForeColor = Color.White
            };
            this.Controls.Add(_SrcArtLbl);

            for(int loop = 0; loop < _ArtResCount; loop++) {
               Panel dyArtPnl = new Panel() {
                  Size = new Size(300, 150),
                  BackColor = Color.White,
                  Location = new Point(3, 150 * loop + 3),
                  BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
               };
               _ArtPnl.Add(dyArtPnl);
               _SrcArtPnl.Controls.Add(dyArtPnl);

               PictureBox dyArtBox = new PictureBox() {
                  Size = new Size(130, 150),
                  Image = Image.FromFile("res/log2.jpg"),
                  SizeMode = PictureBoxSizeMode.StretchImage,
                  Location = new Point(3, 0)
               };
               dyArtBox.MouseEnter += new EventHandler(__GlobalMEnterBox);
               dyArtBox.MouseLeave += new EventHandler(__GlobalMLeaveBox);
               _ArtBox.Add(dyArtBox);
               dyArtPnl.Controls.Add(dyArtBox);

               Label dyArtLbl = new Label() {
                  Tag = "DyArt",
                  Size = new Size(170, 150),
                  Text = "Artwork by Aling Bebang 28. Hehehz talented aketch",
                  Font = new Font("Arial", 9),
                  Location = new Point(133, 0),
                  TextAlign = ContentAlignment.MiddleLeft,
                  BackColor = ColorTranslator.FromHtml("#595959"),
               };
               dyArtLbl.MouseEnter += new EventHandler(__GlobalMEnterLbl);
               dyArtLbl.MouseLeave += new EventHandler(__GlobalMLeaveLbl);
               dyArtLbl.Click += new EventHandler(__MouseClick);
               _ArtLbl.Add(dyArtLbl);
               dyArtPnl.Controls.Add(dyArtLbl);

            }

         // Search results for users.

         _SrcUserPnl = new Panel() {
            Size = new Size(330, 360),
            BackColor = Color.Gray,
            Location = new Point(570, 80),
            AutoScroll = true
         };
         this.Controls.Add(_SrcUserPnl);

            _SrcUserLbl = new Label() {
               Size = new Size(320, 30),
               Text = "RESULTS FOR USERS",
               Font = new Font("Segoe UI", 13),
               TextAlign = ContentAlignment.MiddleCenter,
               BackColor = ColorTranslator.FromHtml("#145214"),
               ForeColor = Color.White,
               Location = new Point(575, 50)
            };
            this.Controls.Add(_SrcUserLbl);

            for(int loop = 0; loop < _UserResCount; loop++) {
               Panel dyUserPnl = new Panel() {
                  Size = new Size(330, 150),
                  BackColor = Color.White,
                  Location = new Point(3, 150 * loop + 3),
                  BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
               };
               _UserPnl.Add(dyUserPnl);
               _SrcUserPnl.Controls.Add(dyUserPnl);

               PictureBox dyUserBox = new PictureBox() {
                  Size = new Size(130, 150),
                  Image = Image.FromFile("res/janno.jpg"),
                  SizeMode = PictureBoxSizeMode.StretchImage,
                  Location = new Point(3, 0)
               };
               dyUserBox.MouseEnter += new EventHandler(__GlobalMEnterBox);
               dyUserBox.MouseLeave += new EventHandler(__GlobalMLeaveBox);
               _UserBox.Add(dyUserBox);
               dyUserPnl.Controls.Add(dyUserBox);

               Label dyUserLbl = new Label() {
                  Tag = "DyUser",
                  Size = new Size(180, 150),
                  Text = @"Janno III Gibbs
   Sa Puso mo <3",
                  Font = new Font("Arial", 9),
                  Location = new Point(133, 0),
                  TextAlign = ContentAlignment.MiddleLeft,
                  BackColor = ColorTranslator.FromHtml("#595959"),
               };
               dyUserLbl.MouseEnter += new EventHandler(__GlobalMEnterLbl);
               dyUserLbl.MouseLeave += new EventHandler(__GlobalMLeaveLbl);
               dyUserLbl.Click += new EventHandler(__MouseClick);

               _UserLbl.Add(dyUserLbl);
               dyUserPnl.Controls.Add(dyUserLbl);

            }

            this.Controls.SetChildIndex(_SrcBidPnl, 3);
            this.Controls.SetChildIndex(_SrcArtPnl, 2);
            this.Controls.SetChildIndex(_SrcUserPnl, 1);

      }

      /*============================================================================*
        *  Function   : __GlobalPEventPnl
        *  Params     : object source - Component that triggered the event.
                        PaintEventArgs pa - Event Argument
        *  Returns    : Void
        *  Description: Puts border highlight to the panel.
        *=============================================================================*/
      void __GlobalPEventPnl(object source, PaintEventArgs pa) {
         var sender = source as Panel;
         Control SenderParent = sender.Parent;
         Color BorderColor = Color.Red; // Change the color if ya want.
         int BorderThickness = 3; // Change this too if ya want to.
         ControlPaint.DrawBorder(pa.Graphics, SenderParent.DisplayRectangle,
                                 BorderColor, BorderThickness, ButtonBorderStyle.Solid,
                                 BorderColor, 0, ButtonBorderStyle.Solid,
                                 BorderColor, 0, ButtonBorderStyle.Solid,
                                 BorderColor, 0, ButtonBorderStyle.Solid);
      }

      /*============================================================================*
        *  Function   : __GlobalMEnterBox
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Puts border highlight to the hovered picture box.
        *=============================================================================*/
      void __GlobalMEnterBox(object source, EventArgs mea) {
         var sender = source as PictureBox;
         Control SenderParent = sender.Parent;
         SenderParent.Paint += new PaintEventHandler(__GlobalPEventPnl);
         SenderParent.Refresh();
      }

      /*============================================================================*
        *  Function   : __GlobalMLeaveBox
        *  Params     : object source - Component that triggered the event.
                        EventArgs mla - Event Argument
        *  Returns    : Void
        *  Description: Removes border highlight when the picture box is unhovered.
        *=============================================================================*/
      void __GlobalMLeaveBox(object source, EventArgs mla) {
         var sender = source as PictureBox;
         Control SenderParent = sender.Parent;
         SenderParent.Paint -= new PaintEventHandler(__GlobalPEventPnl);
         SenderParent.Refresh();
      }

      /*============================================================================*
        *  Function   : __GlobalMEnterLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Puts border highlight to the hovered label.
        *=============================================================================*/
      void __GlobalMEnterLbl(object source, EventArgs mea) {
         var sender = source as Label;
         Control SenderParent = sender.Parent;
         SenderParent.Paint += new PaintEventHandler(__GlobalPEventPnl);
         SenderParent.Refresh();
      }

      /*============================================================================*
        *  Function   : __GlobalMLeaveLbl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mla - Event Argument
        *  Returns    : Void
        *  Description: Removes border highlight when the label is unhovered.
        *=============================================================================*/
      void __GlobalMLeaveLbl(object source, EventArgs mla) {
         var sender = source as Label;
         Control SenderParent = sender.Parent;
         SenderParent.Paint -= new PaintEventHandler(__GlobalPEventPnl);
         SenderParent.Refresh();
      }

      /*============================================================================*
        *  Function   : __MouseClick
        *  Params     : object source - Component that triggered the event.
                        EventArgs ca - Event Argument
        *  Returns    : Void
        *  Description: Handles click events on the search panel.
        *=============================================================================*/
      void __MouseClick(object source, EventArgs ca) {
         var sender = source as Label;
         if(sender.Tag.ToString() == "SrcExit") {
            _SrcResInfoPnl.Hide();
         } else {
            if(sender.Tag.ToString() == "DyBid") {
               _SrcResCatLbl.Text = "Bidding | BidName";
               _SrcResSellPriceLbl.Show();
               _SrcResSellPrice.Show();
               _SrcResBuyIt.Show();
               _SrcResMakeOffer.Show();

               _SrcResLike.Hide();
               _SrcResComment.Hide();
               _SrcResMess.Hide();
               _SrcResFollow.Hide();
            } else if(sender.Tag.ToString() == "DyArt") {
               _SrcResCatLbl.Text = "ArtWork | ArtName";
               _SrcResLike.Show();
               _SrcResComment.Show();

               _SrcResSellPriceLbl.Hide();
               _SrcResSellPrice.Hide();
               _SrcResBuyIt.Hide();
               _SrcResMakeOffer.Hide();
               _SrcResMess.Hide();
               _SrcResFollow.Hide();
            } else if(sender.Tag.ToString() == "DyUser") {
               _SrcResCatLbl.Text = "User | UserName";
               _SrcResMess.Show();
               _SrcResFollow.Show();

               _SrcResSellPriceLbl.Hide();
               _SrcResSellPrice.Hide();
               _SrcResBuyIt.Hide();
               _SrcResMakeOffer.Hide();
               _SrcResLike.Hide();
               _SrcResComment.Hide();

            }
            _SrcResInfoPnl.Show();
         }

      }

      /*==============================INITIALIZATION==============================*/
      Label _SrcResLbl;
      Panel _SrcResInfoPnl;
         PictureBox _SrcResInfoBox;
         Label _SrcResCatLbl;
         Label _SrcResInfo;
         Button _SrcResFollow;
         Button _SrcResMess;
         Button _SrcResLike;
         Button _SrcResComment;
         Label _SrcResSellPrice;
         Button _SrcResBuyIt;
         Button _SrcResMakeOffer;
         Label _SrcResSellPriceLbl;
      Panel _SrcBidPnl;
         Label _SrcBidLbl;
         List<Panel> _BidPnl = new List<Panel>();
         List<PictureBox> _BidBox= new List<PictureBox>();
         List<Label> _BidLbl = new List<Label>();
            static int _BidResCount = 5;
      Panel _SrcArtPnl;
         Label _SrcArtLbl;
         List<Panel> _ArtPnl = new List<Panel>();
         List<PictureBox> _ArtBox= new List<PictureBox>();
         List<Label> _ArtLbl = new List<Label>();
            static int _ArtResCount = 8;
      Panel _SrcUserPnl;
         Label _SrcUserLbl;
         List<Panel> _UserPnl = new List<Panel>();
         List<PictureBox> _UserBox= new List<PictureBox>();
         List<Label> _UserLbl = new List<Label>();
            static int _UserResCount = 4;


   }
}
