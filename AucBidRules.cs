/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : AucBidRules.cs
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

   public class Rules : Panel {

      public Rules() {
         DisplayRules();
      }

      /*============================================================================*
      *  Function   : DisplayRules
      *  Params     : None 
      *  Returns    : Void
      *  Description: This serves as the GUI panel for Artsy's rules and regulations.
                      (Credits to E-bay for the rules that I used.)
      *=============================================================================*/

      void DisplayRules() {
         AutoSize = true;

         _RuleContainer1 = new Panel() {
   			AutoScroll = true,
            Size = new Size(300, 300),
            Location = new Point(10, 10)
         };
         this.Controls.Add(_RuleContainer1);

         _RulesEveryone[0] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            Text = "LOGO FOR EVERYONE",
            TextAlign = ContentAlignment.MiddleCenter
         };
         _RuleContainer1.Controls.Add(_RulesEveryone[0]);

         _RulesEveryone[1] = new Label() {
            Size = new Size(300, 550),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"     RULES ABOUT GENERAL MEMBER
                          CONDUCT


✓ Artsy members aren't allowed to:

✓ Interfere with the Artsy site

✓ Use profanity on the site

✓ Infringe on Artsy's intellectual property

✓ Create a new account or buy and sell on other existing accounts to avoid restrictions or limits

✓ Make offers to buy or sell outside of Artsy

✓ Falsely report that another member has violated an Artsy policy

✓ In addition to rules that apply to all Artsy members, Artsy also has rules specifically about Feedback, buying, and selling.

✓ When a buyer or seller issue comes up, depending on the particular situation, we may consider an individual's performance history and the specific circumstances, which can influence how we apply our rules and policies. At our discretion, we may choose to be more lenient with policy enforcement, as long as that decision doesn't result in Artsy requiring payment from another member. We reserve the right to do the right thing for both buyers and sellers."
         };
         _RuleContainer1.Controls.Add(_RulesEveryone[1]);

         _RulesEveryone[2] = new Label(){
            Size = new Size(300, 320),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"                  RULES ABOUT IDENTITY

   Artsy members:

✓ Must be at least 18 years old

✓ Can't misrepresent their identities

✓ Must always provide valid and complete contact information and must always have a valid email address

✓ Can't publish the contact information of other members in an online public area

✓ Must choose their user ID according to Artsy rules
            "
         };
         _RuleContainer1.Controls.Add(_RulesEveryone[2]);

         _RulesEveryone[3] = new Label(){
            Size = new Size(300, 330),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"  RULES ABOUT COMMUNICATING WITH
                  OTHER ARTSY USERS

   Artsy members:

✓ Can't use our member-to-member contact options to send spam or threats

✓ Must follow Artsy's rules for Artsy Groups, Artsy discussion boards, and community content (including reviews and guides)"
         };
         _RuleContainer1.Controls.Add(_RulesEveryone[3]);

            _TabEveryone[0] = new Label() {
               Size = new Size(100, 180),
               Location = new Point(310, 10),
               BackColor = Color.Gray
            };
            this.Controls.Add(_TabEveryone[0]);

            for(int loop = 1; loop < 4; loop++) {
               _TabEveryone[loop] = new Label() {
                  Tag = loop,
                  Size = new Size(100, 60),
                  Location = new Point(0, 0 + (loop * 60 - 60)),
                  BackColor = Color.Pink,
                  Text = _RuleHeader1[loop - 1],
                  TextAlign = ContentAlignment.MiddleCenter
               };
               _TabEveryone[0].Controls.Add(_TabEveryone[loop]);
               _TabEveryone[loop].Click += new EventHandler(__ChangePanelContent);
            }

         _RuleContainer2 = new Panel() {
            Size = new Size(300, 300),
            Location = new Point(450, 10),
            AutoScroll = true
         };
         this.Controls.Add(_RuleContainer2);

         _RulesForBuyers[0] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            Text = "LOGO FOR BUYERS",
            TextAlign = ContentAlignment.MiddleCenter
         };
         _RuleContainer2.Controls.Add(_RulesForBuyers[0]);

         _RulesForBuyers[1] = new Label() {
            Size = new Size(300, 1700),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"         RULES ABOUT BIDDING AND PAYING

✓ You can't use Artsy if your account contains false contact information.

✓ Buyers and sellers sometimes need to be able to get in touch with each other, and we need to be able to contact our members.

✓ You must pay for any item you commit to buying.

✓ Some Artsy sellers use an auction-style format, allowing you to bid on an item. Bidding is fun, but keep in mind that each bid you make is a binding contract to buy the item if you win. The same is true for Buy It Now purchases. Not paying for an item after you agree to buy it has negative consequences, explained in our unpaid item policy.

✓ You can only bid if you really intend to buy the item, even if you're making a non-binding bid.

✓ You can only make non-binding bids on certain items, such as real estate and vehicles. This type of bid still means that you intend to buy the item. The bottom line is, don't place a bid unless you mean to buy the item.

✓ You can't bid on your own item.

✓ We call this shill bidding and it not only violates our policies, it's against the law in many places.

✓ Be careful about bidding on several items if you only want one.

✓ If you're the winning bidder of more than one auction-style listing, you need to purchase all the items you've won, even if they're the same or similar.

✓ You can only retract a bid under specific circumstances.

✓ For example, if you meant to bid $10.00 but accidentally bid $1,000.00, you can retract the bid. Even then, you need to bid the amount you originally intended immediately. Never use bid retraction to manipulate the bidding process. Bid manipulation is unfair, and it has serious consequences. Learn more about retracting or canceling your bid.

✓ Make sure that you read the listing description before you bid.

✓ Many of the problems buyers and sellers encounter are the result of simple misunderstandings about what is for sale and the terms of the sale. For example, some sellers only want to sell to bidders who live in a certain country, or who will pay using PayPal. Only bid on or buy an item if you can meet the requirements described in the listing. If you bid on an item and you don't meet the seller's requirements, we consider that unwelcome and malicious buying.

✓ If you know the seller, you can't bid on the item with the intent to increase its price or desirability artificially.

✓ This rule applies to family, friends, roommates, employees, and online connections.

✓ Buying items from someone just to increase their Feedback score or improve their search standing is called shill bidding, and it's against our policies.

✓ You can't offer to buy items outside of Artsy.

✓ Our policies don't cover items bought outside of our site. If you buy items outside of Artsy, we don't protect you against fraud. Sellers must follow the same rule, so if a seller offers to sell you something outside of Artsy, don't accept the offer. For more information, see our rules for everyone.

✓ If you buy an item from a seller in another country, you can't ask the seller to mark the item as a gift in the customs declaration.

✓ This is illegal, and against our policies. Learn more about our rules against encouraging illegal activity.

✓ When you bid on or buy a vehicle in Artsy Motors, we may share your contact information with sellers.

✓ Sellers may also contact you about that vehicle or a similar one for sale. Learn more about Artsy Motors bidding.",
         };
         _RuleContainer2.Controls.Add(_RulesForBuyers[1]);

         _RulesForBuyers[2] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"                   RULES ABOUT FEEDBACK



