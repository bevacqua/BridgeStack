namespace BridgeStack
{
	/// <summary>
	/// Exposes methods to access the StackExchange API. Includes methods that require authentication.
	/// <para>Documentation can be found following the link below:</para>
	/// <para>https://api.stackexchange.com/docs</para>
	/// </summary>
	public interface IAuthorizedStackClient : IStackClient
	{
		/// <summary>
		/// The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.
		/// </summary>
		string AccessToken { get; }

		#region API

		#region Events

		/// <summary>
		/// Makes a request to API method /events
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/events</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a stream of events that have occurred on the site.</returns>
		IBridgeResponseCollection<Event> GetEvents(SinceQuery parameters = null);

		#endregion

		#region Users

		#region Vectorized

		/// <summary>
		/// Makes a request to API method /users/{id}/inbox
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/user-inbox</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in a user's inbox.</returns>
		IBridgeResponseCollection<InboxItem> GetUserInbox(long id, SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /users/{id}/inbox/unread
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/user-unread-inbox</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns unread items in a user's inbox.</returns>
		IBridgeResponseCollection<InboxItem> GetUserInboxUnread(long id, SinceQuery parameters = null);

		#endregion

		#region Authenticated

		/// <summary>
		/// Makes a request to API method /me
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user.</returns>
		IBridgeResponseItem<User> GetMyUser(UsersQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/answers
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-answers</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers the authenticated user posted.</returns>
		IBridgeResponseCollection<Answer> GetMyAnswers(PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/badges
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-badges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badges the authenticated user earned.</returns>
		IBridgeResponseCollection<Badge> GetMyBadges(BadgesOnUserQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/comments
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-comments</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user posted.</returns>
		IBridgeResponseCollection<Comment> GetMyComments(CommentsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/comments/{toid}
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-comments-to</para>
		/// </summary>
		/// <param name="toId">The user who's mentioned (being replied to). {toid} parameter.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user posted in reply to  the single user identified by <paramref name="toId"/>.</returns>
		IBridgeResponseCollection<Comment> GetMyCommentsInReplyTo(long toId, CommentsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/favorites
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-favorites</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user favorited.</returns>
		IBridgeResponseCollection<Question> GetMyQuestionFavorites(QuestionFavoritesQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/mentioned
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-mentions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the authenticated user were mentioned in.</returns>
		IBridgeResponseCollection<Comment> GetMyMentions(CommentsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/privileges
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-privileges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the privileges the authenticated user has.</returns>
		IBridgeResponseCollection<Privilege> GetMyPrivileges(SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/questions
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked.</returns>
		IBridgeResponseCollection<Question> GetMyQuestions(PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/questions/no-answers
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-no-answer-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which have no answers.</returns>
		IBridgeResponseCollection<Question> GetMyQuestionsWithNoAnswers(PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/questions/unaccepted
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unaccepted-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which have at least one answer, but no accepted answer.</returns>
		IBridgeResponseCollection<Question> GetMyQuestionsWithNoAcceptedAnswer(PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/questions/unanswered
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unanswered-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the authenticated user asked, which the site consideres unanswered, while still having at least one answer posted.</returns>
		IBridgeResponseCollection<Question> GetMyQuestionsConsideredUnanswered(PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/reputation
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-reputation</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the reputation changes for the authenticated user.</returns>
		IBridgeResponseCollection<Reputation> GetMyReputationChanges(RangedQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/suggested-edits
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-suggested-edits</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits the authenticated user submitted.</returns>
		IBridgeResponseCollection<SuggestedEdit> GetMySuggestedEdits(SuggestedEditsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/tags
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags the authenticated user have been active in.</returns>
		IBridgeResponseCollection<Tag> GetMyActiveTags(TagsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/tags/{tags}/top-answers
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags-top-answers</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top answers the authenticated user has posted in response to questions with the given <paramref name="tags"/>.</returns>
		IBridgeResponseCollection<Answer> GetMyTopAnswers(string[] tags, PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/tags/{tags}/top-questions
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-tags-top-questions</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top questions the authenticated user has asked with the given <paramref name="tags"/>.</returns>
		IBridgeResponseCollection<Question> GetMyTopQuestions(string[] tags, PostsQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/timeline
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-timeline</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a subset of actions the authenticated user have taken on the system.</returns>
		IBridgeResponseCollection<UserTimeline> GetMyTimeline(RangedQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/top-answer-tags
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-top-answer-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user's top 30 tags by answer score.</returns>
		IBridgeResponseCollection<TagTop> GetMyTopAnswerTags(SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/top-question-tags
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-top-question-tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the authenticated user's top 30 tags by question score.</returns>
		IBridgeResponseCollection<TagTop> GetMyTopQuestionTags(SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /users/{id}/inbox
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in the authenticated user's inbox.</returns>
		IBridgeResponseCollection<InboxItem> GetMyInbox(SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /users/{id}/inbox/unread
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-unread-inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns unread items in the authenticated user's inbox.</returns>
		IBridgeResponseCollection<InboxItem> GetMyInboxUnread(SinceQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /me/associated
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/me-associated-users</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all of a user's associated accounts for a set of authenticated user.</returns>
		IBridgeResponseCollection<NetworkUser> GetMyAssociatedAccounts(SimpleQuery parameters = null);

		#endregion

		#endregion

		#region Network Methods

		/// <summary>
		/// Makes a request to API method /inbox
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/inbox</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all items in a user's inbox.</returns>		
		IBridgeResponseCollection<InboxItem> GetNetworkInbox(SimpleQuery parameters = null);
		/// <summary>
		/// Makes a request to API method /inbox/unread
		/// <para>Authentication required.</para>
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/inbox-unread</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the unread items in a user's inbox.</returns>
		IBridgeResponseCollection<InboxItem> GetNetworkInboxUnread(SinceQuery parameters = null);

		#endregion

		#endregion
	}
}