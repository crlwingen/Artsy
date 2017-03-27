/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Profile.cs
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
	public class Profile : Panel {

		public Profile() {
			__DisplayProfile();
		}

		/*============================================================================*
        *  Function   : __DisplayProfile
        *  Params     : None 
        *  Returns    : Void
        *  Description: The panel that displays the profile of the Artsy user.
        *=============================================================================*/
		void __DisplayProfile() {
			BackColor = ColorTranslator.FromHtml("#212121");
			AutoSize = true;

			_SideContainer = new Label() {
				Size = new Size(220, 700),
				Location = new Point(10, 10),
				Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
				BackColor = ColorTranslator.FromHtml("#333333")
			};
			this.Controls.Add(_SideContainer);

				var path = new GraphicsPath();
				path.AddEllipse(0, 0, 160, 160);

				_UserImage = new PictureBox() {
					Size = new Size(160, 160),
					Location = new Point(28, 10),
					Image = Image.FromFile("res/log1.jpg"),
					SizeMode = PictureBoxSizeMode.StretchImage,
					Region = new Region(path)
				};
				_SideContainer.Controls.Add(_UserImage);

				_Username = new Label() {
					Size = new Size(210, 30),
					Location = new Point(5, 170),
					BackColor = ColorTranslator.FromHtml("#651a1a"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "JinMer",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Segoe UI", 12)
				};
				_SideContainer.Controls.Add(_Username);

				_FollowButton = new PictureBox() {
					Size = new Size(50, 50),
					Location = new Point(28, 205),
					SizeMode = PictureBoxSizeMode.StretchImage,
					BackColor = Color.Transparent,
					Image = Image.FromFile("res/Icons/user-1.png"),
					Font = new Font("Segoe UI Light", 12)
				};
				_SideContainer.Controls.Add(_FollowButton);

				_CollabButton = new PictureBox() {
					Size = new Size(50, 50),
					Location = new Point(83, 205),
					SizeMode = PictureBoxSizeMode.StretchImage,
					BackColor = Color.Transparent,
					Image = Image.FromFile("res/Icons/pencil.png")
				};
				_SideContainer.Controls.Add(_CollabButton);

				_MessageButton = new PictureBox() {
					Size = new Size(50, 50),
					Location = new Point(138, 205),
					SizeMode = PictureBoxSizeMode.StretchImage,
					BackColor = Color.Transparent,
					Image = Image.FromFile("res/Icons/mail.png")
				};
				_SideContainer.Controls.Add(_MessageButton);

				_Followers = new Label() {
					Size = new Size(90, 20),
					Location = new Point(5, 275),
					BackColor = ColorTranslator.FromHtml("#212121"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "FOLLOWERS",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Segoe UI", 10)
				};
				_SideContainer.Controls.Add(_Followers);

				_FollowersCount = new Label() {
					Size = new Size(120, 24),
					Location = new Point(95, 270),
					BackColor = ColorTranslator.FromHtml("#954535"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = _intFollowersCount.ToString(),
					Font = new Font("Segoe UI", 11),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_SideContainer.Controls.Add(_FollowersCount);

				_Following = new Label() {
					Size = new Size(90, 20),
					Location = new Point(5, 315),
					BackColor = ColorTranslator.FromHtml("#212121"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "FOLLOWING",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Segoe UI", 10)
				};
				_SideContainer.Controls.Add(_Following);

				_FollowingCount = new Label() {
					Size = new Size(120, 24),
					Location = new Point(95, 310),
					BackColor = ColorTranslator.FromHtml("#954535"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = _intFollowingCount.ToString(),
					Font = new Font("Segoe UI", 11),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_SideContainer.Controls.Add(_FollowingCount);

				_Arts = new Label() {
					Size = new Size(90, 20),
					Location = new Point(5, 355),
					BackColor = ColorTranslator.FromHtml("#212121"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "ARTS",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Segoe UI", 10)
				};
				_SideContainer.Controls.Add(_Arts);

				_ArtsCount = new Label() {
					Size = new Size(120, 24),
					Location = new Point(95, 350),
					BackColor = ColorTranslator.FromHtml("#954535"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = _intArtsCount.ToString(),
					Font = new Font("Segoe UI", 11),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_SideContainer.Controls.Add(_ArtsCount);

				_Auctions = new Label() {
					Size = new Size(90, 20),
					Location = new Point(5, 395),
					BackColor = ColorTranslator.FromHtml("#212121"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "AUCTIONS",
					TextAlign = ContentAlignment.MiddleCenter,
					Font = new Font("Segoe UI", 10)
				};
				_SideContainer.Controls.Add(_Auctions);

				_AuctionsCount = new Label() {
					Size = new Size(120, 24),
					Location = new Point(95, 390),
					BackColor = ColorTranslator.FromHtml("#954535"),
					ForeColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = _intAuctionsCount.ToString(),
					Font = new Font("Segoe UI", 11),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_SideContainer.Controls.Add(_AuctionsCount);

				_PostContainer = new Label() {
					Size = new Size(220, 600),
					Location = new Point(0, 490),
					BackColor = Color.Gray
				};
				_SideContainer.Controls.Add(_PostContainer);

				_UserPosts[0] = new Label() {
					Size = new Size(180, 180),
					Location = new Point(20, 10),
					BackColor = ColorTranslator.FromHtml("#E0E0E0"),
					Text = "Thumbnails ng mga post ni user",
					Font = new Font("Segoe UI Light", 12),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_PostContainer.Controls.Add(_UserPosts[0]);

			_MainContainer = new Label() {
				Size = new Size(630, 700),
				Location = new Point(230, 10)
			};
			this.Controls.Add(_MainContainer);

				_FeaturedArtsContainer = new Label() {
					Tag = "Art",
					Size = new Size(300, 300),
					Location = new Point(10, 0),
					BackColor = ColorTranslator.FromHtml("#737373")
				};
				_MainContainer.Controls.Add(_FeaturedArtsContainer);

				_FeaturedArtsLabel = new Label() {
					Size = new Size(300, 30),
					Location = new Point(0, 0),
					BackColor = ColorTranslator.FromHtml("#264040"),
					ForeColor = ColorTranslator.FromHtml("#e6e6e6"),
					Text = "FEATURED ARTS",
					Font = new Font("Segoe UI ", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_FeaturedArtsContainer.Controls.Add(_FeaturedArtsLabel);

				_AuctionsContainer = new Label() {
					Tag = "Auction",
					Size = new Size(300, 300),
					Location = new Point(320, 0),
					BackColor = ColorTranslator.FromHtml("#737373")
				};
				_MainContainer.Controls.Add(_AuctionsContainer);

				_AuctionsLabel = new Label() {
					Size = new Size(300, 30),
					Location = new Point(0, 0),
					BackColor = ColorTranslator.FromHtml("#264040"),
					ForeColor = ColorTranslator.FromHtml("#e6e6e6"),
					Text = "AUCTIONS",
					Font = new Font("Segoe UI ", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_AuctionsContainer.Controls.Add(_AuctionsLabel);

				_TempContainer1 = new Label() {
					Tag = "Follow",
					Size = new Size(300, 300),
					Location = new Point(10, 320),
					BackColor = ColorTranslator.FromHtml("#737373")
				};
				_MainContainer.Controls.Add(_TempContainer1);

				_TempLabel1 = new Label() {
					Size = new Size(300, 30),
					Location = new Point(0, 0),
					BackColor = ColorTranslator.FromHtml("#264040"),
					ForeColor = ColorTranslator.FromHtml("#e6e6e6"),
					Text = "FOLLOWING",
					Font = new Font("Segoe UI ", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_TempContainer1.Controls.Add(_TempLabel1);

				_TempContainer2 = new Label() {
					Tag = "Followr",
					Size = new Size(300, 300),
					Location = new Point(320, 320),
					BackColor = ColorTranslator.FromHtml("#737373")
				};
				_MainContainer.Controls.Add(_TempContainer2);

				_TempLabel2 = new Label() {
					Size = new Size(300, 30),
					Location = new Point(0, 0),
					BackColor = ColorTranslator.FromHtml("#264040"),
					ForeColor = ColorTranslator.FromHtml("#e6e6e6"),
					Text = "FOLLOWERS",
					Font = new Font("Segoe UI ", 15),
					TextAlign = ContentAlignment.MiddleCenter
				};
				_TempContainer2.Controls.Add(_TempLabel2);
		}

		/*============================================================================*
	     *  Function   : __MouseLeave
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs mla - Event Argument
	     *  Returns    : Void
	     *  Description: Show animation for the panel components.
	     *=============================================================================*/
		void __MouseEnter(object source, EventArgs mea) {
			var sender = source as Label;

			if(sender.Tag.ToString() == "Art" && _ArtFlag == 0) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop += 10) {
						try {
							_FeaturedArtsLabel.Size = new Size(300 - loop, 30);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_FeaturedArtsLabel.Location = new Point(0, 0 + loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_FeaturedArtsLabel.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _ArtFlag = 1;
			} else if(sender.Tag.ToString() == "Auction" && _AucFlag == 0) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop += 10) {
						try {
							_AuctionsLabel.Size = new Size(300 - loop, 30);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_AuctionsLabel.Location = new Point(0, 0 + loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_AuctionsLabel.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _AucFlag = 1;
			} else if(sender.Tag.ToString() == "Follow" && _FlwFlag == 0) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop += 10) {
						try {
							_TempLabel1.Size = new Size(300 - loop, 30);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_TempLabel1.Location = new Point(0, 0 + loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_TempLabel1.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _FlwFlag = 1;
			} else if(sender.Tag.ToString() == "Followr" && _FlrFlag == 0) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop += 10) {
						try {
							_TempLabel2.Size = new Size(300 - loop, 30);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_TempLabel2.Location = new Point(0, 0 + loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_TempLabel2.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _FlrFlag = 1;
			}

		}

		/*============================================================================*
	     *  Function   : __MouseLeave
	     *  Params     : object source - Component that triggered the event. 
	                     EventArgs mla - Event Argument
	     *  Returns    : Void
	     *  Description: Hide animation for the panel components.
	     *=============================================================================*/
		void __MouseLeave(object source, EventArgs mla) {
			var sender = source as Label;

			if(sender.Tag.ToString() == "Art" && _ArtFlag == 1) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_FeaturedArtsLabel.Location = new Point(0, 270 - loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_FeaturedArtsLabel.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _ArtFlag = 0;
			} else if(sender.Tag.ToString() == "Auction" && _AucFlag == 1) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_AuctionsLabel.Location = new Point(0, 270 - loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_AuctionsLabel.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _AucFlag = 0;
			} else if(sender.Tag.ToString() == "Follow" && _FlwFlag == 1) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_TempLabel1.Location = new Point(0, 270 - loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_TempLabel1.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _FlwFlag = 0;
			} else if(sender.Tag.ToString() == "Followr" && _FlrFlag == 1) {
				new Thread(() => {
					for(int loop = 0; loop <= 270; loop+=10) {
						try {
							_TempLabel2.Location = new Point(0, 270 - loop);
							Thread.Sleep(1);
						} catch(Exception ex) {
							Console.WriteLine(ex.ToString());
						}
					}

					for(int loop = 0; loop <= 270; loop +=10) {
						_TempLabel2.Size = new Size(30 + loop, 30);
						Thread.Sleep(1);
					}
				}).Start(); _FlrFlag = 0;
			}
		}

		/*==============================INITIALIZATION==============================*/
		Label _MainContainer;
			Label _FeaturedArtsContainer;
			Label _FeaturedArtsLabel;
			Label _AuctionsContainer;
			Label _AuctionsLabel;
			Label _TempContainer1;
			Label _TempLabel1;
			Label _TempContainer2;
			Label _TempLabel2;

		Label _SideContainer;
			Label _Username;
			Label _Followers;
			Label _FollowersCount;
			Label _Following;
			Label _FollowingCount;
		  	PictureBox _FollowButton;
			PictureBox _CollabButton;
			PictureBox _MessageButton;
			Label _Arts;
			Label _ArtsCount;
			Label _Auctions;
			Label _AuctionsCount;
			Label _PostContainer;

		Label[] _UserPosts = new Label[1];

		PictureBox _UserImage;

		int _intFollowersCount = 653;
		int _intFollowingCount = 110;
		int _intArtsCount = 50;
		int _intAuctionsCount = 2;

		static int _ArtFlag = 0;
		static int _AucFlag = 0;
		static int _FlwFlag = 0;
		static int _FlrFlag = 0;
	}
}
