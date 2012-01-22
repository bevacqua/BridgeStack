using System;
using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// API method endpoints enumeration.
	/// </summary>
	public enum ApiMethodEnum
	{
		#region Answers

		/// <summary>
		/// https://api.stackexchange.com/docs/answers
		/// </summary>
		[EnumMember(Value = "answers")]
		Answers,
		/// <summary>
		/// https://api.stackexchange.com/docs/answers-by-ids
		/// </summary>
		[EnumMember(Value = "answers/{ids}")]
		AnswersByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-on-answers
		/// </summary>
		[EnumMember(Value = "answers/{ids}/comments")]
		CommentsOnAnswers,

		#endregion

		#region Badges

		/// <summary>
		/// https://api.stackexchange.com/docs/badges
		/// </summary>
		[EnumMember(Value = "badges")]
		Badges,
		/// <summary>
		/// https://api.stackexchange.com/docs/badges-by-ids
		/// </summary>
		[EnumMember(Value = "badges/{ids}")]
		BadgesByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/badge-recipients
		/// </summary>
		[EnumMember(Value = "badges/recipients")]
		BadgeRecipients,
		/// <summary>
		/// https://api.stackexchange.com/docs/badge-recipients-by-ids
		/// </summary>
		[EnumMember(Value = "badges/{ids}/recipients")]
		BadgeRecipientsByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/badges-by-name
		/// </summary>
		[EnumMember(Value = "badges/name")]
		BadgesByName,
		/// <summary>
		/// https://api.stackexchange.com/docs/badges-by-tag
		/// </summary>
		[EnumMember(Value = "badges/tags")]
		BadgesByTag,

		#endregion

		#region Comments

		/// <summary>
		/// https://api.stackexchange.com/docs/comments
		/// </summary>
		[EnumMember(Value = "comments")]
		Comments,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-by-ids
		/// </summary>
		[EnumMember(Value = "comments/{ids}")]
		CommentsByIds,

		#endregion

		#region Errors

		/// <summary>
		/// https://api.stackexchange.com/docs/errors
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "errors")]
		Errors,
		/// <summary>
		/// https://api.stackexchange.com/docs/simulate-errors
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "errors/{id}")]
		SimulateError,

		#endregion

		#region Posts

		/// <summary>
		/// https://api.stackexchange.com/docs/posts
		/// </summary>
		[EnumMember(Value = "posts")]
		Posts,
		/// <summary>
		/// https://api.stackexchange.com/docs/posts-by-ids
		/// </summary>
		[EnumMember(Value = "posts/{ids}")]
		PostsByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-on-posts
		/// </summary>
		[EnumMember(Value = "posts/{ids}/comments")]
		CommentsOnPosts,
		/// <summary>
		/// https://api.stackexchange.com/docs/revisions-by-ids
		/// </summary>
		[EnumMember(Value = "posts/{ids}/revisions")]
		RevisionsByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/posts-on-suggested-edits
		/// </summary>
		[EnumMember(Value = "posts/{ids}/suggested-edits")]
		PostsOnSuggestedEdits,

		#endregion

		#region Privileges

		/// <summary>
		/// https://api.stackexchange.com/docs/privileges
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "privileges")]
		Privileges,

		#endregion

		#region Questions

		/// <summary>
		/// https://api.stackexchange.com/docs/questions
		/// </summary>
		[EnumMember(Value = "questions")]
		Questions,
		/// <summary>
		/// https://api.stackexchange.com/docs/questions-by-ids
		/// </summary>
		[EnumMember(Value = "questions/{ids}")]
		QuestionsByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/answers-on-questions
		/// </summary>
		[EnumMember(Value = "questions/{ids}/answers")]
		AnswersOnQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-on-questions
		/// </summary>
		[EnumMember(Value = "questions/{ids}/comments")]
		CommentsOnQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/linked-questions
		/// </summary>
		[EnumMember(Value = "questions/{ids}/linked")]
		LinkedQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/related-questions
		/// </summary>
		[EnumMember(Value = "questions/{ids}/related")]
		RelatedQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/questions-timeline
		/// </summary>
		[EnumMember(Value = "questions/{ids}/timeline")]
		QuestionsTimeline,
		/// <summary>
		/// https://api.stackexchange.com/docs/unanswered-questions
		/// </summary>
		[EnumMember(Value = "questions/unanswered")]
		UnansweredQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/no-answer-questions
		/// </summary>
		[EnumMember(Value = "questions/no-answers")]
		NoAnswerQuestions,

		#endregion

		#region Revisions

		/// <summary>
		/// https://api.stackexchange.com/docs/revisions-by-guids
		/// </summary>
		[EnumMember(Value = "revisions/{ids}")]
		RevisionsByGuids,

		#endregion

		#region Search

		/// <summary>
		/// https://api.stackexchange.com/docs/search
		/// </summary>
		[EnumMember(Value = "search")]
		Search,
		/// <summary>
		/// https://api.stackexchange.com/docs/similar
		/// </summary>
		[EnumMember(Value = "similar")]
		Similar,

		#endregion

		#region Suggested Edits

		/// <summary>
		/// https://api.stackexchange.com/docs/suggested-edits
		/// </summary>
		[EnumMember(Value = "suggested-edits")]
		SuggestedEdits,
		/// <summary>
		/// https://api.stackexchange.com/docs/suggested-edits-by-ids
		/// </summary>
		[EnumMember(Value = "suggested-edits/{ids}")]
		SuggestedEditsByIds,

		#endregion

		#region Info

		/// <summary>
		/// https://api.stackexchange.com/docs/info
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "info")]
		Info,

		#endregion

		#region Tags

		/// <summary>
		/// https://api.stackexchange.com/docs/tags
		/// </summary>
		[EnumMember(Value = "tags")]
		Tags,
		/// <summary>
		/// https://api.stackexchange.com/docs/tag-synonyms
		/// </summary>
		[EnumMember(Value = "tags/synonyms")]
		TagSynonyms,
		/// <summary>
		/// https://api.stackexchange.com/docs/faqs-by-tags
		/// </summary>
		[EnumMember(Value = "tags/{tags}/faq")]
		FAQ,
		/// <summary>
		/// https://api.stackexchange.com/docs/related-tags
		/// </summary>
		[EnumMember(Value = "tags/{tags}/related")]
		RelatedTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/synonyms-by-tags
		/// </summary>
		[EnumMember(Value = "tags/{tags}/synonyms")]
		SynonymsByTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-answerers-on-tags
		/// </summary>
		[EnumMember(Value = "tags/{tag}/top-answerers/{period}")]
		TopAnswerersOnTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-askers-on-tags
		/// </summary>
		[EnumMember(Value = "tags/{tag}/top-askers/{period}")]
		TopAskersOnTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/wikis-by-tags
		/// </summary>
		[EnumMember(Value = "tags/{tags}/wikis")]
		WikisByTags,

		#endregion

		#region Users

		/// <summary>
		/// https://api.stackexchange.com/docs/users
		/// </summary>
		[EnumMember(Value = "users")]
		Users,
		/// <summary>
		/// https://api.stackexchange.com/docs/users-by-ids
		/// </summary>
		[EnumMember(Value = "users/{ids}")]
		UsersByIds,
		/// <summary>
		/// https://api.stackexchange.com/docs/answers-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/answers")]
		AnswersOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/badges-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/badges")]
		BadgesOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/comments")]
		CommentsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/comments-by-users-to-user
		/// </summary>
		[EnumMember(Value = "users/{ids}/comments/{toid}")]
		CommentsByUsersToUser,
		/// <summary>
		/// https://api.stackexchange.com/docs/favorites-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/favorites")]
		FavoritesOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/mentions-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/mentioned")]
		MentionsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/privileges-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/privileges")]
		PrivilegesOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/questions-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/questions")]
		QuestionsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/no-answer-questions-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/questions/no-answers")]
		NoAnswerQuestionsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/unaccepted-questions-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/questions/unaccepted")]
		UnacceptedQuestionsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/unanswered-questions-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/questions/unanswered")]
		UnansweredQuestionsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/reputation-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/reputation")]
		ReputationOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/suggested-edits-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/suggested-edits")]
		SuggestedEditsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/tags-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/tags")]
		TagsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-user-answers-in-tags
		/// </summary>
		[EnumMember(Value = "users/{id}/tags/{tags}/top-answers")]
		TopUserAnswersInTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-user-questions-in-tags
		/// </summary>
		[EnumMember(Value = "users/{id}/tags/{tags}/top-questions")]
		TopUserQuestionsInTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/timeline-on-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/timeline")]
		TimelineOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-answer-tags-on-users
		/// </summary>
		[EnumMember(Value = "users/{id}/top-answer-tags")]
		TopAnswerTagsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/top-question-tags-on-users
		/// </summary>
		[EnumMember(Value = "users/{id}/top-question-tags")]
		TopQuestionTagsOnUsers,
		/// <summary>
		/// https://api.stackexchange.com/docs/moderators
		/// </summary>
		[EnumMember(Value = "users/moderators")]
		Moderators,
		/// <summary>
		/// https://api.stackexchange.com/docs/elected-moderators
		/// </summary>
		[EnumMember(Value = "users/moderators/elected")]
		ElectedModerators,

		#endregion

		#region Network

		/// <summary>
		/// https://api.stackexchange.com/docs/invalidate-access-tokens
		/// </summary>
		[EnumMember(Value = "access-tokens/{accessTokens}/invalidate")]
		InvalidateAccessTokens,
		/// <summary>
		/// https://api.stackexchange.com/docs/read-access-tokens
		/// </summary>
		[EnumMember(Value = "access-tokens/{accessTokens}/read")]
		ReadAccessTokens,
		/// <summary>
		/// https://api.stackexchange.com/docs/application-de-authenticate
		/// </summary>
		[EnumMember(Value = "access-tokens/{accessTokens}/de-authenticate")]
		ApplicationDeauthenticate,

		/// <summary>
		/// https://api.stackexchange.com/docs/filter-create
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "filter/create")]
		FilterCreate,
		/// <summary>
		/// https://api.stackexchange.com/docs/read-filter
		/// </summary>
		[CacheLifeSpan(1)]
		[EnumMember(Value = "filter/{filters}/read")]
		ReadFilter,

		/// <summary>
		/// https://api.stackexchange.com/docs/sites
		/// </summary>
		[EnumMember(Value = "sites")]
		Sites,

		/// <summary>
		/// https://api.stackexchange.com/docs/associated-users
		/// </summary>
		[EnumMember(Value = "users/{ids}/associated")]
		AssociatedUsers,

		#endregion

		#region Authentication Required

		#region Events

		/// <summary>
		/// https://api.stackexchange.com/docs/events
		/// </summary>
		[EnumMember(Value = "events")]
		Events,

		#endregion

		#region Users

		/// <summary>
		/// https://api.stackexchange.com/docs/user-inbox
		/// </summary>
		[EnumMember(Value = "users/{id}/inbox")]
		UserInbox,
		/// <summary>
		/// https://api.stackexchange.com/docs/user-inbox-unread
		/// </summary>
		[EnumMember(Value = "users/{id}/inbox/unread")]
		UserInboxUnread,

		/// <summary>
		/// https://api.stackexchange.com/docs/me
		/// </summary>
		[EnumMember(Value = "me")]
		Me,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-answers
		/// </summary>
		[EnumMember(Value = "me/answers")]
		MyAnswers,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-badges
		/// </summary>
		[EnumMember(Value = "me/badges")]
		MyBadges,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-comments
		/// </summary>
		[EnumMember(Value = "me/comments")]
		MyComments,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-comments-to
		/// </summary>
		[EnumMember(Value = "me/comments/{toid}")]
		MyCommentsTo,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-favorites
		/// </summary>
		[EnumMember(Value = "me/favorites")]
		MyFavorites,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-mentioned
		/// </summary>
		[EnumMember(Value = "me/mentioned")]
		MyMentions,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-privileges
		/// </summary>
		[EnumMember(Value = "me/privileges")]
		MyPrivileges,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-questions
		/// </summary>
		[EnumMember(Value = "me/questions")]
		MyQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-no-answer-questions
		/// </summary>
		[EnumMember(Value = "me/questions/no-answers")]
		MyNoAnswerQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-unaccepted-questions
		/// </summary>
		[EnumMember(Value = "me/questions/unaccepted")]
		MyUnacceptedQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-unanswered-questions
		/// </summary>
		[EnumMember(Value = "me/questions/unanswered")]
		MyUnansweredQuestions,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-reputation
		/// </summary>
		[EnumMember(Value = "me/reputation")]
		MyReputation,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-suggested-edits
		/// </summary>
		[EnumMember(Value = "me/suggested-edits")]
		MySuggestedEdits,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-tags
		/// </summary>
		[EnumMember(Value = "me/tags")]
		MyTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-tags-top-answers
		/// </summary>
		[EnumMember(Value = "me/tags/{tags}/top-answers")]
		MyTopAnswersInTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-tags-top-questions
		/// </summary>
		[EnumMember(Value = "me/tags/{tags}/top-questions")]
		MyTopQuestionsInTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-timeline
		/// </summary>
		[EnumMember(Value = "me/timeline")]
		MyTimeline,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-top-answer-tags
		/// </summary>
		[EnumMember(Value = "me/top-answer-tags")]
		MyTopAnswerTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-top-question-tags
		/// </summary>
		[EnumMember(Value = "me/top-question-tags")]
		MyTopQuestionTags,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-inbox
		/// </summary>
		[EnumMember(Value = "me/inbox")]
		MyInbox,
		/// <summary>
		/// https://api.stackexchange.com/docs/me-inbox-unread
		/// </summary>
		[EnumMember(Value = "me/inbox/unread")]
		MyInboxUnread,
		
		#endregion

		#region Network

		/// <summary>
		/// https://api.stackexchange.com/docs/inbox
		/// </summary>
		[EnumMember(Value = "inbox")]
		Inbox,
		/// <summary>
		/// https://api.stackexchange.com/docs/inbox-unread
		/// </summary>
		[EnumMember(Value = "inbox/unread")]
		InboxUnread,
		
		/// <summary>
		/// https://api.stackexchange.com/docs/me-associated-users
		/// </summary>
		[EnumMember(Value = "me/associated")]
		MyAssociatedUsers,

		#endregion

		#endregion
	}
}