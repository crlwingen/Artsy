/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Showroom.cs
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
	public class Showroom : Panel {

		public Showroom() {
			__DisplayShowroom();
		}

	   /*============================================================================*
        *  Function   : __DisplayShowroom
        *  Params     : None 
        *  Returns    : Void
        *  Description: The panel that displays the settings tab of Artsy.
        *=============================================================================*/
		public void __DisplayShowroom() {

			_BidPage = new Panel() {
				Size = new Size(780, 550),
				Location = new Point(38, 10),
				BackColor = Color.FromArgb(100, Color.Black)
			};
			this.Controls.Add(_BidPage);
			_BidPage.Hide();

				_BidPageBox = new PictureBox() {
					Size = new Size(200, 200),
					Location = new Point(5, 5),
					SizeMode = PictureBoxSizeMode.StretchImage
				};
				_BidPage.Controls.Add(_BidPageBox);

				_BidPageName = new Label() {
					AutoSize = true,
					Location = new Point(220, 5),
					Font = new Font("Segoe UI", 20),
					ForeColor = ColorTranslator.FromHtml("#9fc6c6"),
					BackColor = Color.Transparent
				};
				_BidPage.Controls.Add(_BidPageName);

				_BidPageTime = new Label() {
					AutoSize = true,
					Text = "Time Left | hh:mm:ss",
					Font = new Font("Helvetica", 10),
					ForeColor = Color.White,
					BackColor = Color.Transparent
				};
				_BidPage.Controls.Add(_BidPageTime);

				_BidPageCondition = new Label() {
					Size = new Size(200, 15),
					Font = new Font("Helvetica", 10),
					Text = "Item Condition : *Boxz CritikHal Uno*",
					ForeColor = Color.White,
					BackColor = Color.Transparent
				};
				_BidPage.Controls.Add(_BidPageCondition);

				_BidPageBuyIt = new Label() {
					AutoSize = true,
					Text = "Buy It Now:  P 15,000",
					Font = new Font("Helvetica", 15),
					BackColor = Color.Transparent,
					ForeColor = Color.White,
				};
				_BidPage.Controls.Add(_BidPageBuyIt);

				_BidPageBuyItBtn = new Button() {
					Tag = "BuyIt",
					AutoSize = true,
					Text = "BUY IT",
					ForeColor = Color.Gray,
					Font = new Font("Helvetica", 10, FontStyle.Bold),
					Location = new Point(450, 105),
					FlatStyle = FlatStyle.Flat
				};
				_BidPage.Controls.Add(_BidPageBuyItBtn);
				_BidPageBuyItBtn.Click += new EventHandler(__MouseClickBtn);

				_BidPageCurBid = new Label() {
					AutoSize = true,
					Text = "Current Bid: P 10,400",
					Font = new Font("Helvetica", 15),
					Location = new Point(225, 150),
					ForeColor = Color.White,
					BackColor = Color.Transparent
				};
				_BidPage.Controls.Add(_BidPageCurBid);

				_BidPageCurBtn = new Button() {
					Tag = "Offer",
					AutoSize = true,
					Text = "MAKE OFFER",
					ForeColor = Color.Gray,
					Font = new Font("Helvetica", 10, FontStyle.Bold),
					Location = new Point(450, 150),
					FlatStyle = FlatStyle.Flat
				};
				_BidPage.Controls.Add(_BidPageCurBtn);
				_BidPageCurBtn.Click += new EventHandler(__MouseClickBtn);

				Panel _BidPageUserInfoPnl = new Panel() {
					Location = new Point(5, 210),
					Size = new Size(200, 70),
					BackColor = Color.FromArgb(60, Color.Gray)
				};
				_BidPage.Controls.Add(_BidPageUserInfoPnl);

					_BidPageOPRep = new Label() {
						Size = new Size(195, 20),
						Text = "Reputation: Trusted",
						ForeColor = Color.White,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 10, FontStyle.Bold),
						Location = new Point(2, 2)
					};
					_BidPageUserInfoPnl.Controls.Add(_BidPageOPRep);

					_BidPageOPPosFeed = new Label() {
						Size = new Size(195, 20),
						Text = "Positive Feedback: 100%",
						ForeColor = Color.White,
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 10, FontStyle.Bold),
						Location = new Point(2, 24)
					};
					_BidPageUserInfoPnl.Controls.Add(_BidPageOPPosFeed);

					_BidPageOPProfile = new Button() {
						Size = new Size(195, 20),
						Text = "Seller Profile Redirect",
						ForeColor = Color.White,
						BackColor = ColorTranslator.FromHtml("#F08080"),
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 10),
						Location = new Point(2, 48),
						FlatStyle = FlatStyle.Flat
					};
					_BidPageUserInfoPnl.Controls.Add(_BidPageOPProfile);

				Panel _BidPageItemSpecsPnl = new Panel() {
					Size = new Size(530, 190),
					Location = new Point(225, 210),
					AutoScroll = true,
					BackColor = Color.FromArgb(50, Color.Gray)
				};
				_BidPage.Controls.Add(_BidPageItemSpecsPnl);

					_BidPageItemSpecs = new Label() {
						Size = new Size(510, 300),
						Text = "USER NA BAHALA MAGLAGAY NG INFO NUNG ITEM DITO KAPAG MAGSESELL S'YA.",
						Font = new Font("Helvetica", 12),
						ForeColor = Color.White,
					};
					_BidPageItemSpecsPnl.Controls.Add(_BidPageItemSpecs);


			_MainContainer = new Panel() {
				Tag = "Main",
				Size = new Size(900, 600),
				Location = new Point(0, 0),
				BackColor = ColorTranslator.FromHtml("#212121"),
				AutoScroll = true,
				Dock = DockStyle.Fill
			};
			this.Controls.Add(_MainContainer);
			_MainContainer.Click += new EventHandler(__MouseClickPnl);
			_MainContainer.VerticalScroll.Visible = true;
			_MainContainer.MouseEnter += new EventHandler(__MouseEnterPnl);

			for(int loop = 0; loop < _BidCount; loop++) {

				_BidContainer[loop] = new Label() {
					Tag = loop,
					Size = new Size(250, 350),
					BackColor = Color.FromArgb(90, ColorTranslator.FromHtml("#E0E0E0")),
				};
				_MainContainer.Controls.Add(_BidContainer[loop]);

					_BidUsername[loop] = new Label() {
						Size = new Size(300, 40),
						Location = new Point(50, 12),
						Text = "DaVinci001",
						AutoSize = true,
						BackColor = Color.Transparent,
						Font = new Font("Segoe UI", 14)
					};
					_BidContainer[loop].Controls.Add(_BidUsername[loop]);

					var path = new GraphicsPath();
					path.AddEllipse(0, 0, 40, 40);

					_BidUserIcon[loop] = new PictureBox() {
						Size = new Size(40, 40),
						Location = new Point(5, 5),
						SizeMode = PictureBoxSizeMode.StretchImage,
						Image = Image.FromFile("res/log1.jpg"),
						Region = new Region(path)
					};
					_BidContainer[loop].Controls.Add(_BidUserIcon[loop]);

					_BidImage[loop] = new PictureBox() {
						Tag = loop,
						Size = new Size(300, 150),
						Location = new Point(0, 55),
						SizeMode = PictureBoxSizeMode.StretchImage,
						Image = Image.FromFile("res/log1.jpg"),
					};
					_BidContainer[loop].Controls.Add(_BidImage[loop]);

					_BidItem[loop] = new Label() {
						Tag = "Art",
						Size = new Size(250, 30),
						BackColor = Color.FromArgb(100, Color.Black),
						ForeColor = Color.Black,
						TextAlign = ContentAlignment.MiddleCenter,
						Location = new Point(0, 205),
						Text = "MONALISA",
						Font = new Font("Segoe UI", 12)
					};
					_BidContainer[loop].Controls.Add(_BidItem[loop]);
					_BidItem[loop].Click += new EventHandler(__MouseClick);

					_BidItemDesc[loop] = new Panel() {
						Tag = loop,
						AutoScroll = true,
						Size = new Size(270, 115),
						Location = new Point(0, 235)
					};
					_BidContainer[loop].Controls.Add(_BidItemDesc[loop]);
					_BidItemDesc[loop].MouseEnter += new EventHandler(__MouseEnter);
					_BidItemDesc[loop].MouseLeave += new EventHandler(__MouseLeave);
					_BidItemDesc[loop].Hide();

					_BidItemDescCont[loop] = new Label() {
						Tag = "desc",
						MaximumSize = new Size(250, 0),
						AutoSize = true,
						Text = @" *INSERT ARTWORK DESCRIPTION*
Chorus (miztah blaze)
Here comes the storm rushin’ in,
Don’t care what other people say
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…

You tryin’ to quit cuz the love is gone,
Without music I’m feelin’ all alone
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…

-kharma
sa muli naming pag balik ay mas lalo pang lumakas at sanga ng iniisip mo nag kakalas kalas nagkaka mali ka ito kami buo parin matatag parin di mo kayang buwagin karangalan ay bitbit parin sa aming muling pagtapak sa bakuran ng aming pundasyon sa ngayo’y wag mong isipin na isang ilusyon na kung bakit muling bumuo ng ingay at panibagong tugma eto ang bersyon na hindi mo na isip na muling magagawa

-fhat dee
ating wasakin ang poot sa damdamin, muling magbuklod at hawakan ang titulo’y sa amin. walang sistema-akadema ay muling maguluhan ang mga nakikisali sa eksena tuloy ang daloy ng dugo ng kapatiran ang pagmamahal sa musika’y buo bubuhayin ang tunog, sa pagpasok ng taon gigisingin ang mga utak na tulog

-zido a*s
ihanda ang inyong sarili sa pag usad ng mga letra sa iisang mikropono muli kaming nag sama sama bawal dito ang mahina dapat meron kang lakas, lakas na di kayang tibagin ng kahit sino mang ungas tampalasan, ang dapat sa inyo’y binabaon ngayon nyo na maririnig ang boses ng mga pinunong mobstaz pamilyaz na dumadagundong, kasama ko 187 iiwanan kang bungol

-polo.1
muling nagbabalik mikropono ay hinawakan sa lugar na kinamulatan muli ng masisilayan ang mga tunay na bartikal na pagdating sa mga banatan mga kumakalaban samin muli naming babalatan “polo dot one” ang pangalan 187 mobstaz maraming mga haters puro kupal na maangas hindi nakakatakas mga kritiks na imbento pagkat nandito na ang mga tunay na eksperto

-lil’noizy
ang panibugho at ang ligaleg na pumulupot sa leeg, di naging hadlang upang manatili ang pag tikom ng bibeg, lumaganap man ang maling balita kinahiligan ng mangmang, walang pakundangan magparatang na kinabilidan ng tanga, handang manghila pababa upang sila naman ang umangat, pagka’t akala nila wala ng kinabilangan kong pangkat ng mga nag angat sa musika’t sa pedistal ay iniluklok upang ibukod ang mga bugok sa hindi na bubulok, (kami yun)

-xxl
sa paghawak ko ng mikropono mga makata matigas to, bilang bayan ko parin ito, bilang isa walumpo’t pito nagsimula ang mga sundalo paranaque at tondo minahal na ang larong ito para palaganapin buong mundo’y may dumating na pagsubok kahit baril ang tumutok talata ko tumutusok makatang bumubulusok nag papasalamat ako sa pader, muling mawala’y lapit sa papel ito ang nagmistulang mga baril (di mo kaya paring abutin ang narating)

-spyker one
di mapigilan ang kalakasan ng basbas na mula sa taas siguro naman alam mo na kung pano kami manalanta ng walang iniiwan na bakas tanging lakas galing talento ang tinapat sa punyal na sandata walang makakapigil sa kampo ng mga mobsta sariling mga akda na samin lang nagmumula kami ang mga sundalong kinilala sa bansa ngayon alam mo na na walang kamatayan pagkat ang aming antas mataas ang pamantayan

-lil coli
mga galing sa laro dahil sa pagpupursige, nag simula sa maliit ngayon ay lumalaki ang samahan na pinagtibay ng pinuno’t alagad na kung may sumalungat ay itutumba agad kami ang sundalo sa kulturang to kaya’t wag ng humarang muling matutunghayan ang mga banat ng huwarang sa pagsulat ng kanta ng mga magkakapatid, tuloy tuloy sa paggawa na hindi mapapatid

-butangero
187 pinagsadugo ang lakas pinahupa ang tensyon kapit kamay na itataas ang bandila ng samahan ng mga sundalo ng kalye kapatiran kapitbisig at wala ng pasa kalye at wala na ang tampuhan na nagmistulan na parang lamat solido habang buhay yan ang aking pasasalamat, at ilalagay namin ang pangalan sa kasaysayan hindi mamamatay mas lalo pang pinagtibayan

-floydie banks:
(187)humanda sa pangingilagan mo, lahi ng matatapang na katipunero na lumalaban para sa larangan, handang buwis ng dugo mag alay para tumibay ang tulay na bagong daan sa tagumpay ang husay na nanalalaytay sa aming mga ugat ng pantay pantay pagtuloy ng malawakang paghakbangg marka ng sundalo ng tondo patungo sa tinatrato na pagbabago sa pag ikot ng mundo. saludo, respeto, paggalang nyo tanging naging sandalan ko sana itiniwala (ang paniniwala ng mga kaliga ko)

-thug prince
mga kasanligan ko bati muna saking heneral na nagbigay daan sakin maging ganap na animal halika makinig sa ratsadang wala ng preno preno “thugprince” basbasado oh oh bwelo bweno di na ko kailangang sitsitan senyasan lang ng kilay di matik pagbibigyan ng leksyon sa panahon di nako sisipat pinakawalang hiyang dila na sumisibat (sibat)

Chrous (miztah blaze)
Here comes the storm rushin’ in,
Don’t care what other people say
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…

You tryin’ to quit cuz the love is gone,
Without music I’m feelin’ all alone
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…

-curse one
bilang isang nilalang na sumumpang mag hahatid ng mga musikang kaylan man na’y hindi makaka limutan at inaalay kahit kanino man patuloy lang susulat ng tulang sumusugat gumugulat ang kantang nakaka mulat ng mata anu mang pag subok kayang kaya pag nag sama sama na ang mga sundalo ng kalsada (yi! leggo oh yeah)

-jruss
back and strong, i told you you were wrong still the undisputed so get your swagg on you said that i’am done, well im just just getting started so f**k you old guy , grow up you retarded see haters everywhere faggots everywhere you can miss me cause b***h im everywhere im on my own s**t they call me rushy russ so whos number one _MainContainer game? ‘ still us (187)

-kyvz
i put my hit, when i hit the limit. i put my speed when i keep and i’m almost quit it, i put my feet into dig. i put my music, mr.beat. i put my? ribs, don’t need with _MainContainer different s**t. by the gain the laws some, the chords then my fame, find the nerves, ten my words, suck to world. now can judge much heard. my heart only words, much nerds, as i spend the words with the proper verbs, you heard.

-lowdown
come to bully the flame of soldiers going to ranks, mighty tanks face that keeps on aiming the shooting flanks b***h! pump-paging like in the down of the stone of imortality, 187 match thats my reality! and the sum of defference we way if you think of me, _MainContainer is the measure that we mathematicaly symphony! you can instruct the fact that _MainContainer equation is beyond you! we don’t die we multiply still 187 mobstaz!

-plasma
baka pwedeng makinig ka muna sa, salitang aking sinasabi at alam mo na ba kung sino ang nagumpisa kung bakit ang lapit ng lait kahit hindi kami kumapit ay pilit ka pa ring kakapit sa kilalang malupit at bakit ka umiiling ng palihim mapapahanga rin kita dahil dugo ko’y (187) din boss balita lagay ng titulo mo? di na kami mabubura alamat ang titulo ko, kasi –

-syxx
wag munang balakin na ma. sundan ang mga batikan. sa larangan na kami ang hari dapat mga yapak namin sundan simula pa noon hanggang sa ngayon napasamin na ang istilo na ganito sinuman tumugon malaman baon diko papayagan hahayaan na ganito mack syxxx dimo kakayanin ang mga naabot na namin wawasakin ang mga bulaang batukan na naghahangad sa trono namin 187mobstaz lalong pinatibay ng mga sundalo at (ng heneral na umaagapay)

-stanlee
mike kahit kailan di kami mabubura pangkat namin nauna sa ganitong klasing taktika pagkat napa samin na istilo na di mo makita sa iba pinipilit ginagaya-gaya pero di naman makaya-kaya pagkat samin mo lang ngayon mapapakinggan ang ganitong banatan na dumaan malubog man sa putikan, di kami nag iwanan (mic) magpakaylan man di kami bibitaw at lalong di aayaw 187 mobstaz luzon visayas (mindanao)

-j-twist
patuloy sa pagyabong ng dahon at? ng sanga ng punong may ugat na ang dugo ay musika 187 mobstaz alam mo na kung a*o ang aking ibig sabihen nagsimula sa iilan ngayon ay di makayanang sumahen ang bilang ng mga di mapigilang pagdami ng nais mahirang nakasabay sa pambihira at natanging kapatirang itinuring na? ama ng mga hiphop sa pinas we dont die we multiply yeah malabon thugs

-krayziz
kami nang jack upang para tignan ng akin kami’y nagtago dahil kaylangan ng pahinga para pag labas ay meron pa kong lakas para mas maiangat ang antas sa pinakamataas na kalidad ng pinoy rap sa pinas 187 mobstaz malabon thugs naduwag ang lahat ng sa amin nag angas, samin ang katangian ng pagiging matigas, kami’y hahanay sa industriya simula hanggang wakas

-sparo
akala mo lang na nawala pero hindi pala bahagya lang naman na nagging abala mas tumuklas ng bala balang kayang abutin ang tala 187 malabon tatathug matatatag matatag pa samen na patag na pader na di ma tibag pinag balibagan naming gamet ang tula hi hip hop kone konektado di nilipad sama sa mga hakbang pag kakaisa ang nakatakda na palaguin payabungin payamanin patibayin na sundalo na rap game (sa pinas mobzters)

-tuglaks
marami nang nagsilupet at ang babagsik na dahilan ng aming laway nagsitalsik na ngumanga kaya’t lahat sila nakasalo ng bawat stilo ng isa walo pito(187) sino ba sino ba? ang pinanghuhugutan mo (187) san ba nakahanay lahat ng iniidulo mo malabong magkahiwalay cause we dont die we multiply (oh oh)

-hudass
kung naitapak man namin ang isang talampakan dun sa putikan itutuloy pa ang hangarin kahit di kame sundan kahit hindi mo to alam kahit hindi kame tignan isasalamin sa ming katahunan ang sundalo na handang makipaglaban tingalain ang nasa taas at sasaluduhan pag lumagpas sa limitasyon bawat hampas ay may katibayan bumannga ka sa piagkakapitagang nilalang burahin mo sa isipan ang ideyang iwanan

-abaddon
sa maraming pagbalasa sa baraha matapos ay putuloy paring kasama ang sundalo ng makata sa parangan ng matira matibay amin ang patunay habang buhay na mahusay at kame ang may ang akda ng paksang nagmaraka sating bansa nagsagawa ng kantang may basbas at akda laging handa mabutas man ang bangka sabay lang sa agos at sasagwan sa karagatan ng talangka

Chrous (miztah blaze)
Here comes the storm rushin’ in,
Don’t care what other people say
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…

You tryin’ to quit cuz the love is gone,
Without music I’m feelin’ all alone
Livin’ everyday the hiphop life,
WE DON’T DIE WE MULTIPLY…",
						Font = new Font("Helvetica", 10)
					};
					_BidItemDesc[loop].Controls.Add(_BidItemDescCont[loop]);
					_BidItemDescCont[loop].MouseEnter += new EventHandler(__MouseEnter);

					_BidStartLabel[loop] = new Label() {
						Size = new Size(40, 15),
						Location = new Point(2, 250),
						Text = "SBid",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Segoe UI", 10),
						ForeColor = Color.White,
						//ForeColor = ColorTranslator.FromHtml("#757575"),
						BackColor = ColorTranslator.FromHtml("#424242")
					};
					_BidContainer[loop].Controls.Add(_BidStartLabel[loop]);

					_BidCurrentLabel[loop] = new Label() {
						Size = new Size(40, 15),
						Location = new Point(2, 275),
						Text = "CBid",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Segoe UI", 10),
						ForeColor = Color.White,
						//ForeColor = ColorTranslator.FromHtml("#757575"),
						BackColor = ColorTranslator.FromHtml("#424242")
					};
					_BidContainer[loop].Controls.Add(_BidCurrentLabel[loop]);

					_BidStartPrice[loop] = new Label() {
						AutoSize = true,
						Location = new Point(42, 245),
						Text = "P 1000.0",
						TextAlign = ContentAlignment.MiddleLeft,
						Font = new Font("Arial", 10),
						//BackColor = Color.LightGray,
						ForeColor = ColorTranslator.FromHtml("#DD2C00"),
						//BackColor = ColorTranslator.FromHtml("#757575")
					};
					_BidContainer[loop].Controls.Add(_BidStartPrice[loop]);

					_BidCurrentPrice[loop] = new Label() {
						AutoSize = true,
						Location = new Point(42, 270),
						Text = "P 1100.0",
						TextAlign = ContentAlignment.MiddleLeft,
						Font = new Font("Helvetica", 10),
						ForeColor = ColorTranslator.FromHtml("#DD2C00"),
						//BackColor = ColorTranslator.FromHtml("#757575")
					};
					_BidContainer[loop].Controls.Add(_BidCurrentPrice[loop]);

					_BidView[loop] = new Label() {
						Tag = loop,
						Size = new Size(50, 45),
						Location = new Point(135, 245),
						Text = "#Views",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 10)
					};
					_BidView[loop].MouseEnter += new EventHandler(__MouseEnter);
					_BidView[loop].MouseLeave += new EventHandler(__MouseLeave);
					_BidContainer[loop].Controls.Add(_BidView[loop]);

						_BidViewCount[loop] = new Label() {
							Size = new Size(50, 10),
							Location = new Point(0, 35),
							Text = "384",
							TextAlign = ContentAlignment.MiddleCenter,
							Font = new Font("Helvetica", 8),
							BackColor = Color.FromArgb(100, Color.Black),
							ForeColor = Color.White
						};
						_BidView[loop].Controls.Add(_BidViewCount[loop]);

					_BidNumber[loop] = new Label() {
						Tag = loop,
						Size = new Size(50, 45),
						Location = new Point(190, 245),
						Text = "#Bids",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Helvetica", 10)
					};
					_BidNumber[loop].MouseEnter += new EventHandler(__MouseEnter);
					_BidNumber[loop].MouseLeave += new EventHandler(__MouseLeave);
					_BidContainer[loop].Controls.Add(_BidNumber[loop]);

						_BidNumberCount[loop] = new Label() {
							Size = new Size(50, 10),
							Location = new Point(0, 35),
							Text = "152",
							TextAlign = ContentAlignment.MiddleCenter,
							Font = new Font("Helvetica", 8),
							BackColor = Color.FromArgb(100, Color.Black),
							ForeColor = Color.White
						};
						_BidNumber[loop].Controls.Add(_BidNumberCount[loop]);

					_BidBidderName[loop] = new Label() {
						Size = new Size(300, 50),
						AutoSize = true,
						Location = new Point(0, 285),
						Text = "@BidderLover",
						TextAlign = ContentAlignment.MiddleRight,
						Font = new Font("Segoe UI", 11),
						ForeColor = Color.White,
						//ForeColor = ColorTranslator.FromHtml("#757575"),
						BackColor = ColorTranslator.FromHtml("#954535")
					};
					//_BidContainer[loop].Controls.Add(_BidBidderName[loop]);

					_BidBidderLabel[loop] = new Label() {
					};

					_BidButton[loop] = new Label() {
						Tag = loop,
						Size = new Size(250, 35),
						Location = new Point(0, 315),
						BackColor = ColorTranslator.FromHtml("#954535"),
						ForeColor = ColorTranslator.FromHtml("#FFFFFF"),
						Text = "JOIN BIDDING",
						TextAlign = ContentAlignment.MiddleCenter,
						Font = new Font("Segoe UI", 15)
					};
					_BidButton[loop].MouseEnter += new EventHandler(__MouseEnter);
					_BidButton[loop].MouseLeave += new EventHandler(__MouseLeave);
					_BidButton[loop].Click += new EventHandler(__MouseClick);
					_BidContainer[loop].Controls.Add(_BidButton[loop]);

					_BidAmountContainer[loop] = new Label() {
						Size = new Size(150, 55),
						Location = new Point(410, 230),
						BackColor = ColorTranslator.FromHtml("#954535")
					};
					//_BidContainer[loop].Controls.Add(_BidAmountContainer[loop]);

						_BidAmount[loop] = new RichTextBox() {
							Size = new Size(120, 40),
							Location = new Point(10, 8),
							BorderStyle = (BorderStyle)FlatStyle.Flat,
							Font = new Font("Segoe UI", 18),
						};
						//_BidAmountContainer[loop].Controls.Add(_BidAmount[loop]);
			}

			__SetLocation();
			_MainContainer.Select();
		}

		void __MouseEnter(object source, EventArgs e){
			var sender = source as Label;

			if(sender.Text == "#Views") {
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 30);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Green);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].TextAlign = ContentAlignment.TopCenter;
			} else if(sender.Text == "#Bids") {
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 15);
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 30);
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].TextAlign = ContentAlignment.TopCenter;
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(90, Color.Green);
			} else if(sender.Tag.ToString() == "Art" || sender.Tag.ToString() == "desc") {
				_BidItemDesc[Convert.ToInt32(sender.Parent.Tag.ToString())].Show();
				_DescNumber = Convert.ToInt32(sender.Parent.Tag.ToString());
			} else if(sender.Tag.ToString() == "desc") {
				_DescNumber = Convert.ToInt32(sender.Tag.ToString());
			} else if(sender.Text == "JOIN BIDDING") {
				sender.ForeColor = ColorTranslator.FromHtml("#954535");
				sender.BackColor = ColorTranslator.FromHtml("#FFFFFF");
			}
		}

		void __MouseLeave(object source, EventArgs e){
			var sender = source as Label;

			if(sender.Text == "#Views") {
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 10);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(100, Color.Black);
				_BidViewCount[Convert.ToInt32(sender.Tag.ToString())].TextAlign = ContentAlignment.MiddleCenter;
			} else if(sender.Text == "#Bids") {
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].Size = new Size(50, 10);
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].Location = new Point(0, 35);
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].BackColor = Color.FromArgb(100, Color.Black);
				_BidNumberCount[Convert.ToInt32(sender.Tag.ToString())].TextAlign = ContentAlignment.MiddleCenter;
			} else if(sender.Text == "JOIN BIDDING"){
				sender.BackColor = ColorTranslator.FromHtml("#954535");
				sender.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
			}
		}

		void __MouseClick(object source, EventArgs e){
			var sender = source as Label;
			if(sender.Tag.ToString() == "Art") {
				_BidItemDesc[Convert.ToInt32(sender.Parent.Tag.ToString())].Show();
				_DescNumber = Convert.ToInt32(sender.Parent.Tag.ToString());
			} else {
				Bitmap pic = new Bitmap(_BidImage[Convert.ToInt32(sender.Tag.ToString())].Image);
				_BidPageBox.Image = pic;
				_BidPageName.Text = _BidItem[Convert.ToInt32(sender.Tag.ToString())].Text;
				_BidPageTime.Location = new Point(225 + _BidPageName.Width, 22);
				_BidPageCondition.Location = new Point(225,  5 + _BidPageName.Height);
				_BidPageBuyIt.Location = new Point(225, 50 + _BidPageName.Height + _BidPageCondition.Height);
				_BidPage.Show();
			}
		}

		void __MouseClickBtn(object source, EventArgs ca) {
			var sender = source as Button;

			if(sender.Tag.ToString() == "BuyIt") {
				sender.Text = "SOLD!";
				sender.BackColor = Color.FromArgb(90, Color.Green);
				sender.Enabled = false;
			} else if(sender.Tag.ToString() == "Offer") {

				_MainContainer.Enabled = false;

				_OfferHolder = new Label() {
					Size = new Size(300, 200),
					Location = new Point(300, 80)
				};
				this.Controls.Add(_OfferHolder);
				_OfferHolder.BringToFront();

				Label _OfferCurLbl = new Label() {
					Size = new Size(110, 30),
					Text = "Current Bid  :",
					Font = new Font("Helvetica", 12),
					BackColor = Color.Transparent,
					ForeColor = Color.White,
					Location = new Point(20, 50)
				};
				_OfferHolder.Controls.Add(_OfferCurLbl);

				Label _OfferCurPrice = new Label() {
					MaximumSize = new Size(0, 40),
					AutoSize = true,
					Text = "P10,400",
					BackColor = Color.Transparent,
					ForeColor = ColorTranslator.FromHtml("#a22a2a"),
					Font = new Font("Helvetica", 20, FontStyle.Bold),
					Location = new Point(130, 40)
				};
				_OfferHolder.Controls.Add(_OfferCurPrice);

				Label _YourBidLbl = new Label() {
					Size = new Size(110, 30),
					Text = "Your Bid       : ",
					Font = new Font("Helvetica", 12),
					BackColor = Color.Transparent,
					ForeColor = Color.White,
					Location = new Point(20, 100)
				};
				_OfferHolder.Controls.Add(_YourBidLbl);

				TextBox _YourBidTxt = new TextBox() {
					Size = new Size(150, 30),
					Font = new Font("Helvetica", 15, FontStyle.Bold),
					ForeColor = ColorTranslator.FromHtml("#006400"),
					BackColor = ColorTranslator.FromHtml("#e6e6e6"),
					Location = new Point(130, 90)
				};
				_OfferHolder.Controls.Add(_YourBidTxt);

				Label _BidReminder = new Label() {
					AutoSize = true,
					Text = "Remember: Your bid must be HIGHER than the current bid.",
					Font = new Font("Helvetica", 8),
					BackColor = Color.Transparent,
					ForeColor = ColorTranslator.FromHtml("#d04949"),
					Location = new Point(2, 135)
				};
				_OfferHolder.Controls.Add(_BidReminder);

				Button _OfferCancel = new Button() {
					Tag = "OffCancel",
					Size = new Size(60, 20),
					Text = "Cancel",
					FlatStyle = FlatStyle.Flat,
					Font = new Font("Helvetica", 10),
					Location = new Point(10, 170)
				};
				_OfferHolder.Controls.Add(_OfferCancel);
				_OfferCancel.Click += new EventHandler(__MouseClickBtn);

				Button _OfferOk = new Button() {
					Tag = "OffOk",
					Size = new Size(60, 20),
					Text = "Ok",
					FlatStyle = FlatStyle.Flat,
					Font = new Font("Helvetica", 10),
					Location = new Point(230, 170)
				};
				_OfferHolder.Controls.Add(_OfferOk);
				_OfferOk.Click += new EventHandler(__MouseClickBtn);
			} else if(sender.Tag.ToString() == "OffCancel") {
				_OfferHolder.Hide();
				_MainContainer.Enabled = true;
			} else if(sender.Tag.ToString() == "OffOk") {
				_OfferHolder.Hide();
				_MainContainer.Enabled = true;
			}
		}

		/*============================================================================*
        *  Function   : __MouseEnterPBox
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Shows the description of the item being auctioned.
        *=============================================================================*/
		void __MouseEnterPBox(object source, EventArgs mea) {
			var sender = source as PictureBox;
			_DescNumber = Convert.ToInt32(sender.Parent.Tag.ToString());
			_BidItemDesc[Convert.ToInt32(sender.Tag.ToString())].Show();
		}

	   /*============================================================================*
        *  Function   : __MouseLeavePBox
        *  Params     : object source - Component that triggered the event.
                        EventArgs mla - Event Argument
        *  Returns    : Void
        *  Description: Unused mouse leave event.
        *=============================================================================*/
		void __MouseLeavePBox(object source, EventArgs mla) {
			var sender = source as PictureBox;
		}

	   /*============================================================================*
        *  Function   : __MouseClickPnl
        *  Params     : object source - Component that triggered the event.
                        EventArgs ca  - Event Argument
        *  Returns    : Void
        *  Description: Hides bid page panel.
        *=============================================================================*/
		void __MouseClickPnl(object source, EventArgs ca) {
			_BidPage.Hide();
		}

	   /*============================================================================*
        *  Function   : __MouseEnterPnl
        *  Params     : object source - Component that triggered the event.
                        EventArgs mea - Event Argument
        *  Returns    : Void
        *  Description: Hides description of the auctioned item.
        *=============================================================================*/
		void __MouseEnterPnl(object source, EventArgs mea) {
			var sender = source as Panel;
			_BidItemDesc[_DescNumber].Hide();
		}

	   /*============================================================================*
        *  Function   : __SetLocation
        *  Params     : None
        *  Returns    : Void
        *  Description: Manually sets location of the auctioned item container.
        *=============================================================================*/
		void __SetLocation(){
			x = Convert.ToInt32(_MainContainer.Width * .16);

			for(int loop = 0; loop < _BidCount; loop++){
				_BidContainer[loop].Location = new Point(x, y);
				x += 270;
				if((loop+1)%3 == 0){
					y += 380;
					x = Convert.ToInt32(_MainContainer.Width * 0.16);
				}
			}
		}

		/*==============================INITIALIZATION==============================*/
		static int _BidCount = 10;
		static int _DescNumber = 0;
		int x;
		int y = 10;

		Panel _BidPage;
			PictureBox _BidPageBox;
			Label _BidPageName;
			Label _BidPageTime;
			Label _BidPageCondition;
			Label _BidPageBuyIt;
			Button _BidPageBuyItBtn;
			Label _BidPageCurBid;
			Button _BidPageCurBtn;
			Label _BidPageOPRep;
			Label _BidPageOPPosFeed;
			Button _BidPageOPProfile;
			Label _BidPageItemSpecs;
		Panel _MainContainer;
		Label[] _BidContainer = new Label[_BidCount];
		Label[] _BidUsername = new Label[_BidCount];
		Label[] _BidStartLabel = new Label[_BidCount];
		Label[] _BidCurrentLabel = new Label[_BidCount];
		Label[] _BidStartPrice = new Label[_BidCount];
		Label[] _BidCurrentPrice = new Label[_BidCount];
		Label[] _BidBidderName = new Label[_BidCount];
		Label[] _BidBidderLabel = new Label[_BidCount];
		Label[] _BidEndDate = new Label[_BidCount];
		Label[] _BidButton = new Label[_BidCount];
		Label[] _BidItem = new Label[_BidCount];
			Panel[] _BidItemDesc = new Panel[_BidCount];
			Label[] _BidItemDescCont = new Label[_BidCount];
		Label[] _BidAmountContainer = new Label[_BidCount];
		Label[] _BidView = new Label[_BidCount];
			Label[] _BidViewCount = new Label[_BidCount];
		Label[] _BidNumber = new Label[_BidCount];
			Label[] _BidNumberCount = new Label[_BidCount];
		RichTextBox[] _BidAmount = new RichTextBox[_BidCount];
		PictureBox[] _BidImage = new PictureBox[_BidCount];
		PictureBox[] _BidUserIcon = new PictureBox[_BidCount];

		Label _OfferHolder;
	}
}
