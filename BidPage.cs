/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : BidPage.cs
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

   public class BiddingPage : Panel {

    /*============================================================================*
     *  Function   : DisplayBidPage
     *  Params     : None 
     *  Returns    : Void
     *  Description: This serves as the GUI panel for Artsy's bidding page.
     *=============================================================================*/

      public BiddingPage() {
         DisplayBidPage();
      }

      void DisplayBidPage() {
         BackColor = Color.White;
         DoubleBuffered = true;
         AutoScroll = true;

         _BiddedItem = new PictureBox() {
            Size = new Size(250, 300),
            Location = new Point(50, 100),
            Image = Image.FromFile("res/log2.jpg"),
            SizeMode = PictureBoxSizeMode.StretchImage
         };
         this.Controls.Add(_BiddedItem);

         _ItemFullInfo = new Label() {
            Size = new Size(250, 100),
            Font = new Font("Segoe UI", 12),
            Location = new Point(50, 400),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Art full info w/ bidding."
         };
         this.Controls.Add(_ItemFullInfo);

         _ItemName = new Label() {
            Size = new Size(350, 50),
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            Location = new Point(330, 100),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "ITEM NAME: Bidding time left."
         };
         this.Controls.Add(_ItemName);

         _BidPrice[0] = new Label() {
            Size = new Size(350, 40),
            Font = new Font("Segoe UI", 12),
            Location = new Point(330, 170),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Current bid: $$$$$$$$ [Total Bids Count: #]"
         };
         this.Controls.Add(_BidPrice[0]);

         _PriceBox = new TextBox() {
            Size = new Size(180, 40),
            Font = new Font("Segoe UI", 12),
            Location = new Point(500, 230),
         };
         this.Controls.Add(_PriceBox);

         _BidPrice[1] = new Label() {
            Size = new Size(150, 30),
            Font = new Font("Segoe UI", 12),
            Location = new Point(330, 230),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Your bid:"
         };
         this.Controls.Add(_BidPrice[1]);

         _BidPrice[2] = new Label() {
            Size = new Size(100, 40),
            Font = new Font("Segoe UI", 12),
            Location = new Point(330, 300),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Buy now: $$"
         };
         this.Controls.Add(_BidPrice[2]);

         _BuyOption[0] = new Button() {
            Size = new Size(110, 40),
            Font = new Font("Segoe UI", 12),
            Location = new Point(450, 300),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Add to Cart"
         };
         this.Controls.Add(_BuyOption[0]);

         _BuyOption[1] = new Button() {
            Size = new Size(110, 40),
            Font = new Font("Segoe UI", 12),
            Location = new Point(570, 300),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Buy it Now"
         };
         this.Controls.Add(_BuyOption[1]);

         _BidRemind = new Label() {
            Size = new Size(350, 190),
            Font = new Font("Segoe UI", 12),
            Location = new Point(330, 360),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "Bidding Reminders"
         };
         this.Controls.Add(_BidRemind);

         _Tab = new Label() {
            Size = new Size(900, 100),
            Text = "TAB HOLDER ETC",
            BackColor = Color.Gray,
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft
         };
         //this.Controls.Add(_Tab);

         _SellerInfo = new Label() {
            Size = new Size(150, 150),
            Text = "Seller Info",
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(700, 100)
         };
         this.Controls.Add(_SellerInfo);

         _SellerMess = new Label() {
            Size = new Size(150, 280),
            Text = "OP's message regarding the item being sold.",
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(700, 270)
         };
         this.Controls.Add(_SellerMess);

         _ItemAction[0] = new Label() {
            Size = new Size(120, 30),
            Location = new Point(50, 520),
            Text = "Message OP",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
         };
         this.Controls.Add(_ItemAction[0]);

         _ItemAction[1] = new Label() {
            Size = new Size(120, 30),
            Location = new Point(180, 520),
            Text = "Report Item",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
         };
         this.Controls.Add(_ItemAction[1]);

         _Back = new Label() {
            Size = new Size(120, 20),
            Location = new Point(60, 20),
            Text = "◄ BACK",
            Font = new Font("Segoe UI", 15),
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = ColorTranslator.FromHtml("#212121"),
            BackColor = ColorTranslator.FromHtml("#954535")
         };
         _Back.MouseEnter += new EventHandler(__MouseEnter);
         _Back.MouseLeave += new EventHandler(__MouseLeave);
         _Back.Click += new EventHandler(__MouseClick);
         this.Controls.Add(_Back);
      }

      void __MouseEnter(object source, EventArgs e){
         var sender = source as Label;
         sender.BackColor =  ColorTranslator.FromHtml("#212121");
         sender.ForeColor = ColorTranslator.FromHtml("#954535");
      }
      void __MouseLeave(object source, EventArgs e){
         var sender = source as Label;
         sender.ForeColor =  ColorTranslator.FromHtml("#212121");
         sender.BackColor = ColorTranslator.FromHtml("#954535");
      }
      void __MouseClick(object source, EventArgs e){
         this.Hide();
      }

      /*==============================INITIALIZATION==============================*/
      Label _Tab;
      PictureBox _BiddedItem;
      Label _ItemFullInfo;
      Label _ItemName;
      Label _SellerMess;
      Label[] _BidPrice = new Label[3];
      Label _SellerInfo;
      TextBox _PriceBox;
      Label _Back;
      Button[] _BuyOption = new Button[2];
      Label[] _ItemAction = new Label[2];
      Label _BidRemind;
   }

}
