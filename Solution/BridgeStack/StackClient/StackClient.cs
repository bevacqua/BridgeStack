using System;

namespace BridgeStack
{
	/// <summary>
	/// Concrete implementation of IStackClient that makes the actual requests to the API.
	/// </summary>
	internal class StackClient : StackClientBase
	{
		/// <summary>
		/// Instances the StackClient implementation.
		/// </summary>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <param name="plugins">The plugins to register with this StackClient instance.</param>
		internal StackClient(string appKey, StackClientPlugins plugins)
			: base(appKey, plugins)
		{
		}

		#region Overrides of StackClientBase

		/// <summary>
		/// Makes a request to API method /answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the undeleted answers in the system.</returns>
		public override IBridgeResponseCollection<Answer> GetAnswers(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>(ApiMethodEnum.Answers, parameters);
		}

		/// <summary>
		/// Makes a request to API method /answers/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-by-ids</para>
		/// </summary>
		/// <param name="ids">The answer {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of answers identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Answer> GetAnswers(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>(ApiMethodEnum.AnswersByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /answers/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-answers</para>
		/// </summary>
		/// <param name="ids">The answer {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on a set of answers identified by <paramref name="ids"/>..</returns>
		public override IBridgeResponseCollection<Comment> GetAnswersComments(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsOnAnswers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /answers/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-by-ids</para>
		/// </summary>
		/// <param name="id">The single answer in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answer identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Answer> GetAnswer(long id, PostsQuery parameters = null)
		{
			return GetAnswers(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /answers/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-answers</para>
		/// </summary>
		/// <param name="id">The single answer in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on an answers identified by <paramref name="id"/>..</returns>
		public override IBridgeResponseCollection<Comment> GetAnswerComments(long id, CommentsQuery parameters = null)
		{
			return GetAnswersComments(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the badges in the system.</returns>
		public override IBridgeResponseCollection<Badge> GetBadges(BadgesNamedQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesNamedQuery>(ApiMethodEnum.Badges, parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-by-ids</para>
		/// </summary>
		/// <param name="ids">The badge {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of badges identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Badge> GetBadges(long[] ids, BadgesQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesQuery>(ApiMethodEnum.BadgesByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/recipients
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badge-recipients</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns recently awarded badges in the system.</returns>
		public override IBridgeResponseCollection<Badge> GetBadgesRecipients(RangedQuery parameters = null)
		{
			return GetApiResultCollection<Badge, RangedQuery>(ApiMethodEnum.BadgeRecipients, parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/{ids}/recipients
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badge-recipients-by-ids</para>
		/// </summary>
		/// <param name="ids">The badge {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns recently awarded badges in the system, constrained to a certain set of badges identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Badge> GetBadgesRecipients(long[] ids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<Badge, RangedQuery>(ApiMethodEnum.BadgeRecipientsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/name
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-by-name</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all explicitly named badges in the system.</returns>
		public override IBridgeResponseCollection<Badge> GetBadgesExplicitlyNamed(BadgesNamedQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesNamedQuery>(ApiMethodEnum.BadgesByName, parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-by-tag</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badges that are awarded for participation in specific tags.</returns>
		public override IBridgeResponseCollection<Badge> GetBadgesOnTags(BadgesNamedQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesNamedQuery>(ApiMethodEnum.BadgesByTag, parameters);
		}

		/// <summary>
		/// Makes a request to API method /badges/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-by-ids</para>
		/// </summary>
		/// <param name="id">The single badge in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badge identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Badge> GetBadge(long id, BadgesQuery parameters = null)
		{
			return GetBadges(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /badges/{ids}/recipients
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badge-recipients-by-ids</para>
		/// </summary>
		/// <param name="id">The single badge in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns recently awarded badges in the system, constrained to a badge identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Badge> GetBadgeRecipients(long id, RangedQuery parameters = null)
		{
			return GetBadgesRecipients(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the comments on the site.</returns>
		public override IBridgeResponseCollection<Comment> GetComments(CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.Comments, parameters);
		}

		/// <summary>
		/// Makes a request to API method /comments/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-by-ids</para>
		/// </summary>
		/// <param name="ids">The comment {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of comments identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetComments(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /comments/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-by-ids</para>
		/// </summary>
		/// <param name="id">The single comment in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comment identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Comment> GetComment(long id, CommentsQuery parameters = null)
		{
			return GetComments(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /errors
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/errors</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the various error codes that can be produced by the API.</returns>
		public override IBridgeResponseCollection<ApiException> GetErrors(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<ApiException, SimpleQuery>(ApiMethodEnum.Errors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /errors/{id}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/simulate-error</para>
		/// </summary>
		/// <param name="id">The id of the error to simulate</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>This method allows you to generate an error.</returns>
		public override IBridgeResponseItem<ApiException> SimulateError(int id, SiteQuery parameters = null)
		{
			return GetApiResultItem<ApiException, SiteQuery>(ApiMethodEnum.SimulateError, CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/posts</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the posts (questions and answers) in the system.</returns>
		public override IBridgeResponseCollection<Post> GetPosts(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Post, PostsQuery>(ApiMethodEnum.Posts, parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/posts-by-ids</para>
		/// </summary>
		/// <param name="ids">The posts {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of posts (questions and answers) identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Post> GetPosts(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Post, PostsQuery>(ApiMethodEnum.PostsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-posts</para>
		/// </summary>
		/// <param name="ids">The posts {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on the posts identified by <paramref name="ids"/>, regardless of the type of the posts.</returns>
		public override IBridgeResponseCollection<Comment> GetPostsComments(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsOnPosts, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/revisions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/revisions-by-ids</para>
		/// </summary>
		/// <param name="ids">The posts {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the edit revisions on the posts identified by <paramref name="ids"/>, regardless of the type of the posts.</returns>
		public override IBridgeResponseCollection<Revision> GetPostsRevisions(long[] ids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<Revision, RangedQuery>(ApiMethodEnum.RevisionsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/posts-on-suggested-edits</para>
		/// </summary>
		/// <param name="ids">The posts {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits on the posts identified by <paramref name="ids"/>, regardless of the type of the posts.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetPostsSuggestedEdits(long[] ids, SuggestedEditsQuery parameters = null)
		{
			return GetApiResultCollection<SuggestedEdit, SuggestedEditsQuery>(ApiMethodEnum.PostsOnSuggestedEdits, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/posts-by-ids</para>
		/// </summary>
		/// <param name="id">The single post in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the post identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Post> GetPost(long id, PostsQuery parameters = null)
		{
			return GetPosts(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-posts</para>
		/// </summary>
		/// <param name="id">The single post in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on the post identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetPostComments(long id, CommentsQuery parameters = null)
		{
			return GetPostsComments(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/revisions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/revisions-by-ids</para>
		/// </summary>
		/// <param name="id">The single post in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the edit revisions on the post identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Revision> GetPostRevisions(long id, RangedQuery parameters = null)
		{
			return GetPostsRevisions(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /posts/{ids}/suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/posts-on-suggested-edits</para>
		/// </summary>
		/// <param name="id">The single post in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits on the post identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetPostSuggestedEdits(long id, SuggestedEditsQuery parameters = null)
		{
			return GetPostsSuggestedEdits(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /privileges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/privileges</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the privileges that can be earned on a site.</returns>
		public override IBridgeResponseCollection<Privilege> GetPrivileges(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<Privilege, SimpleQuery>(ApiMethodEnum.Privileges, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the questions in the system.</returns>
		public override IBridgeResponseCollection<Question> GetQuestions(QuestionsQuery parameters = null)
		{
			return GetApiResultCollection<Question, QuestionsQuery>(ApiMethodEnum.Questions, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-by-ids</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of questions identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Question> GetQuestions(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.QuestionsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-on-questions</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers on the questions identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Answer> GetQuestionsAnswers(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>(ApiMethodEnum.AnswersOnQuestions, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-questions</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on the questions identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetQuestionsComments(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsOnQuestions, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/linked
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/linked-questions</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions which link to those identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionsLinked(long[] ids, QuestionsRelatedQuery parameters = null)
		{
			return GetApiResultCollection<Question, QuestionsRelatedQuery>(ApiMethodEnum.LinkedQuestions, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/related
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/related-questions</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns questions that the site considers related to those identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionsRelated(long[] ids, QuestionsRelatedQuery parameters = null)
		{
			return GetApiResultCollection<Question, QuestionsRelatedQuery>(ApiMethodEnum.RelatedQuestions, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/timeline
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-timeline</para>
		/// </summary>
		/// <param name="ids">The question {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the timeline for questions identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<QuestionTimeline> GetQuestionsTimeline(long[] ids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<QuestionTimeline, RangedQuery>(ApiMethodEnum.QuestionsTimeline, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/unanswered
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/unanswered-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns questions the site considers to be unanswered.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionsConsideredUnanswered(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.UnansweredQuestions, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/no-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/no-answer-questions</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns questions which have received no answers.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionsWithNoAnswers(PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.NoAnswerQuestions, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-by-ids</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of question identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Question> GetQuestion(long id, PostsQuery parameters = null)
		{
			return GetQuestions(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-on-questions</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers on the question identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Answer> GetQuestionAnswers(long id, PostsQuery parameters = null)
		{
			return GetQuestionsAnswers(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-questions</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments on the question identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetQuestionComments(long id, CommentsQuery parameters = null)
		{
			return GetQuestionsComments(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/linked
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/linked-questions</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions which link to that identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionLinked(long id, QuestionsRelatedQuery parameters = null)
		{
			return GetQuestionsLinked(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/related
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/related-questions</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns questions that the site considers related to that identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Question> GetQuestionRelated(long id, QuestionsRelatedQuery parameters = null)
		{
			return GetQuestionsRelated(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /questions/{ids}/timeline
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-timeline</para>
		/// </summary>
		/// <param name="id">The single question in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the timeline for the question identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<QuestionTimeline> GetQuestionTimeline(long id, RangedQuery parameters = null)
		{
			return GetQuestionsTimeline(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /revisions/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/revisions-by-guids</para>
		/// </summary>
		/// <param name="guids">The revision {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns edit revisions identified by <paramref name="guids"/>.</returns>
		public override IBridgeResponseCollection<Revision> GetRevisions(Guid[] guids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<Revision, RangedQuery>(ApiMethodEnum.RevisionsByGuids, CreateIdsVector(guids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /revisions/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/revisions-by-guids</para>
		/// </summary>
		/// <param name="guid">The single revision in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the edit revision identified by <paramref name="guid"/>.</returns>
		public override IBridgeResponseItem<Revision> GetRevision(Guid guid, RangedQuery parameters = null)
		{
			return GetRevisions(new[] { guid }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /search
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/search</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns any questions which satisfy a search criteria.</returns>
		public override IBridgeResponseCollection<Question> Search(SearchQuery parameters = null)
		{
			return GetApiResultCollection<Question, SearchQuery>(ApiMethodEnum.Search, parameters);
		}

		/// <summary>
		/// Makes a request to API method /similar
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/similar</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns questions which are similar to a hypothetical one based on a title and tag combination.</returns>
		public override IBridgeResponseCollection<Question> Similar(SearchSimilarQuery parameters = null)
		{
			return GetApiResultCollection<Question, SearchSimilarQuery>(ApiMethodEnum.Similar, parameters);
		}

		/// <summary>
		/// Makes a request to API method /suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/suggested-edits</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the suggested edits in the system.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetSuggestedEdits(SuggestedEditsQuery parameters = null)
		{
			return GetApiResultCollection<SuggestedEdit, SuggestedEditsQuery>(ApiMethodEnum.SuggestedEdits, parameters);
		}

		/// <summary>
		/// Makes a request to API method /suggested-edits/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/suggested-edits-by-ids</para>
		/// </summary>
		/// <param name="ids">The suggested edit {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of suggested edits identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetSuggestedEdits(long[] ids, SuggestedEditsQuery parameters = null)
		{
			return GetApiResultCollection<SuggestedEdit, SuggestedEditsQuery>(ApiMethodEnum.SuggestedEditsByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /suggested-edits/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/suggested-edits-by-ids</para>
		/// </summary>
		/// <param name="id">The single suggested edit in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edis identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<SuggestedEdit> GetSuggestedEdit(long id, SuggestedEditsQuery parameters = null)
		{
			return GetSuggestedEdits(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /info
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/info</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a collection of statistics about the site.</returns>
		public override IBridgeResponseItem<NetworkSiteStats> GetInfo(SiteQuery parameters = null)
		{
			return GetApiResultItem<NetworkSiteStats, SiteQuery>(ApiMethodEnum.Info, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/tags</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the tags found on a site.</returns>
		public override IBridgeResponseCollection<Tag> GetTags(TagsQuery parameters = null)
		{
			return GetApiResultCollection<Tag, TagsQuery>(ApiMethodEnum.Tags, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/synonyms
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/tag-synonyms</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all tag synonyms found a site.</returns>
		public override IBridgeResponseCollection<TagSynonym> GetTagSynonyms(TagSynonymsQuery parameters = null)
		{
			return GetApiResultCollection<TagSynonym, TagSynonymsQuery>(ApiMethodEnum.TagSynonyms, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/faq
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/faqs-by-tags</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the frequently asked questions for the given set of tags in <paramref name="tags"/>.</returns>
		public override IBridgeResponseCollection<Question> GetTagsFrequentlyAskedQuestions(string[] tags, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<Question, SimpleQuery>(ApiMethodEnum.FAQ, CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/related
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/related-tags</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags that are most related to those in <paramref name="tags"/>.</returns>
		public override IBridgeResponseCollection<Tag> GetTagsRelated(string[] tags, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<Tag, SimpleQuery>(ApiMethodEnum.RelatedTags, CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/synonyms
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/synonyms-by-tags</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags synonyms for the given set of tags in <paramref name="tags"/>.</returns>
		public override IBridgeResponseCollection<TagSynonym> GetTagsSynonyms(string[] tags, TagSynonymsQuery parameters = null)
		{
			return GetApiResultCollection<TagSynonym, TagSynonymsQuery>(ApiMethodEnum.SynonymsByTags, CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tag}/top-answerers/{period}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-answerers-on-tags</para>
		/// </summary>
		/// <param name="tag">A single {tag}.</param>
		/// <param name="period">The selected {period}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top 30 answerers active in a single tag, of either all-time or the last 30 days.</returns>
		public override IBridgeResponseCollection<TagScore> GetTagTopAnswerers(string tag, QueryPeriodEnum period, TagScoresQuery parameters = null)
		{
			IRequestVector[] vectors = new[] { CreateTagVector(tag), CreateEnumVector("{period}", period) };
			return GetApiResultCollection<TagScore, TagScoresQuery>(ApiMethodEnum.TopAnswerersOnTags, vectors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tag}/top-askers/{period}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-askers-on-tags</para>
		/// </summary>
		/// <param name="tag">A single {tag}.</param>
		/// <param name="period">The selected {period}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top 30 askers active in a single tag, of either all-time or the last 30 days.</returns>
		public override IBridgeResponseCollection<TagScore> GetTagTopAskers(string tag, QueryPeriodEnum period, TagScoresQuery parameters = null)
		{
			IRequestVector[] vectors = new[] { CreateTagVector(tag), CreateEnumVector("{period}", period) };
			return GetApiResultCollection<TagScore, TagScoresQuery>(ApiMethodEnum.TopAskersOnTags, vectors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/wikis
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/wikis-by-tags</para>
		/// </summary>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the wikis that go with the given set of tags in {tags}.</returns>
		public override IBridgeResponseCollection<TagWiki> GetTagsWikis(string[] tags, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<TagWiki, SimpleQuery>(ApiMethodEnum.WikisByTags, CreateTagsVector(tags), parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/faq
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/faqs-by-tags</para>
		/// </summary>
		/// <param name="tag">The single tag in {tags}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the frequently asked questions for the tag identified by <paramref name="tag"/>.</returns>
		public override IBridgeResponseCollection<Question> GetTagFrequentlyAskedQuestions(string tag, SimpleQuery parameters = null)
		{
			return GetTagsFrequentlyAskedQuestions(new[] { tag }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/related
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/related-tags</para>
		/// </summary>
		/// <param name="tag">The single tag in {tags}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags that are most related to that identified by <paramref name="tag"/>.</returns>
		public override IBridgeResponseCollection<Tag> GetTagRelated(string tag, TagsQuery parameters = null)
		{
			return GetTagsRelated(new[] { tag }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/synonyms
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/synonyms-by-tags</para>
		/// </summary>
		/// <param name="tag">The single tag in {tags}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags synonyms for the tag identified by <paramref name="tag"/>.</returns>
		public override IBridgeResponseCollection<TagSynonym> GetTagSynonyms(string tag, TagSynonymsQuery parameters = null)
		{
			return GetTagsSynonyms(new[] { tag }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /tags/{tags}/wikis
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/wikis-by-tags</para>
		/// </summary>
		/// <param name="tag">The single tag in {tags}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags wiki for the tag identified by <paramref name="tag"/>.</returns>
		public override IBridgeResponseItem<TagWiki> GetTagWiki(string tag, SimpleQuery parameters = null)
		{
			return GetTagsWikis(new[] { tag }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /users
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/users</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all the users in the system.</returns>
		public override IBridgeResponseCollection<User> GetUsers(UsersNamedQuery parameters = null)
		{
			return GetApiResultCollection<User, UsersNamedQuery>(ApiMethodEnum.Users, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/users-by-ids</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the set of users identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<User> GetUsers(long[] ids, UsersQuery parameters = null)
		{
			return GetApiResultCollection<User, UsersQuery>(ApiMethodEnum.UsersByIds, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers the users identified by <paramref name="ids"/> posted.</returns>
		public override IBridgeResponseCollection<Answer> GetUsersAnswers(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Answer, PostsQuery>(ApiMethodEnum.AnswersOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/badges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badges the users identified by <paramref name="ids"/> earned.</returns>
		public override IBridgeResponseCollection<Badge> GetUsersBadges(long[] ids, BadgesOnUserQuery parameters = null)
		{
			return GetApiResultCollection<Badge, BadgesOnUserQuery>(ApiMethodEnum.BadgesOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the users identified by <paramref name="ids"/> posted.</returns>
		public override IBridgeResponseCollection<Comment> GetUsersComments(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/comments/{toid}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-by-users-to-user</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="toId">The user who's mentioned (being replied to). {toid} parameter.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the users identified by <paramref name="ids"/> posted in reply to  the single user identified by <paramref name="toId"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetUsersCommentsInReplyTo(long[] ids, long toId, CommentsQuery parameters = null)
		{
			IRequestVector[] vectors = new[] { CreateIdsVector(ids), CreateNamedVector("{toid}", new[] { toId }) };
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.CommentsByUsersToUser, vectors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/favorites
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/favorites-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the users identified by <paramref name="ids"/> favorited.</returns>
		public override IBridgeResponseCollection<Question> GetUsersQuestionFavorites(long[] ids, QuestionFavoritesQuery parameters = null)
		{
			return GetApiResultCollection<Question, QuestionFavoritesQuery>(ApiMethodEnum.FavoritesOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/mentioned
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/mentions-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the users identified by <paramref name="ids"/> were mentioned in.</returns>
		public override IBridgeResponseCollection<Comment> GetUsersMentions(long[] ids, CommentsQuery parameters = null)
		{
			return GetApiResultCollection<Comment, CommentsQuery>(ApiMethodEnum.MentionsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{id}/privileges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/privileges-on-users</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the privileges the user identified by <paramref name="id"/> has.</returns>
		public override IBridgeResponseCollection<Privilege> GetUserPrivileges(long id, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<Privilege, SimpleQuery>(ApiMethodEnum.PrivilegesOnUsers, CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the users identified by <paramref name="ids"/> asked.</returns>
		public override IBridgeResponseCollection<Question> GetUsersQuestions(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.QuestionsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/no-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/no-answer-questions-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the users identified by <paramref name="ids"/> asked, which have no answers.</returns>
		public override IBridgeResponseCollection<Question> GetUsersQuestionsWithNoAnswers(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.NoAnswerQuestionsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/unaccepted
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/unaccepted-questions-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the users identified by <paramref name="ids"/> asked, which have at least one answer, but no accepted answer.</returns>
		public override IBridgeResponseCollection<Question> GetUsersQuestionsWithNoAcceptedAnswer(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.UnacceptedQuestionsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/unanswered
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/unanswered-questions-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the users identified by <paramref name="ids"/> asked, which the site consideres unanswered, while still having at least one answer posted.</returns>
		public override IBridgeResponseCollection<Question> GetUsersQuestionsConsideredUnanswered(long[] ids, PostsQuery parameters = null)
		{
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.UnansweredQuestionsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/reputation
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/reputation-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the reputation changes for the users identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<Reputation> GetUsersReputationChanges(long[] ids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<Reputation, RangedQuery>(ApiMethodEnum.ReputationOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/suggested-edits-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits the users identified by <paramref name="ids"/> submitted.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetUsersSuggestedEdits(long[] ids, SuggestedEditsQuery parameters = null)
		{
			return GetApiResultCollection<SuggestedEdit, SuggestedEditsQuery>(ApiMethodEnum.SuggestedEditsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/tags-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags the users identified by <paramref name="ids"/> have been active in.</returns>
		public override IBridgeResponseCollection<Tag> GetUsersActiveTags(long[] ids, TagsQuery parameters = null)
		{
			return GetApiResultCollection<Tag, TagsQuery>(ApiMethodEnum.TagsOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/tags/{tags}/top-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-user-answers-in-tags</para>
		/// </summary>
		/// /// <param name="id">The single user {id}.</param>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top answers the users identified by <paramref name="id"/> has posted in response to questions with the given <paramref name="tags"/>.</returns>
		public override IBridgeResponseCollection<Answer> GetUserTopAnswers(long id, string[] tags, PostsQuery parameters = null)
		{
			IRequestVector[] vectors = new[] { CreateIdVector(id), CreateTagsVector(tags) };
			return GetApiResultCollection<Answer, PostsQuery>(ApiMethodEnum.TopUserAnswersInTags, vectors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/tags/{tags}/top-questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-user-questions-in-tags</para>
		/// </summary>
		/// /// <param name="id">The single user {id}.</param>
		/// <param name="tags">The {tags} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the top questions the users identified by <paramref name="id"/> has asked with the given <paramref name="tags"/>.</returns>
		public override IBridgeResponseCollection<Question> GetUserTopQuestions(long id, string[] tags, PostsQuery parameters = null)
		{
			IRequestVector[] vectors = new[] { CreateIdVector(id), CreateTagsVector(tags) };
			return GetApiResultCollection<Question, PostsQuery>(ApiMethodEnum.TopUserQuestionsInTags, vectors, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/timeline
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/timeline-on-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a subset of actions the users identified by <paramref name="ids"/> have taken on the system.</returns>
		public override IBridgeResponseCollection<UserTimeline> GetUsersTimeline(long[] ids, RangedQuery parameters = null)
		{
			return GetApiResultCollection<UserTimeline, RangedQuery>(ApiMethodEnum.TimelineOnUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/top-answer-tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-answer-tags-on-users</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a single user's top 30 tags by answer score.</returns>
		public override IBridgeResponseCollection<TagTop> GetUserTopAnswerTags(long id, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<TagTop, SimpleQuery>(ApiMethodEnum.TopAnswerTagsOnUsers, CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/top-question-tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/top-question-tags-on-users</para>
		/// </summary>
		/// <param name="id">The single user {id}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a single user's top 30 tags by question score.</returns>
		public override IBridgeResponseCollection<TagTop> GetUserTopQuestionTags(long id, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<TagTop, SimpleQuery>(ApiMethodEnum.TopQuestionTagsOnUsers, CreateIdVector(id), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/moderators
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/moderators</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Gets those users on a system who can exercise moderation powers.</returns>
		public override IBridgeResponseCollection<User> GetModerators(UsersQuery parameters = null)
		{
			return GetApiResultCollection<User, UsersQuery>(ApiMethodEnum.Moderators, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/moderators/elected
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/elected-moderators</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns those users on a site who both have moderator powers, and were actually elected.</returns>
		public override IBridgeResponseCollection<User> GetModeratorsElected(UsersQuery parameters = null)
		{
			return GetApiResultCollection<User, UsersQuery>(ApiMethodEnum.ElectedModerators, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/associated
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/associated-users</para>
		/// </summary>
		/// <param name="ids">The user {ids} vector.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all of a user's associated accounts for a set of users identified by <paramref name="ids"/>.</returns>
		public override IBridgeResponseCollection<NetworkUser> GetUsersAssociatedAccounts(long[] ids, SimpleQuery parameters = null)
		{
			return GetApiResultCollection<NetworkUser, SimpleQuery>(ApiMethodEnum.AssociatedUsers, CreateIdsVector(ids), parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/users-by-ids</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the user identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<User> GetUser(long id, UsersQuery parameters = null)
		{
			return GetUsers(new[] { id }, parameters).Single();
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/answers-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the answers the user identified by <paramref name="id"/> posted.</returns>
		public override IBridgeResponseCollection<Answer> GetUserAnswers(long id, PostsQuery parameters = null)
		{
			return GetUsersAnswers(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/badges
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/badges-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the badges the user identified by <paramref name="id"/> earned.</returns>
		public override IBridgeResponseCollection<Badge> GetUserBadges(long id, BadgesOnUserQuery parameters = null)
		{
			return GetUsersBadges(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/comments
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the user identified by <paramref name="id"/> posted.</returns>
		public override IBridgeResponseCollection<Comment> GetUserComments(long id, CommentsQuery parameters = null)
		{
			return GetUsersComments(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/comments/{toid}
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/comments-by-users-to-user</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="toId">The user who's mentioned (being replied to). {toid} parameter.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the user identified by <paramref name="id"/> posted in reply to  the single user identified by <paramref name="toId"/>.</returns>
		public override IBridgeResponseCollection<Comment> GetUserCommentsInReplyTo(long id, long toId, CommentsQuery parameters = null)
		{
			return GetUsersCommentsInReplyTo(new[] { id }, toId, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/favorites
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/favorites-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the user identified by <paramref name="id"/> favorited.</returns>
		public override IBridgeResponseCollection<Question> GetUserQuestionFavorites(long id, QuestionFavoritesQuery parameters = null)
		{
			return GetUsersQuestionFavorites(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/mentioned
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/mentions-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the comments the user identified by <paramref name="id"/> were mentioned in.</returns>
		public override IBridgeResponseCollection<Comment> GetUserMentions(long id, CommentsQuery parameters = null)
		{
			return GetUsersMentions(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/questions-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the user identified by <paramref name="id"/> asked.</returns>
		public override IBridgeResponseCollection<Question> GetUserQuestions(long id, PostsQuery parameters = null)
		{
			return GetUsersQuestions(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/no-answers
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/no-answer-questions-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the user identified by <paramref name="id"/> asked, which have no answers.</returns>
		public override IBridgeResponseCollection<Question> GetUserQuestionsWithNoAnswers(long id, PostsQuery parameters = null)
		{
			return GetUsersQuestionsWithNoAnswers(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/unaccepted
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/unaccepted-questions-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the user identified by <paramref name="id"/> asked, which have at least one answer, but no accepted answer.</returns>
		public override IBridgeResponseCollection<Question> GetUserQuestionsWithNoAcceptedAnswer(long id, PostsQuery parameters = null)
		{
			return GetUsersQuestionsWithNoAcceptedAnswer(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/questions/unanswered
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/unanswered-questions-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the questions the user identified by <paramref name="id"/> asked, which the site consideres unanswered, while still having at least one answer posted.</returns>
		public override IBridgeResponseCollection<Question> GetUserQuestionsConsideredUnanswered(long id, PostsQuery parameters = null)
		{
			return GetUsersQuestionsConsideredUnanswered(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/reputation
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/reputation-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the reputation changes for the user identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<Reputation> GetUserReputationChanges(long id, RangedQuery parameters = null)
		{
			return GetUsersReputationChanges(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/suggested-edits
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/suggested-edits-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the suggested edits the user identified by <paramref name="id"/> submitted.</returns>
		public override IBridgeResponseCollection<SuggestedEdit> GetUserSuggestedEdits(long id, SuggestedEditsQuery parameters = null)
		{
			return GetUsersSuggestedEdits(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/tags
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/tags-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns the tags the user identified by <paramref name="id"/> have been active in.</returns>
		public override IBridgeResponseCollection<Tag> GetUserActiveTags(long id, TagsQuery parameters = null)
		{
			return GetUsersActiveTags(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/timeline
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/timeline-on-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns a subset of actions the user identified by <paramref name="id"/> have taken on the system.</returns>
		public override IBridgeResponseCollection<UserTimeline> GetUserTimeline(long id, RangedQuery parameters = null)
		{
			return GetUsersTimeline(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /users/{ids}/associated
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/associated-users</para>
		/// </summary>
		/// <param name="id">The single user in {ids}.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all of a user's associated accounts for a set of user identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseCollection<NetworkUser> GetUserAssociatedAccounts(long id, SimpleQuery parameters = null)
		{
			return GetUsersAssociatedAccounts(new[] { id }, parameters);
		}

		/// <summary>
		/// Makes a request to API method /access-tokens/{accessTokens}/invalidate
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/invalidate-access-tokens</para>
		/// </summary>
		/// <param name="tokens">The access token {accessTokens} vector.</param>
		/// <returns>Immediately expires the access tokens passed. This method is meant to allow an application to discard any active access tokens it no longer needs.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokensInvalidate(string[] tokens)
		{
			return GetApiResultCollection<AccessToken, NullQuery>(ApiMethodEnum.InvalidateAccessTokens, CreateNamedVector("{accessTokens}", tokens), null);
		}

		/// <summary>
		/// Makes a request to API method /access-tokens/{accessTokens}/read
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/read-access-tokens</para>
		/// </summary>
		/// <param name="tokens">The access token {accessTokens} vector.</param>
		/// <returns>Returns the properties for a set of access tokens.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokensRead(string[] tokens)
		{
			return GetApiResultCollection<AccessToken, NullQuery>(ApiMethodEnum.ReadAccessTokens, CreateNamedVector("{accessTokens}", tokens), null);
		}

		/// <summary>
		/// Makes a request to API method /apps/{accessTokens}/de-authenticate
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/application-de-authenticate</para>
		/// </summary>
		/// <param name="tokens">The access token {accessTokens} vector.</param>
		/// <returns>This method is meant for uninstalling applications, recovering from access_token leaks, or simply as a stronger form of <see cref="IStackClient.AccessTokenInvalidate"/>.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokensDeauthenticate(string[] tokens)
		{
			return GetApiResultCollection<AccessToken, NullQuery>(ApiMethodEnum.ApplicationDeauthenticate, CreateNamedVector("{accessTokens}", tokens), null);
		}

		/// <summary>
		/// Makes a request to API method /access-tokens/{accessTokens}/invalidate
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/invalidate-access-tokens</para>
		/// </summary>
		/// <param name="token">The single access token in {accessTokens}.</param>
		/// <returns>Immediately expires the access tokens passed. This method is meant to allow an application to discard any active access tokens it no longer needs.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokenInvalidate(string token)
		{
			return AccessTokensInvalidate(new[] { token });
		}

		/// <summary>
		/// Makes a request to API method /access-tokens/{accessTokens}/read
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/read-access-tokens</para>
		/// </summary>
		/// <param name="token">The single access token in {accessTokens}.</param>
		/// <returns>Returns the properties for a set of access tokens.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokenRead(string token)
		{
			return AccessTokensRead(new[] { token });
		}

		/// <summary>
		/// Makes a request to API method /apps/{accessTokens}/de-authenticate
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/application-de-authenticate</para>
		/// </summary>
		/// <param name="token">The single access token in {accessTokens}.</param>
		/// <returns>This method is meant for uninstalling applications, recovering from access_token leaks, or simply as a stronger form of <see cref="IStackClient.AccessTokenInvalidate"/>.</returns>
		public override IBridgeResponseCollection<AccessToken> AccessTokenDeauthenticate(string token)
		{
			return AccessTokensDeauthenticate(new[] { token });
		}

		/// <summary>
		/// Makes a request to API method /filter/create
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/create-filter</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Creates a new filter given a list of includes, excludes, a base filter, and whether or not this filter should be "unsafe".</returns>
		public override IBridgeResponseItem<Filter> CreateNetworkFilter(CreateFilterQuery parameters = null)
		{
			return GetApiResultItem<Filter, CreateFilterQuery>(ApiMethodEnum.FilterCreate, parameters);
		}

		/// <summary>
		/// Makes a request to API method /filter/{filters}/read
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/read-filter</para>
		/// </summary>
		/// <param name="ids">The filter {ids} vector.</param>
		/// <returns>Returns the fields included by the filters identified by <paramref name="ids"/>, and the "safeness" of those filters.</returns>
		public override IBridgeResponseCollection<Filter> GetNetworkFilters(string[] ids)
		{
			return GetApiResultCollection<Filter, NullQuery>(ApiMethodEnum.ReadFilter, CreateNamedVector("{filters}", ids), null);
		}

		/// <summary>
		/// Makes a request to API method /filter/{filters}/read
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/read-filter</para>
		/// </summary>
		/// <param name="id">The single filter in {ids}.</param>
		/// <returns>Returns the filter identified by <paramref name="id"/>.</returns>
		public override IBridgeResponseItem<Filter> GetNetworkFilter(string id)
		{
			return GetNetworkFilters(new[] { id }).Single();
		}

		/// <summary>
		/// Makes a request to API method /sites
		/// <para>Documentation can be found following the link below:</para>
		/// <para>https://api.stackexchange.com/docs/sites</para>
		/// </summary>
		/// <param name="parameters">The request parameters.</param>
		/// <returns>Returns all sites in the network.</returns>
		public override IBridgeResponseCollection<NetworkSite> GetNetworkSites(SimpleQuery parameters = null)
		{
			return GetApiResultCollection<NetworkSite, SimpleQuery>(ApiMethodEnum.Sites, parameters);
		}

		#endregion
	}
}
