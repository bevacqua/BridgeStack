using System;

namespace BridgeStack
{
	internal sealed class AuthorizedStackClient : StackClient, IAuthorizedStackClient
	{
		/// <summary>
		/// The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.
		/// </summary>
		public string AccessToken { get; internal set; }

		/// <summary>
		/// Instances the AuthorizedStackClient implementation.
		/// </summary>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <param name="accessToken">The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.</param>
		/// <param name="plugins">The plugins to register with this AuthorizedStackClient instance.</param>
		internal AuthorizedStackClient(string appKey, string accessToken, StackClientPlugins plugins)
			: base(appKey, plugins)
		{
			if (accessToken == null)
			{
				throw new ArgumentNullException("accessToken");
			}
			AccessToken = accessToken;
		}

		#region IAuthorizedStackClient Implementation

		/// <summary>
		/// Makes a request to API method /events
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/events</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a stream of events that have occurred on the site.</returns>
		public IBridgeResponseCollection<Event> GetEvents(SinceQuery parameters = null)
		{
			return GetApiResultCollection<Event, SinceQuery>("events", parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{id}/inbox
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/user-inbox</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in a user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetUserInbox(long id, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SimpleQuery>("users/{id}/inbox", CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{id}/inbox/unread
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/user-unread-inbox</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns unread items in a user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetUserInboxUnread(long id, SinceQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SinceQuery>("users/{id}/inbox/unread", CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /me
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user.</returns>
		public IBridgeResponseItem<User> GetMyUser(UsersQuery parameters = null)
		{
			return GetApiResultItem<User, UsersQuery>("me", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-answers</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers the authenticated user posted.</returns>
		public IBridgeResponseCollection<Answer> GetMyAnswers(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>("me/answers", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/badges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-badges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badges the authenticated user earned.</returns>
		public IBridgeResponseCollection<Badge> GetMyBadges(BadgesOnUserQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesOnUserQuery>("me/badges", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-comments</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user posted.</returns>
		public IBridgeResponseCollection<Comment> GetMyComments(CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>("me/comments", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/comments/{toid}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-comments-to</para>
		/// </summary>
		/// <param name="toId">The user who's mentioned (being replied to). {toid} parameter.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user posted in reply to  the single user identified by <paramref name="toId"/>.</returns>
		public IBridgeResponseCollection<Comment> GetMyCommentsInReplyTo(long toId, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>("me/comments{toid}", CreateNamedVector("{toid}", new[] { toId }), parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/favorites
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-favorites</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user favorited.</returns>
		public IBridgeResponseCollection<Question> GetMyQuestionFavorites(QuestionFavoritesQuery parameters = null)
		{
			return GetApiResultCollection<Question, QuestionFavoritesQuery>("me/favorites", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/mentioned
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-mentions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user were mentioned in.</returns>
		public IBridgeResponseCollection<Comment> GetMyMentions(CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>("me/mentioned", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/privileges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-privileges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the privileges the authenticated user has.</returns>
		public IBridgeResponseCollection<Privilege> GetMyPrivileges(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<Privilege, SimpleQuery>("me/privileges", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked.</returns>
		public IBridgeResponseCollection<Question> GetMyQuestions(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>("me/questions", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/questions/no-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-no-answer-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which have no answers.</returns>
		public IBridgeResponseCollection<Question> GetMyQuestionsWithNoAnswers(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>("me/questions/no-answers", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/questions/unaccepted
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unaccepted-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which have at least one answer, but no accepted answer.</returns>
		public IBridgeResponseCollection<Question> GetMyQuestionsWithNoAcceptedAnswer(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>("me/questions/unaccepted", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/questions/unanswered
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unanswered-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which the site consideres unanswered, while still having at least one answer posted.</returns>
		public IBridgeResponseCollection<Question> GetMyQuestionsConsideredUnanswered(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>("me/questions/unanswered", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/reputation
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-reputation</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the reputation changes for the authenticated user.</returns>
		public IBridgeResponseCollection<Reputation> GetMyReputationChanges(RangedQuery parameters = null)
		{
			return GetApiResultCollection<Reputation, RangedQuery>("me/reputation", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-suggested-edits</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits the authenticated user submitted.</returns>
		public IBridgeResponseCollection<SuggestedEdit> GetMySuggestedEdits(SuggestedEditsQuery parameters = null)
		{
			return GetApiResultCollection<SuggestedEdit, SuggestedEditsQuery>("me/suggested-edits", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags the authenticated user have been active in.</returns>
		public IBridgeResponseCollection<Tag> GetMyActiveTags(TagsQuery parameters = null)
		{
			return GetApiResultCollection<Tag, TagsQuery>("me/tags", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/tags/{tags}/top-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags-top-answers</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top answers the authenticated user has posted in response to questions with the given <paramref name="tags"/>.</returns>
		public IBridgeResponseCollection<Answer> GetMyTopAnswers(string[] tags, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>("me/tags/{tags}/top-answers", CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/tags/{tags}/top-questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags-top-questions</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top questions the authenticated user has asked with the given <paramref name="tags"/>.</returns>
		public IBridgeResponseCollection<Question> GetMyTopQuestions(string[] tags, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>("me/tags/{tags}/top-questions", CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/timeline
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-timeline</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a subset of actions the authenticated user have taken on the system.</returns>
		public IBridgeResponseCollection<UserTimeline> GetMyTimeline(RangedQuery parameters = null)
		{
			return GetApiResultCollection<UserTimeline, RangedQuery>("me/timeline", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/top-answer-tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-top-answer-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user's top 30 tags by answer score.</returns>
		public IBridgeResponseCollection<TagTop> GetMyTopAnswerTags(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<TagTop, SimpleQuery>("me/top-answer-tags", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/top-question-tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-top-question-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user's top 30 tags by question score.</returns>
		public IBridgeResponseCollection<TagTop> GetMyTopQuestionTags(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<TagTop, SimpleQuery>("me/top-question-tags", parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{id}/inbox
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in the authenticated user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetMyInbox(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SimpleQuery>("me/inbox", parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{id}/inbox/unread
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unread-inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns unread items in the authenticated user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetMyInboxUnread(SinceQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SinceQuery>("me/inbox/unread", parameters);
		}

		/// <summary>
		/// Makes a request to API method /me/associated
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-associated-users</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all of a user's associated accounts for a set of authenticated user.</returns>
		public IBridgeResponseCollection<NetworkUser> GetMyAssociatedAccounts(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<NetworkUser, SimpleQuery>("me/associated", parameters);
		}

		/// <summary>
		/// Makes a request to API method /inbox
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in a user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetNetworkInbox(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SimpleQuery>("inbox", parameters);
		}

		/// <summary>
		/// Makes a request to API method /inbox/unread
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/inbox-unread</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the unread items in a user's inbox.</returns>
		public IBridgeResponseCollection<InboxItem> GetNetworkInboxUnread(SinceQuery parameters = null)
		{
			return GetApiResultCollection<InboxItem, SinceQuery>("inbox/unread", parameters);
		}

		#endregion
	}
}