/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : News.cs
* Version     : v1.0
* Author      : Gensaya, Carl Jerwin F.
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Artsy {
	public class News : Panel {

		public News() {
			_DisplayNews();
		}

    /*============================================================================*
     *  Function   : _DisplayNews
     *  Params     : None
     *  Returns    : Void
     *  Description: Shows panel that contains Artsy's new and latest happenings.
     *=============================================================================*/
		void _DisplayNews() {

         _NewsDetails = new Panel() {
            Size = new Size(650, 400),
            BackColor = Color.FromArgb(50, Color.Gray),
            Location = new Point(100, 15),
         };
         this.Controls.Add(_NewsDetails);
         _NewsDetails.Hide();

            _NewsInfo[0] = new Label() {
               AutoSize = true,
               Text = "DOLPHY, PUMAMAW NA.",
               TextAlign = ContentAlignment.TopCenter,
               Font = new Font("Segoe UI", 12, FontStyle.Bold),
               Location = new Point(5, 5),
					BackColor = Color.Transparent
            };
            _NewsDetails.Controls.Add(_NewsInfo[0]);

            _NewsInfo[1] = new Label() {
               AutoSize = true,
               Text = "By: *Author* Date: ",
               Font = new Font("Segoe UI", 10),
               TextAlign = ContentAlignment.TopCenter,
               Location = new Point(5, _NewsInfo[0].Height + 3),
					BackColor = Color.Transparent
            };
            _NewsDetails.Controls.Add(_NewsInfo[1]);

            _NewsPic = new PictureBox() {
               SizeMode = PictureBoxSizeMode.StretchImage,
               Size = new Size(250, 250),
               Location = new Point(0, _NewsInfo[0].Height + _NewsInfo[1].Height + 10),
               Image = Image.FromFile("res/janno.jpg")
            };
            _NewsDetails.Controls.Add(_NewsPic);

            _DetailsPnl = new Panel() {
               Size = new Size(400, 400),
               Location = new Point(250, 0),
               BackColor = Color.FromArgb(50, 0, 128, 128),
               AutoScroll = true
            };
            _NewsDetails.Controls.Add(_DetailsPnl);

               _NewsInfo[2] = new Label() {
                  AutoSize = true,
                  Font = new Font("Segoe UI", 10),
                  Text = @"Insert news article here.",
                  Location = new Point(2, 2),
						BackColor = Color.Transparent
               };
               _DetailsPnl.Controls.Add(_NewsInfo[2]);

         _MainContainer = new Panel() {
   			AutoScroll = true,
				Size = new Size(910, 600),
            Location = new Point(0, 0),
				Dock = DockStyle.Fill
         };
         _MainContainer.Click += new EventHandler(__PanelClick);
         this.Controls.Add(_MainContainer);

			for(int loop = 0; loop < _NewsCount; loop++) {

				_NewsContainer[loop] = new Label() {
					Size = new Size(650, 300),
					Location = new Point(x, y),
					BackColor = ColorTranslator.FromHtml("#4d4d4d"),
				};
				_MainContainer.Controls.Add(_NewsContainer[loop]);

					_NewsImage[loop] = new PictureBox() {
						Size = new Size(350, 300),
						Location = new Point(0, 0),
						Image = Image.FromFile("res/img.jpg"),
						SizeMode = PictureBoxSizeMode.StretchImage
					};
					_NewsContainer[loop].Controls.Add(_NewsImage[loop]);

					_NewsHeader[loop] = new Label() {
						Size = new Size(350, 30),
						Location = new Point(0, 0),
						Text = Header,
						Font = new Font("Segoe UI", 15),
						BackColor = Color.FromArgb(90, ColorTranslator.FromHtml("#333333")),
						ForeColor = ColorTranslator.FromHtml("#9fc6c6"),
						TextAlign = ContentAlignment.MiddleLeft
					};
					_NewsImage[loop].Controls.Add(_NewsHeader[loop]);

					Panel _NewsContentPnl = new Panel() {
						Size = new Size(313, 250),
						AutoScroll = true,
						BackColor = ColorTranslator.FromHtml("#868079"),
						Location = new Point(355, 5)
					};
					_NewsContainer[loop].Controls.Add(_NewsContentPnl);

						_NewsContent[loop] = new Label() {
							MaximumSize = new Size(300, 0),
							AutoSize = true,
							Location = new Point(0, 0),
							TextAlign = ContentAlignment.TopLeft,
							Font = new Font("Helvetica", 9),
							BackColor = Color.Transparent,
							Text = @"Help us get this started
Everyone's excited
We'll spend the whole time groovin'
Cos what we really like
Is to party on Friday night

I got my friends and we're here to groove (na na na na na)
Nothing's wrong, ain't nuthin' to prove (na na na na na)
Don't need no cash just bring a friend (na na na na na)
Cos we're gonna party all night again (na na na na na)

1 can make a party
2 is not enough to get down
3 you'll still get lonely, cos tonight's the night for crowds
You can make it better
We can help a little bit too
Us and you together there ain't nothin we can't do

Help us get this started
(Cos it's time to call your friends)
Everyone's excited
(Cos it's Friday night again)
We'll spend the whole time groovin'
(Just like we do)
Cos what we really like
Is to party on Friday night"
						};
						_NewsContentPnl.Controls.Add(_NewsContent[loop]);

					_NewsWriter[loop] = new Label() {
						AutoSize = true,
						Text = "By: *Author Name Here*",
						Font = new Font("Helvetica", 9, FontStyle.Italic),
						ForeColor = Color.White,
						BackColor = ColorTranslator.FromHtml("#333333"),
						Location = new Point(405, 300),
						TextAlign = ContentAlignment.BottomLeft
					};
					_NewsContainer[loop].Controls.Add(_NewsWriter[loop]);

					_ReadCountLbl[loop] = new Label() {
						Tag = loop,
						Size = new Size(45, 40),
						Text = "#Reads",
						Font = new Font("Helvetica", 8),
						ForeColor = Color.White,
						BackColor = ColorTranslator.FromHtml("#333333"),
						TextAlign = ContentAlignment.MiddleCenter,
						Location = new Point(360, 260)
					};
					_ReadCountLbl[loop].MouseEnter += new EventHandler(__MouseEnter);
					_ReadCountLbl[loop].MouseLeave += new EventHandler(__MouseLeave);

					_ReadCount[loop] = new Label() {
						Tag = loop,
						Size = new Size(45, 7),
						Text = "1310",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 7),
						ForeColor = Color.White,
						BackColor = Color.FromArgb(80, Color.Black),
						Location = new Point(0, 33)
					};
					_ReadCountLbl[loop].Controls.Add(_ReadCount[loop]);

					_ViewContent[loop] = new Label() {
                  Tag = loop,
						Size = new Size(80, 50),
						Location = new Point(575, 260),
						Text = "Read >",
						Font = new Font("Segoe UI Semibold", 15),
						TextAlign = ContentAlignment.MiddleCenter,
						BackColor = ColorTranslator.FromHtml("#4d4d4d"),
						ForeColor = Color.White
					};
               _ViewContent[loop].Click += new EventHandler(__MouseClick);
					_ViewContent[loop].MouseEnter += new EventHandler(__MouseEnter);
					_ViewContent[loop].MouseLeave += new EventHandler(__MouseLeave);

					_NewsContainer[loop].Controls.Add(_ReadCountLbl[loop]);
					_NewsContainer[loop].Controls.Add(_ViewContent[loop]);

					y += 310;
			}
		}

		/*============================================================================*
	     *  Function   : __MouseEnter
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs e   - Event Argument
	     *  Returns    : Void
	     *  Description: Show highlight read counter of a news article.
	     *=============================================================================*/	
		void __MouseEnter(object source, EventArgs e){
			var sender = source as Label;

			if(sender.Text == "#Reads") {
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = ColorTranslator.FromHtml("#3CB371");
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(45, 10);
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 30);
				_NewsWriter[Convert.ToInt32(sender.Tag.ToString())].ForeColor = ColorTranslator.FromHtml("#3CB371");
				new Thread(() => {
					for(int loop = 0; loop <= 18; loop++) {
						try {
							_NewsWriter[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(405, 300 - loop);
							Thread.Sleep(2);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}
				}).Start();
			} else {
				sender.ForeColor = ColorTranslator.FromHtml("#F08080");
			}
		}

		/*============================================================================*
	     *  Function   : __MouseEnter
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs e   - Event Argument
	     *  Returns    : Void
	     *  Description: Hide highlight read counter of a news article.
	     *=============================================================================*/
		void __MouseLeave(object source, EventArgs e){
			var sender = source as Label;

			if(sender.Text == "#Reads") {
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(80, Color.Black);
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(45, 7);
				_ReadCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 33);
				_NewsWriter[Convert.ToInt32(sender.Tag.ToString())].ForeColor = Color.White;
				new Thread(() => {
					for(int loop = 0; loop <= 15; loop++) {
						try {
							_NewsWriter[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(405, 285 + loop);
							Thread.Sleep(2);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}
				}).Start();
			} else {
				sender.ForeColor = Color.White;
			}
		}

	    /*============================================================================*
	     *  Function   : __MouseClick
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs ca  - Event Argument
	     *  Returns    : Void
	     *  Description: Shows content of the news content clicked.
	     *=============================================================================*/	
      void __MouseClick(object source, EventArgs ca) {
         var sender = source as Label;
         Bitmap pic = new Bitmap(_NewsImage[Convert.ToInt32(sender.Tag.ToString())].Image);
         _MainContainer.HorizontalScroll.Enabled = false;
         _NewsPic.Image = pic;
         _NewsDetails.Show();
      }

        /*============================================================================*
	     *  Function   : __PanelClick
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs ca  - Event Argument
	     *  Returns    : Void
	     *  Description: Hide content of the news content clicked.
	     *=============================================================================*/
      void __PanelClick(object source, EventArgs ca) {
         var sender = source as Panel;
         _NewsDetails.Hide();
      }

		// void __ThreadsFunc(String _ThreadCall) {
		// 	if(_ThreadCall == "WriterShow") {

		// 	} else if(_ThreadCall == "WriterHide") {

		// 	}
		// }

      /*==============================INITIALIZATION==============================*/
		int x = 100;
		int y = 10;
		static int _NewsCount = 5;

		string Header = "HEADER";
		string Content = "contents contents contents";

      Panel _MainContainer;
		Label[] _NewsContainer = new Label[_NewsCount];
		Label[] _NewsWriter = new Label[_NewsCount];
		Label[] _NewsHeader = new Label[_NewsCount];
		Label[] _NewsContent = new Label[_NewsCount];
		Label[] _ViewContent = new Label[_NewsCount];
		PictureBox[] _NewsImage = new PictureBox[_NewsCount];
		Label[] _ReadCountLbl = new Label[_NewsCount];
			Label[] _ReadCount = new Label[_NewsCount];

      Panel _NewsDetails;
         Panel _DetailsPnl;
         Label[] _NewsInfo = new Label[10];
         PictureBox _NewsPic;
	}
}
