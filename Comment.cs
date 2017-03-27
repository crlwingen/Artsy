/*============================================================================*
* Title       : Artsy (Social Application w/ Art Auction)
* Description : "Artsy" is a social application idea that would provide artists
                 a place to showcase their artworks and offer them the chance
                 to make a profit from it.
* Filename    : Comment.cs
* Version     : v1.0
* Author      : Batan, John Aldrin
* Yr&Sec&Uni  : BSCS 3-3 PUP Main
* Subject     : Advance Programming
*============================================================================*/

namespace Artsy {
	public class Comment {

		public string CommentID{
			get;
			set;
		}

		public string ArtworkID{
			get;
			set;
		}

		public string Content{
			get;
			set;
		}

		public string DateCommented{
			get;
			set;
		}
	}
}