✓ You can't abuse the Feedback system.

✓ This means you can't threaten to leave a seller negative Feedback if that seller won't do something that wasn't promised in the original listing. This is called Feedback extortion and is against our policy.

✓ Also, you can't leave Feedback if you're only doing it to help increase a seller's Feedback score. This is a type of Feedback manipulation and is also not allowed."
         };
         _RuleContainer2.Controls.Add(_RulesForBuyers[2]);

         _RulesForBuyers[3] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"        IF YOU'RE HAVING A PROBLEM WITH A
                                    SELLER


✓ Be honest and have good intentions when you try to resolve a transaction problem. Learn more about what to do if you don't receive an item or it doesn't match the listing description.

✓ Attempts to manipulate the Artsy Money Back Guarantee are prohibited and can have serious consequences.

✓ You can't try to contact other potential buyers to ''warn'' them about a seller. This is called transaction interference. If you have a concern about a seller's behavior, report it to us and we'll investigate."
         };
         _RuleContainer2.Controls.Add(_RulesForBuyers[3]);

         _RulesForBuyers[4] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"                    IF YOU'RE ALSO A SELLER


✓ If you're also a seller, please be sure to read our rules for sellers, and make sure that your listings follow our guidelines."
         };
         _RuleContainer2.Controls.Add(_RulesForBuyers[4]);

            _TabForBuyers[0] = new Label() {
               Size = new Size(100, 240),
               Location = new Point(750, 10),
               BackColor = Color.Gray
            };
            this.Controls.Add(_TabForBuyers[0]);

            for(int loop = 1; loop < 5; loop++) {
               _TabForBuyers[loop] = new Label() {
                  Tag = loop,
                  Size = new Size(100, 60),
                  Location = new Point(0, 0 + (loop * 60 - 60)),
                  BackColor = Color.Pink,
                  Text = _RuleHeader2[loop - 1],
                  TextAlign = ContentAlignment.MiddleCenter
               };
               _TabForBuyers[0].Controls.Add(_TabForBuyers[loop]);
               _TabForBuyers[loop].Click += new EventHandler(__ChangePanelContent);
            }

         _RuleContainer3 = new Panel() {
            Size = new Size(300, 300),
            Location = new Point(10, 330)
         };
         this.Controls.Add(_RuleContainer3);

         _RulesForSellers[0] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            Text = "LOGO FOR SELLERS",
            TextAlign = ContentAlignment.MiddleCenter
         };
         _RuleContainer3.Controls.Add(_RulesForSellers[0]);

         _RulesForSellers[1] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Helvetica", 10),
            TextAlign = ContentAlignment.TopLeft,
            Text = @"                        RULES FOR SELLER
                                 Overview

            Artsy's policies help to create a safer, fair and enjoyable trading experience for all Artsy members. As a seller, you are responsible for reviewing and understanding Artsy's selling policies, as well as all applicable laws and regulations outlined in the User Agreement. We recommend that you learn about Artsy's selling policies before you list an item. This will help you to avoid accidentally breaking rules. Also, Artsy's selling policies are updated often to address emerging issues, so it is important to check them regularly for changes. Make sure you follow these guidelines. If you don't, you may be subject to a range of actions, including limits of your buying and selling privileges and suspension of your account."
         };
         _RuleContainer3.Controls.Add(_RulesForSellers[1]);

            _TabForSellers[0] = new Label() {
               Size = new Size(100, 60),
               Location = new Point(310, 330),
               BackColor = Color.Gray
            };
            this.Controls.Add(_TabForSellers[0]);

            for(int loop = 1; loop < 2; loop++) {
               _TabForSellers[loop] = new Label() {
                  Tag = loop,
                  Size = new Size(100, 60),
                  Location = new Point(0, 0 + (loop * 60 - 60)),
                  BackColor = Color.Pink,
                  Text = _RuleHeader3[loop - 1],
                  TextAlign = ContentAlignment.MiddleCenter
               };
               _TabForSellers[0].Controls.Add(_TabForSellers[loop]);
               _TabForSellers[loop].Click += new EventHandler(__ChangePanelContent);
            }

         _RuleContainer4 = new Panel() {
            Size = new Size(300, 300),
            Location = new Point(450, 330)
         };
         this.Controls.Add(_RuleContainer4);

         _SiteInfo[0] = new Label() {
            Size = new Size(300, 300),
            BackColor = Color.White,
            Font = new Font("Segoe UI", 15, FontStyle.Bold),
            Text = "LOGO FOR SITE INFO",
            TextAlign = ContentAlignment.MiddleCenter
         };
         _RuleContainer4.Controls.Add(_SiteInfo[0]);

            _TabForSite[0] = new Label() {
               Size = new Size(100, 180),
               Location = new Point(750, 330),
               BackColor = Color.Gray
            };
            this.Controls.Add(_TabForSite[0]);

            for(int loop = 1; loop < 4; loop++) {
               _TabForSite[loop] = new Label() {
                  Tag = loop,
                  Size = new Size(100, 60),
                  Location = new Point(0, 0 + (loop * 60 - 60)),
                  BackColor = Color.Pink,
                  Text = _RuleHeader4[loop - 1],
                  TextAlign = ContentAlignment.MiddleCenter
               };
               _TabForSite[0].Controls.Add(_TabForSite[loop]);
               _TabForSite[loop].Click += new EventHandler(__ChangePanelContent);
            }

      }

      void __ChangePanelContent(object source, EventArgs cea) {
         Label sender = source as Label;

         new Thread(() => {
            for(int loop = 1; loop < 4; loop++) {
               if(sender.Text == _TabEveryone[loop].Text) {
                  _TabEveryone[loop].ForeColor = Color.Pink;
                  _TabEveryone[loop].BackColor = Color.Black;
                  _RulesEveryone[Convert.ToInt32(_TabEveryone[loop].Tag.ToString())].BringToFront();
               } else {
                  _TabEveryone[loop].ForeColor = Color.Black;
                  _TabEveryone[loop].BackColor = Color.Pink;
                  _RulesEveryone[Convert.ToInt32(_TabEveryone[loop].Tag.ToString())].SendToBack();
               }
            }

            for(int loop = 1; loop < 5; loop++) {
               if(sender.Text == _TabForBuyers[loop].Text) {
                  _TabForBuyers[loop].ForeColor = Color.Pink;
                  _TabForBuyers[loop].BackColor = Color.Black;
                  _RulesForBuyers[Convert.ToInt32(_TabForBuyers[loop].Tag.ToString())].BringToFront();
               } else {
                  _TabForBuyers[loop].ForeColor = Color.Black;
                  _TabForBuyers[loop].BackColor = Color.Pink;
                  _RulesForBuyers[Convert.ToInt32(_TabForBuyers[loop].Tag.ToString())].SendToBack();
               }
            }

            for(int loop = 1; loop < 2; loop++) {
               if(sender.Text == _TabForSellers[loop].Text) {
                  _TabForSellers[loop].ForeColor = Color.Pink;
                  _TabForSellers[loop].BackColor = Color.Black;
                  _RulesForSellers[Convert.ToInt32(_TabForSellers[loop].Tag.ToString())].BringToFront();
               } else {
                  _TabForSellers[loop].ForeColor = Color.Black;
                  _TabForSellers[loop].BackColor = Color.Pink;
                  _RulesForSellers[Convert.ToInt32(_TabForSellers[loop].Tag.ToString())].SendToBack();
               }
            }

            for(int loop = 1; loop < 4; loop++) {
               if(sender.Text == _TabForSite[loop].Text) {
                  _TabForSite[loop].ForeColor = Color.Pink;
                  _TabForSite[loop].BackColor = Color.Black;
               } else {
                  _TabForSite[loop].ForeColor = Color.Black;
                  _TabForSite[loop].BackColor = Color.Pink;
               }
            }
         }).Start();

      }

      /*==============================INITIALIZATION==============================*/
      Panel _RuleContainer1;
      Label[] _RulesEveryone = new Label[4];
         Label[] _TabEveryone = new Label[4];
         String[] _RuleHeader1 = {"General Member Conduct", "Identity", "Communicating To Others"};

      Panel _RuleContainer2;
      Label[] _RulesForBuyers = new Label[5];
         Label[] _TabForBuyers = new Label[5];
         String[] _RuleHeader2 = {"Bidding && Paying", "Feedback", "Problem with a Seller", "Also a Seller"};

      Panel _RuleContainer3;
      Label[] _RulesForSellers = new Label[2];
         Label[] _TabForSellers = new Label[2];
         String[] _RuleHeader3 = {"Overview"};

      Panel _RuleContainer4;
      Label[] _SiteInfo = new Label[4];
         Label[] _TabForSite = new Label[4];
         String[] _RuleHeader4 = {"About", "Contact Us", "Blah"};


   }
}
