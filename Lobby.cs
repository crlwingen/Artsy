/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Lobby.cs
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
	public class Lobby : Panel {

		public Lobby() {
			__DisplayLobby();
		}

		/*============================================================================*
	     *  Function   : __DisplayLobby
	     *  Params     : None 
	     *  Returns    : Void
	     *  Description: This serves as the GUI panel for Artsy's users lobby
	                     (like FB's timeline).
	     *=============================================================================*/

		void __DisplayLobby() {

			BackColor = ColorTranslator.FromHtml("#212121");
			DoubleBuffered = true;
			AutoSize = true;

			_RecHL = new Label();
			_RecHL.Hide();
			this.Controls.Add(_RecHL);

			_UserPostLbl = new Label() {
				Size = new Size(500, 245),
				Location = new Point(50, 10),
				BackColor = Color.Transparent
			};
			this.Controls.Add(_UserPostLbl);

				_UserPostArt = new Label() {
					Tag = "PostArt",
					Size = new Size(70, 70),
					Text = "Artwork",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Helvetica", 10, FontStyle.Bold),
					Location = new Point(0, 5),
					BackColor = ColorTranslator.FromHtml("#7a1f1f")
				};
				_UserPostLbl.Controls.Add(_UserPostArt);
				_UserPostArt.MouseEnter += new EventHandler(__MouseEnter);
				_UserPostArt.MouseLeave += new EventHandler(__MouseLeave);
				_UserPostArt.Click += new EventHandler(__MouseClick);

					_UserArtPnl = new Panel() {
						Size = new Size(425, 0),
						Location = new Point(75, 0),
						BackColor = ColorTranslator.FromHtml("#7a1f1f")
					};
					_UserPostLbl.Controls.Add(_UserArtPnl);

					_UserArtBox = new PictureBox() {
						Size = new Size(285, 235),
						Location = new Point(5, 5),
						SizeMode = PictureBoxSizeMode.StretchImage,
						BackColor = Color.White
					};
					_UserArtPnl.Controls.Add(_UserArtBox);

					Label _ArtCaption = new Label() {
						Text = "Art Caption",
						TextAlign = ContentAlignment.MiddleCenter,
						AutoSize = true,
						Location = new Point(325, 5),
						Font = new Font("Helvetica", 10),
						ForeColor = Color.White
					};
					_UserArtPnl.Controls.Add(_ArtCaption);

					RichTextBox _ArtCaptionTxt = new RichTextBox() {
						Multiline = true,
						Size = new Size(125, 180),
						Location = new Point(295, 25),
					};
					_UserArtPnl.Controls.Add(_ArtCaptionTxt);

					Button _ArtBtn = new Button() {
						Size = new Size(125, 30),
						Text = "UPLOAD",
						FlatStyle = FlatStyle.Flat,
						Location = new Point(295, 210)
					};
					_UserArtPnl.Controls.Add(_ArtBtn);

				_UserPostAuc = new Label() {
					Tag = "PostAuc",
					Size = new Size(70, 70),
					Text = "Auction",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Helvetica", 10, FontStyle.Bold),
					Location = new Point(0, 85),
					BackColor = ColorTranslator.FromHtml("#395e60")
				};
				_UserPostLbl.Controls.Add(_UserPostAuc);
				_UserPostAuc.MouseEnter += new EventHandler(__MouseEnter);
				_UserPostAuc.MouseLeave += new EventHandler(__MouseLeave);
				_UserPostAuc.Click += new EventHandler(__MouseClick);

					_UserAucPnl = new Panel() {
						Size = new Size(425, 0),
						Location = new Point(75, 0),
						BackColor = ColorTranslator.FromHtml("#395e60")
					};
					_UserPostLbl.Controls.Add(_UserAucPnl);

						Button _AucButtonFile = new Button() {
							Size = new Size(150, 25),
							FlatStyle = FlatStyle.Flat,
							Text = "Select From File",
							Location = new Point(5, 5)
						};
						_UserAucPnl.Controls.Add(_AucButtonFile);

						Button _AucButtonColl = new Button() {
							Size = new Size(150, 25),
							FlatStyle = FlatStyle.Flat,
							Text = "Select From Collection",
							Location = new Point(5, 35)
						};
						_UserAucPnl.Controls.Add(_AucButtonColl);

						PictureBox _AucBox = new PictureBox() {
							Size = new Size(150, 150),
							SizeMode = PictureBoxSizeMode.StretchImage,
							BackColor = Color.Gray,
							Location = new Point(5, 65)
						};
						_UserAucPnl.Controls.Add(_AucBox);

						RichTextBox _AucDetails = new RichTextBox() {
							Size = new Size(260, 210),
							Multiline = true,
							Location = new Point(160, 5),
							Font = new Font("Helvetica", 9)
						};
						_UserAucPnl.Controls.Add(_AucDetails);

						Button _AucOkBtn = new Button() {
							Size = new Size(50, 20),
							Text = "OK",
							FlatStyle = FlatStyle.Flat,
							Location = new Point(370, 220)
						};
						_UserAucPnl.Controls.Add(_AucOkBtn);

				_UserPostStat = new Label() {
					Tag = "PostStat",
					Size = new Size(70, 70),
					Text = "Status",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Helvetica", 10, FontStyle.Bold),
					Location = new Point(0, 165),
					BackColor = ColorTranslator.FromHtml("#916a08")
				};
				_UserPostLbl.Controls.Add(_UserPostStat);
				_UserPostStat.MouseEnter += new EventHandler(__MouseEnter);
				_UserPostStat.MouseLeave += new EventHandler(__MouseLeave);
				_UserPostStat.Click += new EventHandler(__MouseClick);

					_UserStatPnl = new Panel() {
						Size = new Size(425, 0),
						Location = new Point(75, 0),
						BackColor = ColorTranslator.FromHtml("#916a08")
					};
					_UserPostLbl.Controls.Add(_UserStatPnl);

					RichTextBox _UserStatBox = new RichTextBox() {
						Multiline = true,
						Size = new Size(400, 150),
						Font = new Font("Helvetica", 10),
						Location = new Point(10, 10)
					};
					_UserStatPnl.Controls.Add(_UserStatBox);

					Button _UserStatBtn = new Button() {
						Size = new Size(150, 20),
						Text = "Post",
						FlatStyle = FlatStyle.Flat,
						Font = new Font("Helvetica", 10),
						Location = new Point(260, 205)
					};
					_UserStatPnl.Controls.Add(_UserStatBtn);

					Label _ArtSyTot = new Label() {
						Text = @"SPEAK OUT YOUR MIND",
						TextAlign = ContentAlignment.MiddleCenter,
						ForeColor = ColorTranslator.FromHtml("#0059b3"),
						AutoSize = true,
						Location = new Point(90, 40)
					};
					_UserPostLbl.Controls.Add(_ArtSyTot);

			for(int loop = 0; loop < _PostCount; loop++) {

				_CommentBoxHolder[loop] = new Label() {
					Location = new Point(155, 300 + y),
					Size = new Size(400, 50),
				};
				this.Controls.Add(_CommentBoxHolder[loop]);
				_CommentBoxHolder[loop].Hide();

				_CommentBox[loop] = new RichTextBox() {
					Size = new Size(345, 50),
					Location = new Point(0, 0),
					Font = new Font("Segoe UI", 10),
					Multiline = true,
					BackColor = ColorTranslator.FromHtml("#E0E1E1")
				};
				_CommentBoxHolder[loop].Controls.Add(_CommentBox[loop]);

				_CommentBoxOk[loop] = new Label() {
					Tag = loop,
					Size = new Size(50, 50),
					Location = new Point(345, 0),
					TextAlign = ContentAlignment.MiddleCenter,
					BackColor = Color.FromArgb(90, Color.Gray),
					Text = "OK"
				};
				_CommentBoxHolder[loop].Controls.Add(_CommentBoxOk[loop]);
				_CommentBoxOk[loop].Click += new EventHandler(__MouseClick);
				_CommentBoxOk[loop].MouseEnter += new EventHandler(__MouseEnter);
				_CommentBoxOk[loop].MouseLeave += new EventHandler(__MouseLeave);

				_PostContainer[loop] = new Label() {
					Size = new Size(500, 350),
					Location = new Point(x, y),
					BackColor = Color.FromArgb(100, ColorTranslator.FromHtml("#E0E0E0"))
				};
				this.Controls.Add(_PostContainer[loop]);

				_PostImage[loop] = new PictureBox() {
					Size = new Size(500, 250),
					Location = new Point(0, 50),
					Text = "IMAGE CONTAINER",
					Image = Image.FromFile("res/log2.jpg"),
					SizeMode = PictureBoxSizeMode.StretchImage,
				};
				_PostContainer[loop].Controls.Add(_PostImage[loop]);

				_PostUsername[loop] = new Label() {
					Size = new Size(150, 40),
					Location = new Point(50, 10),
					AutoSize = true,
					BackColor = Color.Transparent,
					Text = "DaVinci001",
					Font = new Font("Segoe UI", 14),
					TextAlign = ContentAlignment.MiddleLeft
				};
				_PostContainer[loop].Controls.Add(_PostUsername[loop]);

				var path = new GraphicsPath();
				path.AddEllipse(0, 0, 40, 40);

				_PostIcon[loop] = new PictureBox() {
					Size = new Size(40, 40),
					Location = new Point(5, 5),
					BackColor = ColorTranslator.FromHtml("#212121"),
					Region = new Region(path),
					SizeMode = PictureBoxSizeMode.StretchImage,
					Image = Image.FromFile("res/log1.jpg")
				};
				_PostContainer[loop].Controls.Add(_PostIcon[loop]);

				_PostComment[loop] = new Label() {
					Size = new Size(480, 170),
					Location = new Point(10, 320),
					BackColor = Color.Gray,
					ForeColor = ColorTranslator.FromHtml("#212121"),
					Text = "CAPTION AND COMMENTS",
					TextAlign = ContentAlignment.MiddleCenter
				};

				_CommentButton[loop] = new Label() {
					Tag = loop,
					Size = new Size(50, 50),
					Location = new Point(0, 300),
					BackColor = ColorTranslator.FromHtml("#424242"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "C",
					Font = new Font("Raleway Bold", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_CommentButton[loop].MouseEnter += new EventHandler(__MouseEnter);
				_CommentButton[loop].MouseLeave += new EventHandler(__MouseLeave);
				_CommentButton[loop].Click += new EventHandler(__MouseClick);
				_PostContainer[loop].Controls.Add(_CommentButton[loop]);

				_LikeButton[loop] = new Label() {
					Tag = loop,
					Size = new Size(50, 50),
					Location = new Point(52, 300),
					BackColor = ColorTranslator.FromHtml("#424242"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "L",
					Font = new Font("Raleway Bold", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_LikeButton[loop].MouseEnter += new EventHandler(__MouseEnter);
				_LikeButton[loop].MouseLeave += new EventHandler(__MouseLeave);
				_LikeButton[loop].Click += new EventHandler(__MouseClick);
				_PostContainer[loop].Controls.Add(_LikeButton[loop]);

				_LikeCount[loop] = new Label() {
					Tag = loop,
					Size = new Size(50, 10),
					Location = new Point(0, 40),
					BackColor = Color.FromArgb(70, ColorTranslator.FromHtml("#212121")),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "300",
					Font = new Font("Raleway Thin", 10),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_LikeCount[loop].MouseEnter += new EventHandler(__MouseEnter);
				_LikeCount[loop].MouseLeave += new EventHandler(__MouseLeave);
				_LikeCount[loop].Click += new EventHandler(__MouseClick);
				_LikeButton[loop].Controls.Add(_LikeCount[loop]);

				_LikersPnl[loop] = new Panel() {
					Location = new Point(570, y),
					Size = new Size(270, 350),
					BackColor = ColorTranslator.FromHtml("#808080"),
				};
				this.Controls.Add(_LikersPnl[loop]);
				_LikersPnl[loop].Hide();

					_LikersPnlHead[loop] = new Label() {
						AutoSize = true,
						BackColor = Color.Transparent,
						ForeColor = ColorTranslator.FromHtml("#563434"),
						Text = "Users who liked this post:",
						Font = new Font("Helvetica", 11, FontStyle.Bold),
						Location = new Point(5, 5)
					};
					_LikersPnl[loop].Controls.Add(_LikersPnlHead[loop]);

					Panel _LikersHolder = new Panel() {
						Size = new Size(290, 330),
						Location = new Point(0, 30),
						BackColor = Color.Transparent,
						AutoScroll = true
					};
					_LikersPnl[loop].Controls.Add(_LikersHolder);

					for(int likeloop = 0; likeloop < _LikerCount; likeloop++) {
						_LikersPnlBox[likeloop] = new PictureBox() {
							Size = new Size(50, 50),
							SizeMode = PictureBoxSizeMode.StretchImage,
							Location = new Point(10, 10 + 65 * likeloop),
							Image = Image.FromFile("res/user.jpg")
						};
						_LikersHolder.Controls.Add(_LikersPnlBox[likeloop]);

						_LikersPnlName[likeloop] = new Label() {
							Size = new Size(100, 50),
							TextAlign = ContentAlignment.MiddleCenter,
							Location = new Point(70, 0 + 65 * likeloop),
							Text = "*Insert Name Here*",
							Font = new Font("Helvetica", 8),
							BackColor = Color.Transparent
						};
						_LikersHolder.Controls.Add(_LikersPnlName[likeloop]);

						_LikersPnlFollow[likeloop] = new Button() {
							Size = new Size(60, 40),
							Text = "Follow",
							Font = new Font("Helvetica", 10, FontStyle.Bold),
							ForeColor = Color.White,
							FlatStyle = FlatStyle.Flat,
							Location = new Point(200, 15 + 65 * likeloop)
						};
						_LikersHolder.Controls.Add(_LikersPnlFollow[likeloop]);
					}

				_PostCommentCount[loop] = new Label() {
					Tag = loop,
					Size = new Size(50, 10),
					Location = new Point(0, 40),
					Text = "150",
					BackColor = Color.FromArgb(70, ColorTranslator.FromHtml("#212121")),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Font = new Font("Raleway Thin", 10),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_PostCommentCount[loop].MouseEnter += new EventHandler(__MouseEnter);
				_PostCommentCount[loop].MouseLeave += new EventHandler(__MouseLeave);
				_PostCommentCount[loop].Click += new EventHandler(__MouseClick);
				_CommentButton[loop].Controls.Add(_PostCommentCount[loop]);

				_CommentsPnl[loop] = new Panel() {
					Location = new Point(570, y),
					Size = new Size(270, 350),
					BackColor = ColorTranslator.FromHtml("#808080"),
				};
				this.Controls.Add(_CommentsPnl[loop]);
				_CommentsPnl[loop].Hide();

				Panel _CommentsHolder = new Panel() {
					Size = new Size(310, 330),
					Location = new Point(0, 30),
					BackColor = Color.Transparent,
					AutoScroll = true
				};
				_CommentsPnl[loop].Controls.Add(_CommentsHolder);

				for(int commentloop = 0; commentloop < _CommentCount; commentloop++) {
					_CommentsPnlBox[commentloop] = new PictureBox() {
						Size = new Size(50, 50),
						SizeMode = PictureBoxSizeMode.StretchImage,
						Location = new Point(10, 10 + 65 * commentloop),
						Image = Image.FromFile("res/user.jpg")
					};
					_CommentsHolder.Controls.Add(_CommentsPnlBox[commentloop]);

					Panel _CommentsPnlCommPnl = new Panel() {
						AutoScroll = true,
						Size = new Size(230, 50),
						BackColor = Color.FromArgb(90, ColorTranslator.FromHtml("#484141")),
						Location = new Point(60, 10 + 65 * commentloop)
					};
					_CommentsHolder.Controls.Add(_CommentsPnlCommPnl);

					_CommentsPnlComm[commentloop] = new Label() {
						MaximumSize = new Size(205, 0),
						AutoSize = true,
						Font = new Font("Helvetica", 9),
						ForeColor = Color.White,
						Text = @"I don't set alarms
Lately I don't set alarms
But that's because of the ringing that's happening inside my head
Inside my head
Yeah yeah
It keeps me safe from harm
At least I tell myself I'm safe from harm
But really it's probably filling my dreams with dread
So I get out of bed
Yeah yeah
Yes I'm neurotic I'm obsessed and I know it
I can't take vacations and the brain won't believe me I'm on one
Hawaii under warm sun
Yeah yeah

I think I lost my mind
Don't worry about me
Happens all the time
In the morning I'll be better
In the morning I'll be better
Sing it again
I think I lost my mind
But don't worry about me
Happens all the time
In the morning I'll be better
Things are only getting better
Sing it again

I'll tell myself I'll change
That's right I tell myself I'll change
But then I begin to realize that the problems inside my veins
But it's inside my veins (vein)
Yeah yeah
I swear I'm not insane
Yes most likely not insane
Everybody goes through moments of losing their clarity
At least I'm never boring
But I've been losing sleep so call the doctor said to take one of these
And call me in the morning"
					};
					_CommentsPnlCommPnl.Controls.Add(_CommentsPnlComm[commentloop]);

				}

					_CommentsPnlHead[loop] = new Label() {
						AutoSize = true,
						BackColor = Color.Transparent,
						ForeColor = ColorTranslator.FromHtml("#563434"),
						Text = "Comments on this post:",
						Font = new Font("Helvetica", 11, FontStyle.Bold),
						Location = new Point(5, 5)
					};
					_CommentsPnl[loop].Controls.Add(_CommentsPnlHead[loop]);

				_PostCaption[loop] = new Label() {
					Size = new Size(500, 200),
					Location = new Point(10, 315),
					Text = "Starry night... #Artsy #ArtsyCaption",
					ForeColor = ColorTranslator.FromHtml("#212121"),
					BackColor = Color.Transparent,
					Font = new Font("Helvetica", 11),
					TextAlign = ContentAlignment.TopCenter
				};
				_PostContainer[loop].Controls.Add(_PostCaption[loop]);
				y += 360;
			};

			_RecommendedLbl[0] = new Label() {
				Size = new Size(270, 600),
				Location = new Point(570, 15),
				BackColor = Color.Transparent
			};
			this.Controls.Add(_RecommendedLbl[0]);

				_RecommendedLbl[1] = new Label() {
					Size = new Size(270, 100),
					Text = "Recommended Artists",
					Font = new Font("Segoe UI Semibold", 10),
					ForeColor = Color.FromArgb(143, 136, 135)
				};
				_RecommendedLbl[0].Controls.Add(_RecommendedLbl[1]);

				for(int loop = 0; loop < 4; loop++) {
					PictureBox _RecArtBox = new PictureBox() {
						Size = new Size(60, 60),
						SizeMode = PictureBoxSizeMode.StretchImage,
						Location = new Point(10 + (62 * loop), 20),
						Image = Image.FromFile("res/Janno.jpg")
					};
					_RecommendedLbl[1].Controls.Add(_RecArtBox);
					_RecArtBox.MouseEnter += new EventHandler(__PictureBoxEnter);
					_RecArtBox.MouseLeave += new EventHandler(__PictureBoxLeave);

				}

				_RecommendedLbl[1] = new Label() {
					Size = new Size(270, 200),
					Text = "Recommended Artworks",
					Font = new Font("Segoe UI Semibold", 10),
					ForeColor = Color.FromArgb(143, 136, 135),
					Location = new Point(0, 100)
				};
				_RecommendedLbl[0].Controls.Add(_RecommendedLbl[1]);

				for(int oloop = 0; oloop < 2; oloop++) {
					for(int iloop = 0; iloop < 2; iloop++) {
						PictureBox _RecArtBox = new PictureBox() {
							Size = new Size(130, 90),
							SizeMode = PictureBoxSizeMode.StretchImage,
							Image = Image.FromFile("res/Spo.jpg"),
							Location = new Point(5 +iloop * 132, 20 + oloop * 92),

						};
						_RecArtBox.MouseEnter += new EventHandler(__PictureBoxEnter);
						_RecArtBox.MouseLeave += new EventHandler(__PictureBoxLeave);
						_RecommendedLbl[1].Controls.Add(_RecArtBox);
					}
				}

				_RecommendedLbl[2] = new Label() {
					Size = new Size(270, 200),
					Text = "Recommended Biddings",
					Font = new Font("Segoe UI Semibold", 10),
					ForeColor = Color.FromArgb(143, 136, 135),
					Location = new Point(0, 300)
				};
				_RecommendedLbl[0].Controls.Add(_RecommendedLbl[2]);

				for(int loop = 0; loop < 2; loop ++) {
					Label _RecBidLbl = new Label() {
						Tag = "rec",
						Size = new Size(270, 90),
						BackColor = Color.FromArgb(90, Color.Gray),
						Location = new Point(0, 20 + 92 * loop)
					};
					_RecommendedLbl[2].Controls.Add(_RecBidLbl);
					_RecBidLbl.MouseEnter += new EventHandler(__MouseEnter);
					_RecBidLbl.MouseLeave += new EventHandler(__MouseLeave);

					_RecommendedBox[loop] = new PictureBox() {
						Size = new Size(90, 90),
						SizeMode = PictureBoxSizeMode.StretchImage,
						Image = Image.FromFile("res/janno.jpg")
					};
					_RecBidLbl.Controls.Add(_RecommendedBox[loop]);

					__RecommendedAucName[loop] = new Label() {
						Size = new Size(90, 15),
						Text = "Janno Gibbs",
						TextAlign = ContentAlignment.MiddleCenter,
						Location = new Point(0, 75),
						Font = new Font("Helvetica", 8),
						ForeColor = Color.Black,
						BackColor = Color.FromArgb(90, Color.Gray)
					};
					_RecommendedBox[loop].Controls.Add(__RecommendedAucName[loop]);

					Label _RecAucName = new Label() {
						Text = @"#Bid         :

#Views     :

CurrBid    :

Time Left :  ",
						Font = new Font("Helvetica", 8, FontStyle.Bold),
						Location = new Point(93, 0),
						Size = new Size(61, 90),
						BackColor = Color.Transparent,
						ForeColor = Color.Black
					};
					_RecBidLbl.Controls.Add(_RecAucName);

					_RecommendedAucCont[loop] = new Label() {
						MaximumSize = new Size(0, 90),
						AutoSize = true,
						Text = @"131

521

P12,312

13:33",
						Font = new Font("Helvetica", 8),
						ForeColor = Color.White,
						BackColor = Color.Transparent,
						Location = new Point(160, 0)
					};
					_RecBidLbl.Controls.Add(_RecommendedAucCont[loop]);

					Button _RecGoBtn = new Button() {
						Size = new Size(30, 20),
						Location = new Point(235, 65),
						Text = "Go",
						FlatStyle = FlatStyle.Flat,
						Font = new Font("Helvetica", 8)
					};
					_RecBidLbl.Controls.Add(_RecGoBtn);

				}

				_RecommendedLbl[3] = new Label() {
					Size = new Size(270, 100),
					Text = "Top Event of the Day",
					Font = new Font("Segoe UI Semibold", 10),
					ForeColor = Color.FromArgb(143, 136, 135),
					Location = new Point(0, 500)
				};
				_RecommendedLbl[0].Controls.Add(_RecommendedLbl[3]);

				Label _RecEveLbl = new Label() {
					Tag = "rec2",
					Size = new Size(270, 80),
					Location = new Point(0, 20),
					BackColor = Color.FromArgb(90, Color.Gray),
				};
				_RecommendedLbl[3].Controls.Add(_RecEveLbl);
				_RecEveLbl.MouseEnter += new EventHandler(__MouseEnter);
				_RecEveLbl.MouseLeave += new EventHandler(__MouseLeave);

				_TopEventBox = new PictureBox() {
					Size = new Size(90, 80),
					SizeMode = PictureBoxSizeMode.StretchImage,
					Image = Image.FromFile("res/qtpie.jpg")
				};
				_RecEveLbl.Controls.Add(_TopEventBox);

				_TopEventName = new Label() {
					Size = new Size(90, 10),
					Text = "QtPie ♥",
					Font = new Font("Helvetica", 8),
					ForeColor = Color.Black,
					BackColor = Color.FromArgb(90, Color.Gray),
					Location = new Point(0, 70),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_TopEventBox.Controls.Add(_TopEventName);

				Label _TopEventDetailsLbl = new Label() {
					Size = new Size(65, 80),
					Text = @"

Category  :

Views        : ",
					Font = new Font("Helvetica", 8, FontStyle.Bold),
					ForeColor = Color.Black,
					BackColor = Color.Transparent,
					Location = new Point(95, 0)
				};
				_RecEveLbl.Controls.Add(_TopEventDetailsLbl);

				_TopEventDetails = new Label() {
					Size = new Size(70, 80),
					Text = @"

Driver Fetish

69 million",
					Font = new Font("Helvetica", 8),
					ForeColor = Color.White,
					BackColor = Color.Transparent,
					Location = new Point(165, 0)
				};
				_RecEveLbl.Controls.Add(_TopEventDetails);

				Button _TopGoBtn = new Button() {
					Size = new Size(30, 20),
					Location = new Point(235, 55),
					Text = "Go",
					FlatStyle = FlatStyle.Flat,
					Font = new Font("Helvetica", 8)
				};
				_RecEveLbl.Controls.Add(_TopGoBtn);

		}

		/*============================================================================*
	     *  Function   : __MouseEnter
     	 *  Params     : object source - Component that triggered the event. 
                         EventArgs mea - Event Argument
	     *  Returns    : Void
	     *  Description: Highlights the component that is being hovered.
	     *=============================================================================*/
		void __MouseEnter(object source, EventArgs mea){
			var sender = source as Label;
			Point ParLocation = sender.Parent.Location;
			Point location = sender.Location;
			Point ContLocation = _RecommendedLbl[0].Location;
			int HLHeight = 0;

			if(sender.Tag.ToString() == "rec") {
				_RecHL.BackColor = Color.FromArgb(90, 255, 53, 255);
				HLHeight = 4;
				_RecHL.Size = new Size(sender.Width, HLHeight);
				_RecHL.Location =  new Point(ContLocation.X + location.X, ContLocation.Y + location.Y + ParLocation.Y + (sender.Height - HLHeight));
				_RecHL.Show();
			}  else if(sender.Tag.ToString() == "rec2") {
				_RecHL.BackColor = Color.FromArgb(90, 190, 85, 0);
				HLHeight = 4;
				_RecHL.Size = new Size(sender.Width, HLHeight);
				_RecHL.Location =  new Point(ContLocation.X + location.X, ContLocation.Y + location.Y + ParLocation.Y + (sender.Height - HLHeight));
				_RecHL.Show();
			} else if(sender.Text == "C") {
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Red);
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
			} else if(sender.Text == "L") {
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Red);
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
			} else if(sender.Text == "OK") {
				sender.BackColor = ColorTranslator.FromHtml("#BDBDBD");
				sender.ForeColor = ColorTranslator.FromHtml("#954535");
			} else if(sender.Parent.Text == "C") {
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Red);
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
			} else if(sender.Parent.Text == "L") {
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Red);
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
			} else if(sender.Tag.ToString() == "PostArt") {
				sender.BackColor = Color.Transparent;
				sender.ForeColor = ColorTranslator.FromHtml("#7a1f1f");
			} else if(sender.Tag.ToString() == "PostAuc") {
				sender.BackColor = Color.Transparent;
				sender.ForeColor = ColorTranslator.FromHtml("#395e60");
			} else if(sender.Tag.ToString() == "PostStat") {
				sender.BackColor = Color.Transparent;
				sender.ForeColor = ColorTranslator.FromHtml("#916a08");
			}
		}

		/*============================================================================*
	     *  Function   : __MouseLeave
     	 *  Params     : object source - Component that triggered the event. 
                         EventArgs e   - Event Argument
	     *  Returns    : Void
	     *  Description: Resets component's appearance when unhovered.
	     *=============================================================================*/
		void __MouseLeave(object source, EventArgs e){
			var sender = source as Label;

			if(sender.Text == "C" || sender.Parent.Text == "C") {
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(30, ColorTranslator.FromHtml("#212121"));
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 10);
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 40);
			} else if(sender.Text == "L" || sender.Parent.Text == "L") {
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(30, ColorTranslator.FromHtml("#212121"));
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 10);
				_LikeCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 40);
			} else if(sender.Tag.ToString() == "PostArt") {
				sender.ForeColor = Color.Black;
				sender.BackColor = ColorTranslator.FromHtml("#7a1f1f");
			} else if(sender.Tag.ToString() == "PostAuc") {
				sender.ForeColor = Color.Black;
				sender.BackColor = ColorTranslator.FromHtml("#395e60");
			} else if(sender.Tag.ToString() == "PostStat") {
				sender.ForeColor = Color.Black;
				sender.BackColor = ColorTranslator.FromHtml("#916a08");
			}

			if(sender.Text == "L" || sender.Text == "C" || sender.Text == "OK" || sender.Parent.Text == "L" || sender.Parent.Text == "C") {
				sender.TextAlign = ContentAlignment.MiddleCenter;
				sender.BackColor = ColorTranslator.FromHtml("#424242");
				sender.ForeColor = ColorTranslator.FromHtml("#E0E0E0");
			}
			_RecHL.Hide();
		}

		/*============================================================================*
	     *  Function   : __PictureBoxEnter
     	 *  Params     : object source - Component that triggered the event. 
                         EventArgs mea - Event Argument
	     *  Returns    : Void
	     *  Description: Highlights the component that is being hovered (for side bar). 
	     *=============================================================================*/
		void __PictureBoxEnter(object source, EventArgs mea) {
			var sender = source as PictureBox;
			Point ParLocation = sender.Parent.Location;
			Point location = sender.Location;
			Point ContLocation = _RecommendedLbl[0].Location;
			int HLHeight = 0;

			if(sender.Width == 60) {
				_RecHL.BackColor = Color.FromArgb(90, 213, 218, 16);
				HLHeight = 3;
				_NameHL = new Label() {
					Size = new Size(sender.Width, 8),
					Text = "Item Name",
					TextAlign = ContentAlignment.MiddleCenter,
					BackColor = Color.FromArgb(90, Color.Gray),
					ForeColor = Color.Black,
					Font = new Font("Helvetica", 7),
				};
				sender.Controls.Add(_NameHL);
				new Thread(() => {
					for(int loop = 0; loop <= 8; loop++) {
						try {
							_NameHL.Location = new Point(0, 0 - 8 + loop);
							Thread.Sleep(1);
						} catch(Exception e) {
							Console.WriteLine(e.ToString());
						}
					}
				}).Start();
			} else if(sender.Width == 130) {
				_RecHL.BackColor = Color.FromArgb(90, 66, 168, 148);
				HLHeight = 4;
				_NameHL = new Label() {
					Size = new Size(sender.Width, 10),
					Text = "Item Name",
					TextAlign = ContentAlignment.MiddleCenter,
					BackColor = Color.FromArgb(90, Color.Gray),
					ForeColor = Color.Black,
					Font = new Font("Helvetica", 8),
				};
				sender.Controls.Add(_NameHL);
				new Thread(() => {
					for(int loop = 0; loop <= 10; loop++) {
						try {
							_NameHL.Location = new Point(0, 0 - 10 + loop);
							Thread.Sleep(1);
						} catch(Exception e) {
							Console.WriteLine(e.ToString());
						}
					}
				}).Start();
			} else if(sender.Width == 270) {
				_RecHL.BackColor = Color.FromArgb(90, 164, 70, 124);
				HLHeight = 2;
			}

			_RecHL.Size = new Size(sender.Width, HLHeight);
			_RecHL.Location =  new Point(ContLocation.X + location.X, ContLocation.Y + location.Y + ParLocation.Y + (sender.Height - HLHeight));
			_RecHL.Show();
		}

		/*============================================================================*
	     *  Function   : __PictureBoxLeave
     	 *  Params     : object source - Component that triggered the event. 
                         EventArgs mla - Event Argument
	     *  Returns    : Void
	     *  Description: Resets side bar component when unhovered.
	     *=============================================================================*/
		void __PictureBoxLeave(object source, EventArgs mla) {
			_RecHL.Hide();
			_NameHL.Hide();
		}

		/*============================================================================*
	     *  Function   : __MouseClick
     	 *  Params     : object source - Component that triggered the event. 
                         EventArgs ca  - Event Argument
	     *  Returns    : Void
	     *  Description: Handles click events on labels on lobby panel.
	     *=============================================================================*/
		void __MouseClick(object source, EventArgs ca) {
			var sender = source as Label;

			if(sender.Text == "L") {
				sender.Text = "Li";
				_LikeCount[Convert.ToInt32(sender.Tag)].Text = (Convert.ToInt32(_LikeCount[Convert.ToInt32(sender.Tag)].Text) + 1).ToString();
			} else if(sender.Text == "Li") {
				sender.Text = "L";
				_LikeCount[Convert.ToInt32(sender.Tag)].Text = (Convert.ToInt32(_LikeCount[Convert.ToInt32(sender.Tag)].Text) - 1).ToString();
			} else if(sender.Text == "C") {
				Point ComLoc = _CommentBoxHolder[Convert.ToInt32(sender.Tag.ToString())].Location;
				_CommentBoxHolder[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(ComLoc.X, ComLoc.Y + this.AutoScrollPosition.Y);
				_CommentBoxHolder[Convert.ToInt32(sender.Tag.ToString())].Show();
				sender.Text = "C.";
			} else if(sender.Text == "C.") {
				_CommentBoxHolder[Convert.ToInt32(sender.Tag.ToString())].Hide();
				sender.Text = "C";
			} else if(sender.Text == "OK" && !String.IsNullOrEmpty(_CommentBox[Convert.ToInt32(sender.Tag.ToString())].Text)) {
				_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Text = (Convert.ToInt32(_PostCommentCount[Convert.ToInt32(sender.Tag.ToString())].Text) + 1).ToString();
				_CommentBox[Convert.ToInt32(sender.Tag.ToString())].Text = "";
				_CommentButton[Convert.ToInt32(sender.Tag.ToString())].Text = "C";
				_CommentBoxHolder[Convert.ToInt32(sender.Tag.ToString())].Hide();
			} else if(sender.Parent.Text == "C" && _CommentsPnlFlag == 0 || sender.Parent.Text == "C." && _CommentsPnlFlag == 0) {
				_CommentsPnl[Convert.ToInt32(sender.Tag.ToString())].Show();
				// UPDATE _COMMENTCOUNT HERE
				_LikersPnl[Convert.ToInt32(sender.Tag.ToString())].Hide();
				_CommentsPnlFlag = 1;
			} else if(sender.Parent.Text == "C" && _CommentsPnlFlag == 1 || sender.Parent.Text == "C." && _CommentsPnlFlag == 1) {
				_CommentsPnl[Convert.ToInt32(sender.Tag.ToString())].Hide();
				_CommentsPnlFlag = 0;
			} else if(sender.Parent.Text == "L" && _LikersPnlFlag == 0 || sender.Parent.Text == "Li" && _LikersPnlFlag == 0) {
				_LikersPnl[Convert.ToInt32(sender.Tag.ToString())].Show();
				// UPDATE _LIKECOUNT HERE
				_CommentsPnl[Convert.ToInt32(sender.Tag.ToString())].Hide();
				_LikersPnlFlag = 1;
			} else if(sender.Parent.Text == "L" && _LikersPnlFlag == 1 || sender.Parent.Text == "Li" && _LikersPnlFlag == 1) {
				_LikersPnl[Convert.ToInt32(sender.Tag.ToString())].Hide();
				_LikersPnlFlag = 0;
			} else if(sender.Tag.ToString() == "PostArt") {
				new Thread(() => {
					if(_PostArtFlag == 0) {
						_UserAucPnl.Size = new Size(425, 0);
						_UserStatPnl.Size = new Size(425, 0);
						_PostAucFlag = 0;
						_PostStaFlag = 0;
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserArtPnl.Size = new Size(425, loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostArtFlag = 1;
						}
					} else {
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserArtPnl.Size = new Size(425, 245 - loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostArtFlag = 0;
						}
					}
				}).Start();
			} else if(sender.Tag.ToString() == "PostAuc") {
				new Thread(() => {
					if(_PostAucFlag == 0) {
						_UserArtPnl.Size = new Size(425, 0);
						_UserStatPnl.Size = new Size(425, 0);
						_PostArtFlag = 0;
						_PostStaFlag = 0;
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserAucPnl.Size = new Size(425, loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostAucFlag = 1;
						}
					} else {
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserAucPnl.Size = new Size(425, 245 - loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostAucFlag = 0;
						}
					}
				}).Start();
			} else if(sender.Tag.ToString() == "PostStat") {
				new Thread(() => {
					if(_PostStaFlag == 0) {
						_UserArtPnl.Size = new Size(425, 0);
						_PostArtFlag = 0;
						_UserAucPnl.Size = new Size(425, 0);
						_PostAucFlag = 0;
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserStatPnl.Size = new Size(425, loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostStaFlag = 1;
						}
					} else {
						for(int loop = 0; loop <= 245; loop += 5) {
							try {
								_UserStatPnl.Size = new Size(425, 245 - loop);
								Thread.Sleep(1);
							} catch(Exception e) {
								Console.WriteLine(e.ToString());
							} _PostStaFlag = 0;
						}
					}
				}).Start();
			}
		}

		/*==============================INITIALIZATION==============================*/
		static int _PostCount = 5;
		static int x = 50;
		static int y = 265;
		static int _LikersPnlFlag = 0;
		static int _CommentsPnlFlag = 0;

		static int _LikerCount = 10;
		static int _CommentCount = 15;

		static int _PostArtFlag = 0;
		static int _PostAucFlag = 0;
		static int _PostStaFlag = 0;
		
		Label _UserPostLbl;
			Label _UserPostArt;
				Panel _UserArtPnl;
				PictureBox _UserArtBox;
			Label _UserPostAuc;
				Panel _UserAucPnl;
			Label _UserPostStat;
				Panel _UserStatPnl;


		Label[] _PostContainer = new Label[_PostCount];
		Label _RecHL;
		Label _NameHL;
			Label[] _CommentBoxHolder = new Label[_PostCount];
				RichTextBox[] _CommentBox = new RichTextBox[_PostCount];
				Label[] _CommentBoxOk = new Label[_PostCount];
			PictureBox[] _PostIcon = new PictureBox[_PostCount];
			PictureBox[] _PostImage = new PictureBox[_PostCount];
			Label[] _PostUsername = new Label[_PostCount];
			Label[] _PostCaption = new Label[_PostCount];
			Label[] _LikeCount = new Label[_PostCount];
				Panel[] _LikersPnl = new Panel[_PostCount];
					Label[] _LikersPnlHead = new Label[_PostCount];
					PictureBox[] _LikersPnlBox = new PictureBox[_LikerCount];
					Label[] _LikersPnlName = new Label[_LikerCount];
					Button[] _LikersPnlFollow = new Button[_LikerCount];
			Label[] _PostComment = new Label[_PostCount];
			Label[] _PostCommentCount = new Label[_PostCount];
				Panel[] _CommentsPnl = new Panel[_PostCount];
					Label[] _CommentsPnlHead = new Label[_PostCount];
					PictureBox[] _CommentsPnlBox = new PictureBox[_CommentCount];
					Label[] _CommentsPnlComm = new Label[_CommentCount];
					Button[] _CommentsPnlFollow = new Button[_CommentCount];
			Label[] _CommentButton = new Label[_PostCount];
			Label[] _LikeButton = new Label[_PostCount];
		Label[] _RecommendedLbl = new Label[4];
			PictureBox[] _RecommendedBox = new PictureBox[2];
			Label[] _RecommendedAucCont = new Label[2];
			Label[] __RecommendedAucName = new Label[2];
			PictureBox _TopEventBox;
			Label _TopEventName;
			Label _TopEventDetails;

	}
}
